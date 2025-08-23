using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JiebaNet.Segmenter;

namespace Citi
{
    public class City
    {
        private static object LOCK = new object();
        private static string PATH = "词提"; // 配置文件目录
        private static bool initialized = false; // 是否已初始化码表
        private static City city = new City(); // 单例实例
        private static JiebaSegmenter jieBa = new JiebaSegmenter(); // jieba实例

        private static string NO_CODE = "????"; // 缺编码（用于单字）
        private static int DEFAULT_NO = 1; // 默认候选位置

        // 缺码的编码信息
        private static CodeInfo NO_CODE_INFO =
            new CodeInfo(NO_CODE, NO_CODE.Length, NO_CODE, NO_CODE.Length, DEFAULT_NO, false);

        private int MAX_CH = 666666666; // 最大选重
        private int maxWordLength; // 最大词长（越长计算越慢）

        private bool singeleTip; // 提示单字
        private bool shortFirst; // 码长短优先
        private bool meanFirst; // 语义优先
        private bool firstFirst; // 低重优先

        // 编码长度为1、2、3、4、>4提示的最大重数，0为不提示
        private int code1Limit;
        private int code2Limit;
        private int code3Limit;
        private int code4Limit;
        private int code5Limit;

        // 词条长度为1、2、3、4、>4提示的最大重数，0为不提示
        private int word1Limit;
        private int word2Limit;
        private int word3Limit;
        private int word4Limit;
        private int word5Limit;

        private HashSet<string> bdSet; // 标顶符号
        private HashSet<string> singleSet; // 当前文章单字
        private Dictionary<string, List<CodeInfo>> wordCodeDictionary; // 词、码映射，一词多码
        private Dictionary<int, int> cutDictionary; // jieba 分词结果，起始下标-右边界（右开区间）

        private string article; // 文章
        private CityInfo[] cityInfos; // 每个字的词提信息，同下标字/词的最佳打法
        private int totalCodeLength; // 总码长
        private double avgCodeLength; // 平均码长
        private string articleCodes; // 全文编码

        private int last = -1; // 上次渲染起点

        public static City GetInstance()
        {
            if (!initialized)
            {
                lock (LOCK)
                {
                    if (!initialized)
                    {
                        city.Init();
                        // city.SetArticle("添");
                        initialized = true;
                    }
                }
            }

            return city;
        }

        public static void ResetInstance()
        {
            city.Init();
            if (city.article != null)
            {
                city.GenerateCityInfo();
            }
        }

        public void SetArticle(string article)
        {
            if (article == null || article.Equals(this.article))
            {
                return;
            }

            lock (LOCK)
            {
                this.article = article;
                CutArticle();
                InitSingleSet();
                GenerateCityInfo();
            }
        }

        public CityInfo[] GetCityInfos()
        {
            return cityInfos;
        }

        /**
         * 给个渲染右边界的建议，可以不用，注意F3要ResetEnd() （不保证正确，也容易用错）
         */
        public int GetRenderEnd(int start)
        {
            int res = article.Length;
            if (!(start >= article.Length || last == -1))
            {
                int i1 = start;
                int i2 = last;
                while (i1 < article.Length && i2 < article.Length)
                {
                    if (i1 == i2)
                    {
                        res = i1;
                        break;
                    }

                    if (i1 < i2)
                    {
                        i1 = cityInfos[i1].end;
                    }
                    else
                    {
                        i2 = cityInfos[i2].end;
                    }
                }
            }

            last = start;
            return res;
        }

        public void ResetEnd()
        {
            last = -1;
        }

        public double GetAvgCodeLength()
        {
            return avgCodeLength;
        }

        public string GetArticleCodes()
        {
            return articleCodes;
        }

        public bool IsSingleTip()
        {
            return singeleTip;
        }

        private void CutArticle()
        {
            cutDictionary = new Dictionary<int, int>();
            IEnumerable<string> words = jieBa.Cut(article);
            int begin = 0;
            foreach (string word in words)
            {
                cutDictionary.Add(begin, begin + word.Length);
                begin += word.Length;
            }
        }

        private void InitSingleSet()
        {
            singleSet = new HashSet<string>();
            foreach (string item in UnicodeUtil.ToStringList(article))
            {
                singleSet.Add(item);
            }
        }

        /**
         * 判断是否为单字
         */
        private bool IsSingle(string word)
        {
            return singleSet.Contains(word);
        }

        /**
         * 计算词提的逻辑
         * 从文末往前依次计算每个位置的打法。因为文是单向的，可以根据后文的结果计算当前最佳打法
         */
        private void GenerateCityInfo()
        {
            List<Edge>[] edgeArr = GetEdgeArr(); // 从前向后的单向边，边即是字/词、码长为边权 （码表有才取）

            int[] dist = new int[article.Length + 1]; // 每个字到文末的码长
            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = MAX_CH;
            }

            dist[article.Length] = 0;

            int[] chs = new int[dist.Length]; // 每个字到文末的选重数
            for (int i = 0; i < chs.Length; i++)
            {
                chs[i] = dist[i];
            }

            cityInfos = new CityInfo[dist.Length]; // 起初化空的词提信息
            for (int i = 0; i < cityInfos.Length; i++)
            {
                cityInfos[i] = new CityInfo();
            }

            for (int i = article.Length - 1; i >= 0; i--)
            {
                CityInfo cityInfo = cityInfos[i];
                List<Edge> edgeList = edgeArr[i]; // 以某个字开头可能有多个词可打、或者打单，故有多条边
                foreach (Edge edge in edgeList)
                {
                    string word = edge.word;
                    int u = edge.u;
                    int v = edge.v; // v是下一个词的开头
                    int cutV = cutDictionary.ContainsKey(u) ? cutDictionary[u] : -1; // jieba分词该字的右边界
                    // 如果按分词打，非分词结果的词不取
                    // 由于分出的词可能不在码表，所以单字是可取的
                    if (meanFirst && !edge.single && cutV != v)
                    {
                        continue;
                    }

                    CodeInfo codeInfo = GetCodeInfo(word); // 根据设置选词的编码。该方法无词返null，单字返默认编码
                    if (codeInfo == null)
                    {
                        continue;
                    }

                    // 是否标顶
                    bool bd = v < article.Length && codeInfo.code.EndsWith("_") &&
                              bdSet.Contains(article.Substring(v, 1));
                    int ch = codeInfo.no > 1 ? 1 : 0; // 是否重
                    int curCh = dist[v] + ch; // 当前重数
                    int length = bd ? codeInfo.realLength : codeInfo.length; // 当前词码长
                    int curLength = dist[v] + length; // 当前总码长
                    bool select = false; // 是否选取该词标识
                    if (firstFirst) // 少重优先
                    {
                        if (curCh < chs[u])
                        {
                            select = true;
                        }
                        else if (curCh == chs[u] && (cutV == v || curLength < dist[u])) // 重数一样时，若是分词或码长更短则取
                        {
                            select = true;
                        }
                    }
                    else if (shortFirst) // 码短优先
                    {
                        if (curLength < dist[u])
                        {
                            select = true;
                        }
                        else if (curLength == dist[u] && (cutV == v || curCh < chs[u])) // 码长一样时，若是分词或更少重则取
                        {
                            select = true;
                        }
                    }
                    else // 若分词优先，上面判断过，到这里必可取
                    {
                        select = true;
                    }

                    if (select) // 填充词组词提信息
                    {
                        dist[u] = curLength;
                        chs[u] = curCh;
                        cityInfo.ci = word;
                        cityInfo.ciCode = bd ? codeInfo.realCode : codeInfo.code;
                        cityInfo.ciCodeLength = bd ? codeInfo.realLength : codeInfo.length;
                        cityInfo.ciRealCode = codeInfo.realCode;
                        cityInfo.ciRealCodeLength = codeInfo.realLength;
                        cityInfo.ciNo = codeInfo.no;
                        cityInfo.end = v;
                        cityInfo.hasChinese = codeInfo.hasChinese;
                        if (isSameType(cityInfo, cityInfos[v])) // 是否跟相邻编码、候选都相同
                        {
                            cityInfo.bold = !cityInfos[v].bold; // 相同则加粗取反
                        }
                        else
                        {
                            cityInfo.bold = false; // 不同则不加粗
                        }
                    }
                }

                if (cityInfo.end != i + 1) // 是词组，则第一个字再另取编码
                {
                    string zi = article.Substring(i, 1);
                    CodeInfo ziCodeInfo = GetCodeInfo(zi);
                    cityInfo.zi = zi;
                    cityInfo.ziCode = ziCodeInfo.code;
                    cityInfo.ziNo = ziCodeInfo.no;
                    cityInfo.ziCodeLength = ziCodeInfo.length;
                }
                else // 单字，则zi、ci信息一样
                {
                    cityInfo.zi = cityInfo.ci;
                    cityInfo.ziCode = cityInfo.ciCode;
                    cityInfo.ciNo = cityInfo.ciNo;
                    cityInfo.ciCodeLength = cityInfo.ciCodeLength;
                }
            }

            CalSummary(); // 计算全文总数据
            last = -1; // 重置渲染起点
        }

        private void CalSummary()
        {
            int i = 0;
            int articleLength = article.Length;
            StringBuilder sb = new StringBuilder();
            totalCodeLength = 0;
            while (i < articleLength)
            {
                CityInfo cityInfo = cityInfos[i];
                sb.Append(cityInfo.ciCode);
                totalCodeLength += cityInfo.ciCodeLength;
                i = cityInfo.end;
            }

            avgCodeLength = double.Parse(((double)totalCodeLength / articleLength).ToString("f2"));
            articleCodes = sb.ToString();
        }

        /**
         * 获取以每个字开头可打的词/字
         */
        private List<Edge>[] GetEdgeArr()
        {
            List<Edge>[] edges = new List<Edge>[article.Length];
            for (int i = 0; i < edges.Length; i++)
            {
                List<Edge> list = new List<Edge>();
                edges[i] = list;
                int end = Math.Min(i + maxWordLength, edges.Length + 1);
                for (int j = i + 1; j < end; j++)
                {
                    string word = article.Substring(i, j - i);
                    if (wordCodeDictionary.ContainsKey(word) || IsSingle(word))
                    {
                        list.Add(new Edge(i, j, word, IsSingle(word)));
                    }
                }
            }

            return edges;
        }

        /**
         * 根据配置信息选取编码
         */
        private CodeInfo GetCodeInfo(string word)
        {
            List<CodeInfo> codeInfoList = wordCodeDictionary.ContainsKey(word) ? wordCodeDictionary[word] : null;
            if (codeInfoList == null)
            {
                return UnicodeUtil.GetLength(word) > 1 ? null : NO_CODE_INFO;
            }

            CodeInfo codeInfo = null;
            if (firstFirst) // 低重优先
            {
                int minNo = MAX_CH; // 记录当前最低重
                foreach (CodeInfo cInfo in codeInfoList)
                {
                    if (CheckWordLimit(cInfo, word) && CheckCodeLimit(cInfo)) // 检查码长和词长限制
                    {
                        if (cInfo.no < minNo)
                        {
                            minNo = cInfo.no;
                            codeInfo = cInfo;
                        }

                        if (minNo == 0)
                        {
                            return codeInfo; // 取到首选直接返回即可
                        }
                    }
                }
            }
            else // 编码已按码长升序，若不考虑重直接选第一个符合的编码
            {
                foreach (CodeInfo cInfo in codeInfoList)
                {
                    if (CheckWordLimit(cInfo, word) && CheckCodeLimit(cInfo)) // 检查码长和词长限制
                    {
                        return cInfo;
                    }
                }
            }

            if (UnicodeUtil.GetLength(word) == 1) // 单字有编码但不合要求也取
            {
                codeInfo = codeInfoList[0];
            }

            return codeInfo;
        }


        private bool CheckWordLimit(CodeInfo codeInfo, string word)
        {
            int wl = UnicodeUtil.GetLength(word);
            switch (wl)
            {
                case 1:
                    return codeInfo.no <= word1Limit;
                case 2:
                    return codeInfo.no <= word2Limit;
                case 3:
                    return codeInfo.no <= word3Limit;
                case 4:
                    return codeInfo.no <= word4Limit;
                case 5:
                    return codeInfo.no <= word5Limit;
                default:
                    return true;
            }
        }

        private bool CheckCodeLimit(CodeInfo codeInfo)
        {
            int cl = codeInfo.realLength;
            switch (cl)
            {
                case 1:
                    return codeInfo.no <= code1Limit;
                case 2:
                    return codeInfo.no <= code2Limit;
                case 3:
                    return codeInfo.no <= code3Limit;
                case 4:
                    return codeInfo.no <= code4Limit;
                case 5:
                    return codeInfo.no <= code5Limit;
                default:
                    return true;
            }
        }

        private bool isSameType(CityInfo a, CityInfo b)
        {
            return a.ciRealCodeLength == b.ciRealCodeLength && a.ciNo == b.ciNo;
        }

        private City()
        {
        }

        /**
         * 读取各种文件，路径根据实际情况修改
         */
        private void Init()
        {
            InitJb();
            InitBd();
            InitCodeDictionary();
            InitConfig();
        }

        /**
         * 读取jieba用户词典
         * jieba的自带词组需要放到相应目录，根据报错信息改
         */
        private void InitJb()
        {
            string path = PATH + "\\" + "词组.txt";
            jieBa.LoadUserDict(path);
        }

        private void InitBd()
        {
            string path = PATH + "\\" + "标顶.txt";
            List<string> list = LoadFile(path);
            bdSet = new HashSet<string>();
            foreach (string line in list)
            {
                bdSet.Add(line.Trim());
            }
        }

        /**
         * 读取多多码表，从上到下；同编码上面的在前
         */
        private void InitCodeDictionary()
        {
            string tablePath = PATH + "\\" + "码表.txt";
            List<string> lines = LoadFile(tablePath);

            // 先把同编码的词放到一起；码-词组列表映射
            Dictionary<string, List<string>> codeWordDictionary = new Dictionary<string, List<string>>();
            foreach (string line in lines)
            {
                string[] split = line.Trim().Split('\t');
                if (split.Length < 2)
                {
                    continue;
                }

                string word = split[0];
                string code = split[1];
                List<string> list = codeWordDictionary.ContainsKey(code)
                    ? codeWordDictionary[code]
                    : new List<string>();
                list.Add(word);
                codeWordDictionary[code] = list;
            }

            // 再把词的不同编码放到一起，编码的选重则根据上一步词的位置获得
            wordCodeDictionary = new Dictionary<string, List<CodeInfo>>();
            foreach (KeyValuePair<string, List<string>> pair in codeWordDictionary)
            {
                string code = pair.Key;
                List<string> value = pair.Value;
                for (int i = 0; i < value.Count; i++)
                {
                    int no = i + 1; // 候选位置
                    string word = value[i];
                    string citi = "";
                    if (i == 0)
                    {
                        citi = code + (code.Length < 4 ? "_" : "");
                    }
                    else
                    {
                        citi = code + GetNo(no); // 选重符号要另算一下，默认10重候选，可能有若干=翻页
                    }

                    CodeInfo codeInfo = new CodeInfo(citi, citi.Length, code, code.Length, no,
                        UnicodeUtil.HasChinese(word));
                    AddToDictionary(wordCodeDictionary, word, codeInfo); // 放入词-编码（词提）列表映射
                }
            }

            /*
             * 再把标点的词提读进来
             * 标点词提文件要写最终的词提编码，而不是像码表一样只有abc的编码
             * 然后也放到码表词提映射里
             */
            string symbolPath = PATH + "\\" + "符号.txt";
            lines = LoadFile(symbolPath);
            foreach (string line in lines)
            {
                string[] split = line.Trim().Split('\t');
                if (split.Length < 2)
                {
                    continue;
                }

                string word = split[0];
                string code = split[1];
                CodeInfo codeInfo = new CodeInfo(code, code.Length, code, code.Length, 1, UnicodeUtil.HasChinese(word));
                AddToDictionary(wordCodeDictionary, word, codeInfo);
            }

            // 最后，对每个词的词提编码们排序，优先级：码长 —— 选重 —— 真实编码(字符串排序)，如 abc_ 和 abcd 则 abc_ 优先 
            foreach (KeyValuePair<string, List<CodeInfo>> pair in wordCodeDictionary)
            {
                List<CodeInfo> value = pair.Value;
                value.Sort(delegate(CodeInfo a, CodeInfo b)
                {
                    if (a.length != b.length)
                    {
                        return a.length - b.length;
                    }

                    if (a.no != b.no)
                    {
                        return a.no - b.no;
                    }

                    return a.code.CompareTo(b.code);
                });
            }
        }

        /**
         * 读词提控制配置
         */
        private void InitConfig()
        {
            string path = PATH + "\\" + "config.ini";
            List<string> list = LoadFile(path);
            Dictionary<string, string> configDictionary = new Dictionary<string, string>();
            foreach (string line in list)
            {
                string[] split = line.Trim().Split('=');
                if (split.Length < 2)
                {
                    continue;
                }

                configDictionary.Add(split[0].Trim(), split[1].Trim());
            }

            maxWordLength = GetInt(configDictionary, "最大词长");

            singeleTip = GetBool(configDictionary, "提示单字");
            shortFirst = GetBool(configDictionary, "码短优先");
            meanFirst = GetBool(configDictionary, "语义优先");
            firstFirst = GetBool(configDictionary, "低重优先");

            code1Limit = GetInt(configDictionary, "1码重数");
            code2Limit = GetInt(configDictionary, "2码重数");
            code3Limit = GetInt(configDictionary, "3码重数");
            code3Limit = GetInt(configDictionary, "3码重数");
            code4Limit = GetInt(configDictionary, "4码重数");
            code5Limit = GetInt(configDictionary, "多码重数");

            word1Limit = GetInt(configDictionary, "1字重数");
            word2Limit = GetInt(configDictionary, "2字重数");
            word3Limit = GetInt(configDictionary, "3字重数");
            word3Limit = GetInt(configDictionary, "3字重数");
            word4Limit = GetInt(configDictionary, "4字重数");
            word5Limit = GetInt(configDictionary, "多字重数");
        }

        private void AddToDictionary(Dictionary<string, List<CodeInfo>> dictionary, string word, CodeInfo codeInfo)
        {
            List<CodeInfo> list = dictionary.ContainsKey(word) ? dictionary[word] : new List<CodeInfo>();
            list.Add(codeInfo);
            dictionary[word] = list;
        }

        private string GetNo(int n)
        {
            if (n < 10)
            {
                return "" + n;
            }

            int digit = n % 10;
            int count = n / 10 - (digit == 0 ? 1 : 0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append('=');
            }

            sb.Append(digit == 0 ? "0" : (digit == 1 ? "_" : "" + digit));

            return sb.ToString();
        }

        private int GetInt(Dictionary<string, string> configDictionary, string configName)
        {
            string value = configDictionary.ContainsKey(configName) ? configDictionary[configName] : "0";
            try
            {
                return int.Parse(value);
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        private bool GetBool(Dictionary<string, string> configDictionary, string configName)
        {
            string value = configDictionary.ContainsKey(configName) ? configDictionary[configName] : "否";
            return !"否".Equals(value);
        }

        private static List<string> LoadFile(string path)
        {
            List<string> list = new List<string>();
            String content = "";

            try
            {
                StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
                content = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("打开文件失败");
            }

            foreach (string line in content.Split('\n'))
            {
                list.Add(line);
            }

            return list;
        }
    }
}