using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //正则
using System.Collections;
using WindowsFormsApplication2.编码提示;

namespace WindowsFormsApplication2
{
    public class Glob
    {
        //一些全局变量
        private const string _ver = "0.94";
        public static string Ver = ".250227";

        public static string Form = "添雨跟打器v" + _ver;
        public static string Instration = " t46"; //尾发送字符

        public static string VerInstance = _ver + Ver;

        //public static int su = 0;//测试用的
        public static string BianMa = ""; //编码查询

        /// <summary>
        /// 编码码表
        /// </summary>
        public static List<List<string>> BmTips = new List<List<string>>();

        //控制类
        public static bool notShowjs = false; //显示
        public static bool getStyle = false; //默认鼠标

        /// <summary>
        /// 当前段
        /// </summary>
        public static string Pre_Cout = "1225"; //当前段号

        public static int Time = 0;
        public static string[,] GetWin = new string[40, 2]; //获取的窗口
        public static int GetWinC = 0; //获取窗口的总数
        public static int WinSwitch = 0; //窗口切换控制
        public static string Text; //跟打文字*****
        public static string TypeText; //跟打文章
        public static int TypeTextCount = 0; //已跟打字数
        public static double TextSpeed; //以下为上次成绩
        public static double Textjj;
        public static double Textmc;
        public static string TextPreCout = ""; //上次段号
        public static bool ReTypePD = false; //重打判断
        public static int TextLen; //总字数
        public static int TextJc = 0; //需要减去的数量
        public static int TextCz = 0; //错字
        public static int TextiCz = 0; //正字计数（用来    获取错字数量）
        public static int TextJs = 0; //键数

        public static int TextMc = 0; //码长完美计数
        public static int TextMcc = 0; //完美计数总量

        public static int TextJj = 0; //击键
        public static ArrayList TextHgPlace = new ArrayList(); //显示回改地点
        public static int TextHgPlace_Skip = 0; //点击跳转的标记
        public static int TextBg = 0; //退格 + 回改量
        public static int 回车 = 0;
        public static int 选重 = 0;
        public static bool 是否选重 = true;
        public static bool 文段类型 = true; //真 为中文 假为英文
        public static int leftHand = 0;
        public static int rightHand = 0;
        public static int 撤销 = 0;
        public static int 撤销用量 = 0;
        public static double 速度限制 = 0.00;

        public static bool 是否速度限制 = false;

        //检查过程是否一直持续
        public static DateTime nowStart;

        //段数
        public static Match getDuan;

        public static Regex regexCout;

        //颜色 
        public static Color Right;
        public static Color False;

        public static Color r1Back;

        //峰值
        public static double MaxSpeed = 0;
        public static double MaxJj = 0;
        public static double MaxMc = 10; //码长


        public static int TextHg = 0; //回改
        public static int TextHgAll = 0; //总回改

        /// <summary>
        /// 回改用时
        /// </summary>
        public static double hgAllUse;

        public static int TextLenAll; //跟打的总字数

        /// <summary>
        /// 记录开始时的字数
        /// </summary>
        public static int TextRecLenAll; //

        /// <summary>
        /// 记录天数
        /// </summary>
        public static int TextRecDays = 0;

        /// <summary>
        /// 今日时间    
        /// </summary>
        public static string TodayDate;

        public static double TextHg_ = 0; //回改率

        public static string InstraPre = ""; //个签
        public static string InstraPre_ = ""; //是否启用了个签

        public static int LoadCount = 0; //载入次数 暂时是用来确定是否开启输入法
        public static double typeUseTime; //跟打用时
        public static int HaveTypeCount = 0; //已跟打段数
        public static int HaveTypeCount_ = 0; //实际跟打段数
        public static double TotalUse = 0; //总用时
        public static string InstraSrf = ""; //输入法签名
        public static string InstraSrf_ = ""; //是否启用了输入法签名

        public static int aTypeWords = 0; //打词

        public static Font font_1; //对照区字体大小
        public static Font font_2; //跟打区字体大小

        public static bool binput = true;
        public static int oneH; //一行高度
        public static int reTypeCount = 0; //重打次数

        /// <summary>
        /// 跟打效率
        /// </summary>
        public static int 效率 = 0;

        //发送的控制
        public static string sortSend = "ABCVGDSTLUEFNOPRQ";
        public static int LastInput = 0; //末字错时不发送 可以继续跟打
        public static int DelaySend = 50; //打完发送延时
        public static bool sendOrNo = false; //是否 显示 发送框 默认 否
        public static bool GDQActon = false; //跟打完后 是否激活跟打器

        //跟打历史
        public static int TypeCount = 0; //跟打次数

        //发文标记
        public static int SendNow = 0;

        public static string PreText; //前导
        public static string PreDuan; //段标
        public static bool isZdy; //自定义开启

        public static string getName = ""; //发文配置的名称

        //图表速度传递
        public static double chartSpeedTo = 0;
        public static bool chartShow = false;

        //表传递
        public static int Count = 0;

        //平均所有
        public static double Per_Speed = 0; //平均速度
        public static double Per_Jj = 0; //平均击键
        public static double Per_Mc = 0; //平均码长
        public static double Per_Hg = 0; //平均回改
        public static double Per_Jz = 0; //平均键准
        public static double Per_Zs = 0; //平均字数
        public static int Total_Type = 0; //跟打总字数

        //今日已跟打
        public static int todayTyping = 0;

        //比赛验证
        public static bool isMatch = false; //比赛

        //上一次跟打
        public static string theLastGoal = "";

        public static bool isQQ = false;

        public static string QQnumber;

        //随机段数
        public static int AZpre = 88;

        //错次
        public static int FalseCount = 0;
        public static ArrayList FWords = new ArrayList();
        public static int FWordsSkip = 0; //错字跳转标记

        //拖动条
        public static int p1;

        public static int p2;

        //曲线界面
        public static bool isShowSpline = false; //默认显示

        //停止用时
        public static int StopUse = 1;

        //曲线极值
        public static double MinSplite = 500;

        //极简模式
        public static bool simpleMoudle = false;
        public static string simpleSplite = "|"; //分隔符

        public static bool jwMatchMoudle = false; //精五比赛模式

        //自动替换英转中
        public static bool autoReplaceBiaodian = false;

        //是否潜水
        public static bool isSub = false;

        //暂停次数
        public static int PauseTimes = 0;

        //击键比例
        public static int[] jjPer = new int[9];

        public static int jjAllC = 0;

        //对因剪切板问题导致的无法获取 采用自动手动功能
        public static bool F4Cut = false; //F4阻拦器

        //跟打地图
        public static Graphics Type_Map;
        public static Color Type_Map_Color = Color.Green;
        public static Color Type_map_C_1 = Color.FromArgb(220, 220, 220);
        public static int Type_Map_C = 200;
        public static int 地图长度 = 0;
        public static bool Type_Map_Level = true; //优先级

        //打开标记
        public static bool isPointIt = false;

        //作弊
        public static bool isCheat = false;

        //分析
        public static bool Use分析 = false;

        //测速点位置
        public static int[] SpeedPoint_ = new int[10]; //测速点控制
        public static double[] SpeedTime = new double[10]; //测速点时间控制
        public static int[] SpeedJs = new int[10]; //键数
        public static int[] SpeedHg = new int[10]; //回改
        public static int SpeedPointCount = 0; //测速点数量控制
        public static int SpeedControl = 0;

        //跟打报告
        public static List<TypeDate> TypeReport = new List<TypeDate>();

        //图片成绩发送昵称
        public static string PicName = "";

        public static string TextTime = "";

        //是否开启智能测词
        public static bool 是否智能测词 = false;
        public static List<BmAll> BmAlls = new List<BmAll>();
        public static double 词库理论码长 = 0;
        public static string 词组编码 = "";
        public static Color[] BmColors = new Color[] { Color.Blue, Color.Red, Color.Purple, Color.DeepPink };

        public static void InitSortSend(string str)
        {
            string sort = "ABCVGDSTLUEFNOPRQHIJKMWXYZ";
            string sortSend = "";
            for (int i = 0; i < sort.Length; i++)
            {
                char c = sort[i];
                if (str.Contains(c))
                {
                    sortSend += c;
                }
            }

            Glob.sortSend = sortSend;
        }

        // 关于输入法过滤emoji的
        private static HashSet<Char> availableChars;
        public static HashSet<string> noEmojiNo;

        static Glob()
        {
            string s =
                "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789的一是不了在我人他这有个大上中来地和说为们到你就也以国那要时出着可道之对会自而得下能过生子年于后发都里没还去所看事如用小作多行只成好家天她方当然心起种想经现但法无同么进学面其前已主从动分把开军又两本因定部与将日理长三些实样十意知此第力很正高什手被身它明老公者见机向问最使全点情外民并战工关回等相二重由头声性应间话文给美业物真体或政几内利打新走位西再产加月却先特制东果才儿门神太合表信女原更己名立比代斯四任次世便提听做海教水眼化通感王各口气别处少常何解平接目变反入笑总安认条金及度让山马受活结数直必白张指报论员放义电五至难系尔建命件死保完场题许空光计怎管非德量强决形期像队清务资统市书司师住带飞即克南区李则觉交社基今北展传叫连治告路万科呢思达记望转边风快色该界权象拉设且取干步林领收根极亲求往每未程式兵据类言吧规品确城观格失虽远办元共令运似准请武改士英车深石术联吗争院火罗轻百夫花离近切识造组流算布导候满早找服官整爱字持跟突影吃商随消单证存击议越精调黑济始台杀需支功华具团脸府集红九青双周八半片容阿曾落除党尽显照备复众陈断价写约包级另病称倒质江敌黄技绝六朝究派线站装刚首亚况示视增古惊史谈谁须引际七器息研留易房广推注坐查语紧念奇若参号企委希响攻剑历势冷哪农投专考图皇土微选终局星足刘男甚严医答父孩乎仅拿营啊标费依低千兴护急仍较竟某防讲列破故客施血节云龙钱举母伤苏族按帝维修巴河划威案底革致冲送态音船段构够群苦责章律京围衣愿斗独喜效怕细例料米热晚项志供害灵密属验般采沉错继境居毛察既否脑批股纪假速续夜帮乐陆退型铁友暗汉句雷状左率网值承弹普试停止久卫药印职掌织助待阳初追哈刻木您预创诉简球射限差树校怪兰波异阵宗充担顿激游育适银胡省食背负警尼排素穿忽酒弟福怀欢环模胜痛招财习险益宝赶脚乱疑挥获坚劳敢压右置层村静略香范副源州纳岁闻余罪玉占哥忙守兄杨跑述座超喝皮田演摇策封佛角卡买室富块判姑配善优征刀恶降娘草积恐妈慢宣读阶靠楚呼姐执检巨免协养洲份顾救控抗肯赵著登犯换露莫尚伊审危掉宫魔欧枪散沙唐亦耳孙屋永毫临圣宋讨谢叶毒航温嘴逃托呀野伯岛索贵良楼朋顺遇户坏景亮烈闪互架渐礼秘丝艺鱼短监君升抓付鬼舰困梦炮税洋隐败概归货松幸诸恩评吸寻介探脱县朱画旁缺释跳误移藏春吉睡刺端翻附核减款味雪央爷遗杂版编齐徐阴雨智班湖丽鲁蒙仙钟康咱固借诗损震吴镇妇均秦鲜序域测洞旧练猛烟笔顶饭灭堂毕补括怒席逐庄禁剧湾乡卖牛暴避旅弄忍欲抱额含忘虚油洛肉输板虎缓婚乃票销迎祖遍冰录虑宁伸臣谷熟玩予奥博材督港狂谋庭亡炸词俄韩寒混拍盘训遭尊厂凡卷麻荣私谓夏丁骨休牙摆勒默迫骑授替拥泽店健睛疗诺透扬载纸岸床唯迅尤伦坦徒稳园抵蓝绿软弱叹握姓择郑盖轮束窗歌篇森午雄丈残伙妻戏醒甲啦塔套折典馆梅迷秋爸灯扩厉曲秀街哭努潜萨硬宇阻搞喊冒纵罢妹塞盛萧桌悲淡访纷鼓圆拜础杜宽犹奔抽懂偏侵刑延侧蒋抬舞赞针纯夺距柳赛申川丹仿途贝曹茶购竞浪姆偷乌胸亿毁库贸末弃墙烧伟雅爆操诚轰杰盟趣挑沿振呆狗恨迹敬勇闭撤促丰挂横疾麦析哲埃彩摩童召乘符眉袭侠筑孤妙培染稍凶耶页触措戴厚汇络售瓦违洗陷援植彻洪魂泪粮抢献玄彼劲摸巧珠尖皆碰凭暂胆订奉灰津聚闹鸟倾厅享忠孔扑唱凤凌汽叔吓妖驻紫鼻肩箭课莱梁奴庆融扫殊裁菜烦估恢镜御币惨迟隔骂瞧圈尸尾仪译珍艾惯荒季曼飘旗舍剩愈缘吹废颗朗累玛牌恰签涉腿燕腰杯罚奋甘奖拒描奶贫婆仰仇粗殿繁弗伏患幕启穷绍沈缩郎桥仁碎泰挺晓旋羊债障虫慈郭赫幻刊裂吕孟凝讯颜伴逼泛瑞辛役翼袁昨捕潮峰径辆偶岂舒邪宜倍插袋浮豪霍爬颇掩症壮拔播渡堆鸡狼零悄拖尺躲俗映灾壁辩猜冬疯码丧艘炎咬番滚哼劝柔赏兽贴伍撞旦狠衡糊隆魏忧跃扎薄堡崇粉汗净赖岩忆帐偿赤丢董愤阁漫佩绕撒详欣巡仔竹蛋盾返扶焦矿矛耐陪乔侍吐闲邦胞辈荷侯滑井墨拳润摄署允晨荡递敏泥彭骗搜曰租幅昏兼肃艇幽奏垂辞菲贯辑戒黎凉嘛浓酸躺污岳枝苍驾截凯炼埋驱箱乏冯慧漂拼桑腾悉涌诊皱迪钢恭恋蛇氏侦碍餐尘邓燃韦饮阅贼呵俩磨欺牵趋锁绪液殖综踪臂储蒂慌惠晋卢慕扰汤陶宪呈聪怨宙宾匆盗跌芳锋佳劫脉哦帕铺遵霸朵腹媒牧抛频驶踏伪惜胁袖幼仗勃册颤盯抚贡贺键洁腊励怜龄扭勤寿弯雾椅尝爹挤届扣券熊询肚肥浑寄夹艰娇拟喷迁疼吾斜祝钻柏挡惧牢鸣叛庞敲屈叙薛腐籍辽穆匹坡铜悟擦抖割沟晃揭掠奈泉狱怔旨池辉祭寂昆猎猫貌娜瓶琴牲吞遥诱羽醉哀搬昌筹剂绩晶俊莲鞋厌鹰柱搭瞪稿践纠俱亏逻迈弥恼浅僧瘦挣睁猪丛跪惑邻胖疲傻宿贷戈葛冠耗贾鉴跨拦粒嗯赔饰廷慰稀祥悬脏仲澳拨趁傅锦仆遣扔衰贪贤削赢捉雕闷湿鼠瞬遂桃辖邮卓豆祸阔枚暖乾梯碗嫌歇押誉丑滴赴赋勾吼嘉斤堪烂契寺坛涂挖娃惟械循邀抑渔傲仓寸吨覆浩帽帅逊姿扁玻蔡闯赌痕唤哩煤庙瑟牺愚唇敦忌玲笼苗逆妥汪纹峡盐耀郁宅碧惩喘饿缝岗弓恒宏谨夸陵墓纽锐慎糖卧羞涨秩挨柴齿斥串档雇鸿悔肌歼砍溜蛮勉漠屏欠扇疏添屠糟滋唉舱磁赐肝桂嘿嫁捷聊茫啥刷喂乙矮缠扯催粹伐吩瓜狐菌廉履披丘儒乳煞兹姊陛柄蜂肤辅绘姜缴潘鹏卿窝沃巫肖穴斩罩肿辨怖愁耕奸爵郡溃隶晴舌绳孝丫婴悠癌翠翰酷惹谭亭霞携泄疫昂卑鞭剥卜轨柯棉袍劈甜矣吟宰饱脖禅臭凑芬俘疆愣莉抹尿辱拾畏吻咽朕骤吵脆妨竭渴览劣铃炉泡摔填顽毅愉豫扮肠狄吊灌壳鹿芒屁棋腔饶夕狭氧摘遮址鲍拆驰匪杆纲盒璃讼倘胃翁艳哎痴畜柜函喉猴枯裤漏秒衫掏妄蓄姚於悦膀崩撑翅厨茨拐锅淮盆钦誓胎涛纤轩崖宴盈寨诞姬懒膜囊脾凄刹耸挽晕砸葬赚斑崔颠陡妃肺後颈棵蜜眠喃嫂陕饲陀尉眨佐驳酬拘寇岭朴撕塑摊爪畅抄冻堵甫俯拱棍虹僵骄卵盲陌盼窃狮逝拓藤歪湘啸猩姻裕赠昭摧氛咳饥铭蓬捧泊菩琼洒滩踢锡璇讶浙嘱鼎逢冈钩罕巾栏廊链谅绵挪辟萍歧筒溪吁芝棒笨辰耻钉寡剪匠筋坑吏瞒妮捏葡漆歉躯耍趟瞎鸭殷冤渊沾舟坠宠蠢逮诡骇玑胶淋茅媚乞谦莎擅宛昔膝翔衙阎夷庸孕账胀镖叉乖杭亨惶恍荆裸嚷骚旺哑姨咒豹碑蔽搏阐窜蝶鹅咐丐轿冥蒲伞恕爽禧弦薪绣焰逸淫杖兆嘲叠龟谎矩捐框愧浦倏哇掀猿栽粘脂衷俺刮脊舅慨恳瘤仑聘戚娶嗓哨兔谊寓绑倡巢瓷钓拂裹涵掘茂泼祈渠纱浴窄贞圳砖蹲坟胳躬徽噢谱甩硕匈侄颁愕讽壶桓浸篮滥僚玫攀裙邵蜀竖萄嘻媳旬焉蒸撰诧挫搁憾哗辣厘帘屡亩邱雀溶霜晰咸衔巷勋窑舆喻躁诏滞桩踩郊琳虏禄聂厦秃丸鸦雁株卒鄙弊彪饼耽叮焚尴耿巩咕鹤哄煌倦咖汝肆腺肢禀兜菊绢诀捞拢垄驴瞄涅魄怯擒囚婉腕呜勿厢诈斋铸舶逗厄帆罐稽冀贱狡喀螺昧泣侨渗嘶稣塌炭桶卸衍倚溢榜毙衬雌兑贩啡棺荐靖钧坎魁谜麽蓦裴棚瞥栖傍锻坊纺旱喇垒芦谬嫩膨譬刃珊肾颂塘驼隙钥尹哟韵掷烛咨贬忖稻堤谍藩斧糕搂霉砰苹棠淘熙怡颖佣俞盏黯斌黛笛窦辐弘捡剿烤捆咧骆魅呐壤淑襄挟谐淹娱逾谕蕴詹沼枕轴煮灿瞅幢伺伽迦绞搅娟凛啪剖倩俏妾禽犬绅枢蹄羡彦蚁汁滨丙膊敞绸捣祷垫斐沸咯逛凰藉叩窥蜡廖眸谴顷奢厮侮莹椎熬镑炒醇睹芙龚辜瑰嫉峻栗莽沫撇迄晒矢匙梳诵屯屑嗅喧痒谣咋婢凳妒堕缚郝妓颊勘垃麟缅篷揉嗣梭潭逍芯樱虞乍蛛钞叱栋苟贿鲸磕奎碌萝缕蔑弩趴寝隋桐倭馨腥杏朽瑶憎昼澄锤遁浆沮垮旷岚姥鳞沦牟虐铅砂滔帖嗡兀兮涯哉燥诛叭蹦蚕畴甸奠嘟峨敷鸽褐嚼榴眯泌寞募暮挠蓉阮蚀霆汹咦荫灶吱妆拙彬秉惭沧丞遏膏溅敛菱庐蔓朦畔裘绒熄泻泳凿澡稚琢蹈阀骸沪豁揽陋侣酿坪虔氢叟瘫捂懈冶莺雍屿匀藻拯跋庇蝉戳绰歹缔舵娥鄂嘎讥圾茎窟澜狸琉硫腻钮拚翘杉裳梢蔬毯枉纬萎晤佑灼邹凹匕憋揣簇怠焕浇矫扛楞觅沐孽呕僻崎赎暑烁绥榻凸潇嚣芽蝇枣坝碟咚樊悍宦煎蛟厥慷炕伶蚂萌匿嵌鞘戎删赦呻仕碳烫啼惕颓雯毋虾暇旭驯嫣茵苑噪棕敝哺簿铲淳踱梵粪尬缸蝴棘诫窘揪盔坤啤涩晌婶嗜粟溯髓琐蚊涡喔镶奕禹庵疤扳绷叨扼庚葫拣筷棱梨浏聋渺牡沁慑庶膛佟唾橡嘘迂瑜冢磅厕岔嗤葱搓癫呃枫弧晦稼谏襟炯鞠眷缆拧噗琪鳍窍霎朔唔匣眩熏尧裔懿栅斟帜粥肘贮扒瓣嘀忿竿嚎皓吭胧倪峭嗽邑攸垣瞻彰拽槽逞蹬邸迭哆梗撼讳戟俭碱桨崛廓踉磷沛擎冉檀淌蛙诬奚宵硝靴娅夭芸札绽锥浊敖懊迸炽猝鞑悼刁柬礁侥苛喽锣拇妞胚祁掐熔腮轼栓哮邢颐瑛铮蜘窒缀酌鞍岑嗔褚矗醋殆幡卦壕骏匡馈寥徘煽噬墅涕袜饷霄墟絮荀釉崭搀笃缎钙罡杠闺唬槐酱锯垦肋陇颅悯摹缪懦咆霹翩茜拴汰痰忒捅薇箫蟹婿炫檐毓湛挚芭绊惫辫嫦踌橱祠肪亥骷撩拎掳蟒靡睦狞珀脯瀑洽羌酋瞿蕊膳恃抒祀嗦剔臀巍瘟坞犀娴舷揖绎驿粤陨渣甄诅氨肮靶疮钝嗨瑚徊幌秽叽缉咎狙鹃啃佬篱鲤咙骡氯闵闽阙拭狩嵩苔舔蔚紊嬉殉禺皂栈峙隘悖濒炳掺忏侈饵昊猾蝗兢拷擂犁霖绫氓嵋酶瞟砌呛韧屎舜巳剃汀婷苇恤佯榆肇臻趾孜揍狈糙钗敕涤嫡佃咄跺噩赣蛊褂捍颔畸蕉颉鸠倔侃亢眶赁噜戮抿谟溺捻埔琦绮樵茄睿酥屉眺皖芜诩瘾胤铀闸辙鳌猖稠炊捶淀烘痪卉矶羁伎椒婪翎髦彷钳勺嗖瞳褪洼梧戊枭衅轧吆竺甭怅锄蹙篡磋憨颌麾菁疚剌唠烙笠铝咪侬殴毗憔搔隧驮俨晏谒驭赃喳璋狰瞩谤褒汴钵睬嘈掣澈哧滇蛾吠狒孵蝠哽垢酣汲笈缰窖睫阱桔筐琅蕾赂抡滤衲廿袅呸澎琵茹蠕筛讪孰曙漱焘椭惋徙惺漩曳胰荧黝酝啧毡疹盎琛忡翟谛巅沌惰菇硅惚簧咀吝娄鸾馒拈脓烹嫖跄虬痊髯攘鲨柿穗桅帷渭淆蝎锈奄鞅贻诣鹦萤攒辗钊啄袄弼匾帛忱弛雏躇撮惦渎墩孚腑阜疙羹禾诘痉迥驹恺槛恪傀磊缭鸥抨怦乒曝俟堑觑壬茸薯戍悚蒜坍豚亵伢寅咏隅炙蔼俾璧鬓恻蹭蹿嗒貂铎蕃诽袱驸肛呱沽圭诃桀矜炬抉咔铠楷葵阑漓聆挛纶幔糜冕霓蹑刨瓢穹褥捎韶祟笋袒滕恬惘阉漪彝淤崽辄筝梓暧拗拌痹蝙埠橙憧凋俸噶橄羔癸邯晖诲亟悸茧涧靳橘珂砾涟锚蘑瑙黏碾磐圃溥芹蜷鹊芮偌偎蜈妩曦偕悻胥薰堰殃秧疡腋嬴鸳瓒胺渤嚓茬娼搐踹萃悴氮叼碉喋鳄绯腓翡釜骼劾暨枷笺揩俐粱麓湄懵钠楠撵乓嫔蹊岐祺撬龋笙唆忐韬潼蜕绚渲肴翌滢聿赘辎籽纂攥瘪簸哒惮掂锭汾溉睾箍蛤瀚磺彗骥绛跤饺酵瑾遽攫沥雳镰撂卤捋讷妊冗怂愫瓮锌顼谚屹馀辕蚤榨帧缜赈惴笆阪苞摒跛蟾瞠秤螭啜囱瘩讹萼烽莞皈扈涣唧踞浚匮螂潦藐氖哝琶癖濮耆杞锵惬诠瘸蹂娠吮蜿蜗遐馅栩暄谑蜒筵砚漾邺沂臆膺萦颍渝漳桢祗帚侏铢淄嗷呗苯缤婵馋蚩饬炖鼾阖壑寰豢僭烬撅竣铐轲榄酪燎漉峦卯丕麒黔跷姗谥唰簌蹋汶鹉玺瑕涎骁筱戌汛胭偃掖噎臧褶盅踵渍嗳瘢飙惆沓碘垛筏氟亘刽浒奂蕙稷缄睑嗟芥憬迳鹫铿挎癞晾璐雒闾邙谧茗嗫藕坯媲蔷荃飒叁甥彤湍猥挝蟋萱兖恙酉媛锺伫镯梆蚌泵鳖漕谄晁贰皋诰汞桦蓟旌飓崆抠胯逵荔羚珑髅篓辘寐皿泯捺傩喏蹒蟠螃嘭脐蜻孺赡蟀隼搪骰荼斡螅楔湮椰佚瀛唷甬踊疣簪蘸祯芷徵痔恣谙掰坂蓓贲卞婊豺潺耷傣玷犊镀剁锷呷赓嗥涸踝诙喙髻钾佼秸噤瞌坷喟戾琏躏窿撸潞谩袂瞑馍茉湃噼痞璞闰鳃啬汕麝虱塾泗淞夙荪昙迢娓熹羲鑫煦徇杳鹞缨欤盂煜匝咂纣拄篆皑翱雹葆钡焙骠殡槌椿辍疵岱眈澹裆牒町恫珥扉苻篝锢鹳胱猓嗬斛恚荤嵇跻箕岌锏泾啾臼厩涓獗龛瞰睽夔籁橹蟆檬腼淖剽匍淇卅跚缮绶擞邃螳嚏腆酮邬唏骧咻鸯曜轶熠嘤恿谀樟蛰蔗痣蛀谆捱耙裨槟谗宸骋杵黜怆啐淬铛侗痘颚沣镐桧氦焊阂琥浣璜蛔荟瘠翦皎醮觐灸窠睐斓儡罹椋獠栾銮摞榈楣镁溟囔昵泞庖缥橇蚯祛蛆榕芍闩飕睢僮娲绾畹罔黠忻癣醺腌妍舀靥噫弈龈蛹沅耘瘴咫擢鬃孛蹩谌淙郸掸氐砥棣蚪盹囤秆圪蚣汩倌咣徨觊偈荚岬镌阚糠蝌邝啷痢苓镂孪箩鳗袤莓喵嬷馁睨咛疟糯疱鄱锹岖蛐嚅穑哂蜃舐弑鳎蜓佗渥蜥酰暹痫酗洵琊炀怏晔蚓郢邕瘀峪愠摺郅胄龇霭啵碴俦璀妲靼宕诋牍婀谔鹗迩铬鹄蒿泓洄畿鲫戛胫韭疽掬隽蒯诳濑褴崂涝骊蠡俚濂镣粼绺鹭瑁懋锰宓娩殁鲇柠骈沏衢纫臊熵饕忑豌琬圩龌汐檄藓榭燮蓿煊魇幺窈弋罂芋筠殒仄蟑箴涿孢弁摈啻椽鹑舫匐柑艮埂獾袈姣婕缙蕨犒揆鲲榔镭郦冽泸鲈滦褛霾扪岷辇啮滂娉叵讫憩噙榷蟮莘咝谡娑蓑钛覃恸鸵诿烯皙歆馐荨诒翊臃俑氲纭砧蛭雉斫祚坳浜箔钚粲涔刍怵辏瘁簦铤摁蝮篙槁剐妫鲑夯隍潢夥犄饯犟荩靓莒榘钜噘蹶殓嘹寮洌嶙懔遛胪耄猕馕恁佞谝阡罄颧濡仨赊纾涮孀狻挞缇饨沱剜纨烷闱猬庑忤骛僖邂呓垠慵宥妪钰熨铡蚱榛诤祉茁谘樽唑鏖飚饽菠杈搽苌谶笞魑龊枞迨噔荻嗲踮癜峒胴掇矾燔酚馥嗝觥媾庋蝈逅遑馄霁拮馑儆赳嗑哐邋涞栎莅蛎偻椤珞懑缈邈鼐呶伲蔫镍辔榀嘁氰邛鳅泅俅墒劭砷槊蛳汜馊燧獭闼啕倜嗵抟橐隗淅醯铣庠昕荥峋蚜琰繇烨咿壹迤旖氤墉柚妤庾昱恽咤酯粑嘣膘镳膑孱晟铳呲疸娣蠹蜚霏酆趺苷淦佝枸盥衮虢濠荭祜笏洹肓诨乩郏鞯铰柩倨琨藜俪詈趔蔺蛉蝼虻麋湎淼忸硼颦芪谯锲芩绻饪缫埽铩苫鳝殇佘诜凇竦飧肽阗忝菟鋈锨霰飨谖浔巽赝泱爻徭羿楹呦鱿囿臾腴觎鸢奘锃蜇稹栉桎觯绉濯滓鹌遨魃龅鸨陂愎跸砭铂卟璨噌衩姹碜舛陲蹴锉褡怼垩茯涪讣纥肱诟轱鹘梏犷聒晗薨闳湟咭麂蹇碣羯榉珏戡伉诓馗髡锟澧醴砺呤泷鸬螨汨咩秣鍪艿赧臬纰姘粕颀畦戕襁诮铨阕逡搡瘙艄笥绦誊窕钍崴煨痿钨翕罅撷岫鲟鄢刈蜴翳揄阈郧郓吒谪赭峥诌渚箸髭眦粽酢媪稗煲裱钹逋昶氅抻媸绌苁琮痤厝呔殚啖酊啶阏洱砝杲钴掴掼帼蚝颢囫骅烩芨赍楫珈胛鲛湫阄趄苣谲矍闶颏哙徕痨羸鬣遴棂馏镏鎏茏渌峁弭篾囡孬怩耨讴沤瓯砒牝莆圻蕲碛芊佥骞衾嗪螓揿蠼醛嵘裟舢潸鄯嬗歙豕螫黍驷薮傥逖悌砣魍嵬潍玮炜幄苋勖铉踅恂桠鼹唁揶铱猗缢薏喑夤璎猷竽鹬爰樾錾甑楂砦獐嶂鸩胝鸷馔骓孳俎嗄褓毖蓖礴舂钏玳谠骶靛仃碇轭鲂淝芾郛蚨矸舸诂牯毂诖涫匦鲧焓菏圜蟪屐齑殛蒺浃痂葭笕戬謇腱峤疥槿玖龃讵橛锴忾岢脍阆蜊锂魉泠牦乜缗螟酩苜猊茑耦俳蛴葺槭愆钤掮荞挈箐磬蛩炔穰瓤稔衽觞畲姝姒崧榫郯瑭帑笤烃菀逶刎鹜硒阋绡硎噱氩恹焱烊苡潆痈壅莜俣龉掾钺笮赜柞旃轸杼炷颛啭笫诹铵骜鏊灞佰碚吡哔笾槎澶菖郴墀褫瘛氚踔鹚撺镫睇钿腚黩芏煅裰屙钒枋凫旮擀绀缟镉虼彀鸪蛄崮痼胍鸹鳏灏曷珩桁蘅鲎阍藿蠖笳跏菅犍讦蚧妗鞫踽蠲狷镢髁缂绔侩髋聩篑蛞锒醪诔嘞嫠娌唳溧鲢臁廪垅缦蟊铆焖勐蠓嘧眇愍旎鲶颞怄葩杷袢逄邳枇睥嘌枰鲆蹼仟芡嫱樯羟遒劬阒鬈禳娆仞鞣缛挲糁膻绱苕嵊锶濉趿遢饧洮佻龆坨芄帏韪莴婺矽郗浠饩狎岘芗勰缬囟擤芎溴鳕垭菸芫厣餍镒饔莠蚴纡萸饫鬻鼋鄣磔鹧枳贽妯茱洙缁锕嗌嫒桉獒螯鞴薜嬖鳊苄亳擘锸汊侪徜鸱雠樗滁蜍楮蹉矬怛笪砀氘籴柢簟胨硐椴碓趸腭珐榧缶呋跗怫砩拊鲋尕赅搿膈硌嘏瞽醢沆貉訇讧唿猢鹕槲怙砉虺咴茴佶芰袷蛱硷疖衿堇粳肼婧僦苴雎裾鄄稞氪倥蔻堀岿阃旯崃鹂枥跞傈奁裢蠊裣鹩囹熘瘘舻囵蜢祢醚縻幂黾渑哞侔脲镊驽匏旆堋蟛罴圮苤笸綦髂悭箝炝愀箧诎黢朐荛桡荏糅蚋噻馓芟疝筮艏铄忪嗾涑嗉僳嗍跆锑醍餮乇跎鼍佤艉阌硪浯寤跹冼魈崤獬庥溆泫埙獯睚闫滟徉崾饴痍峄悒肄瘿镛喁莸卣牖鼬鹆蜮螈刖昀韫缯啁笊柘畛卮栀踯帙陟潴苎缒倬浞鳟捌鲅钣舨锛畚畀煸杓傧镔鹁伧虿廛伥阊鬯焯砗龀榇铖篪莼嵯聃儋凼嶝堞氡鸫髑诶垡蘩畈鲱痱偾葑罘菔蜉黼垓戆锆鲠笱宄晷绲椁盍觳瓠铧鬟篁珲隳嚯笄嵴荠缣裥孑骱炅锩钪芤狯赉谰镧鲡逦呖楝啉辚檩瓴鲮鹨砻轳脔倮膂呒劢熳昴镆蛑钼萘猱蘖钕耪狍铍鼙胼钋萋亓扦缱慊戗蜣硗鞒楸癯洳厍胂菽澍鸶兕谇狲羧唢羰畋粜疃肟焐蚬跣缃枵陉盱楦迓郾蛘挹茔圄塬锗胗钲摭碡躅肫诼赀鲰菹镞嘬砹瑷钯捭鐾铋篦髀濞褊鳔玢髌醭螬蛏裎踟豉蹰憷遄蝽璁榱皴鹾甙箪戥磴蹀玎钭莪苊铒钫悱麸莩泔酐槔藁袼哏岣罟辊磙崞蚶薅糇煳醐岵鹱萑逭镬虮鲚湔艽鹪敫獍窭醵麇疴溘裉喾侉暌愦砬罱嫘喱缡黧鳢疠粝钌蓼尥捩酃旒蒌嵝逯猡漯锊犸鞔旄浼艨蘼敉沔杪蠛暝仫肭曩蛲嬲肀甯孥衄哌泮帔湓蚍貔庀皤芑钎搴褰肷筇跫銎逑糗蕖璩轫葚肜朊铯痧渖殳秫锼荽睃邰薹溏樘醣鼗绨鹈裼殄酡庹脘鲔迕穸舾硖祆籼燹瀣泶窨曛酽欹钇癔鄞鳙蚰蝣嵛圉窳甾罾谵幛跖骘彘螽隹窀粢锱偬驺胙锿蒡荸窆髟邴瓿艚馇躔羼艟骢爨锝鲷鸸镄砜疳仡哿鞲刿菡蟥鳇锪戢镓茭琚胩喹铑缧檑耒锍栌辂硭镅钔硇铙垴甓殍桤葜吣檠黥鸲筌苒襦蕤箬谂炻搠蒴菘溲炱镗煺葳涠仵隰氙鸺嶷窬谮橥翥訾犴狴觇徂殂绐纛镝坻耋坩旰郜觚翮滹洎糨徼喈尻悝瘌潋骝耧娈芈嫫貊柰搦爿裒柒謦歃剡眚蓍疋沭澌眭玟杌欷廨貅蕈崦谳轺怿洇霪撄媵侑燠瑗棹缵阼怍吖埯揞廒聱岙岜茇菝癍趵鹎邶褙坌甏芘妣秕舭荜萆庳筚滗箅襞碥忭缏飑瘭豳踣檗钸晡礤骖黪猹檫镲瘥镡蒇骣冁鲳惝怊耖坼柽枨埕塍酲眵茌彳傺茺瘳帱亍搋膪巛舡棰茈糍楱腠蔟汆镩毳脞骀埭瘅赕萏菪忉羝觌碲阽坫铞铫垤瓞揲鲽疔耵铥岽垌蔸篼椟簖憝礅镦砘哚缍锇蒽鲕佴蹯邡篚棼鼢鲼瀵唪稃绂绋祓桴艴幞黻滏赙鳆钆尜陔戤澉筻鬲塥茛绠珙缑遘觏菰酤臌牿鲴栝桄簋鳜呙埚馘蜾铪胲顸邗撖绗颃嚆蕻黉瘊骺篌堠轷烀冱戽郇锾缳漶鲩擐癀哕浍缋溷耠劐攉钬丌剞墼蕺掎哜跽恝铗瘕戋搛蒹鲣鹣囝枧趼谫牮楗毽踺茳豇礓耩洚僬挢噍鲒卺廑赆腈刭弪扃鬏桕椐锔犋屦桊孓桷觖劂爝皲捃佧锎剀垲蒈莰栲钶骒锞箜眍筘刳郐夼圹纩贶蝰跬蒉醌悃铼漤稂莨蒗铹栳耢仂叻泐鳓酹塄蓠坜苈轹疬猁篥蔹墚埒躐瞵膦柃栊癃垆镥簏氇脶镙瘰蠃泺荦稆杩荬唛颟墁镘漭茆蝥泖瞀猸鹛甍瞢礞艋脒眄鹋苠珉鳘瘼貘耱毪坶镎腩蝻攮坭铌鲵埝陧聍狃胬锘恧筢蒎襻脬醅锫霈郫陴埤蜱仳擗淠犏蹁螵氕俜攴钷掊镤氆镨萁骐蜞屺綮汔岍椠锖镪劁缲郄溱檎锓圊鲭苘茕犰赇巯蝤鼽磲蘧氍悛辁畎悫蚺蝾铷薷颥蓐溽枘脎毵磉颡唼酾钐埏骟垧蛸筲潲猞滠矧椹鲺埘莳鲥贳铈摅毹腧妁厶缌耜螋瞍蔌觫桫铊溻鲐酞锬钽铴耥螗铽慝荑掭祧蜩髫鲦萜莛葶梃仝茼砼酴堍彖暾氽沲柁柝箨腽辋隈沩洧璺蓊蕹圬鼯怃牾阢芴痦菥粞樨鼷觋葸蓰屣舄禊柙莶鹇猃筅葙鲞蟓哓绁渫榍薤躞荇髹糈醑洫揎儇痃碹镟岈痖砑揠罨珧鳐铘黟圯眙舣酏佾埸瘗殪劓镱铟堙狺吲茚蓥铕舁狳雩蝓伛瘐蓣眢箢橼垸龠瀹狁拶糌昝趱驵唣迮帻舴箦昃哳揸砟痄瘵搌嫜仉浈蓁埴絷轵黹豸忮轾踬膣舯荮酎籀邾槠舳瘃麈疰禚嵫趑觜鲻耔秭腙陬鄹躜蕞撙勹宀疒艹刂屮亻卩丶犭攵匚廾虍灬彐纟钅蚵冫糸丿冖凵麴狨彡氵鳋饣礻丨忄扌冂囗軎亠讠衤廴尢齄夂丬辶阝";
            availableChars = new HashSet<Char>();
            foreach (char c in s.ToCharArray())
            {
                availableChars.Add(c);
            }

            // 去掉emoji的段号
            {
                noEmojiNo = new HashSet<string>();
                noEmojiNo.Add("999");
                noEmojiNo.Add("99999");
                noEmojiNo.Add("100000");
                noEmojiNo.Add("100004");
            }
        }

        public static string FilterEmoji(string inputMethod)
        {
            if (inputMethod == null || "".Equals(inputMethod))
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in inputMethod)
            {
                if (availableChars.Contains(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// 跟打报告
    /// </summary>
    public class TypeDate
    {
        /// <summary>
        /// 序
        /// </summary>
        public int Index { set; get; }

        /// <summary>
        /// 跟打起点
        /// </summary>
        public int Start { set; get; }

        /// <summary>
        /// 跟打终点
        /// </summary>
        public int End { set; get; }

        /// <summary>
        /// 跟打长度
        /// </summary>
        public int Length { set; get; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public double NowTime { set; get; }

        /// <summary>
        /// 总时间
        /// </summary>
        public double TotalTime { set; get; }

        /// <summary>
        /// 当前击键
        /// </summary>
        public int Tick { set; get; }

        /// <summary>
        /// 总击键
        /// </summary>
        public int TotalTick { set; get; }
    }
}