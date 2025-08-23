namespace Citi
{
    public class CityInfo
    {
        public string zi; // 词条第一个字
        public string ziCode; // 词条第一个字词提编码
        public int ziNo; // 词条第一个字候选
        public int ziCodeLength; // 词条第一个字词提编码长度
        public string ci; // 词条
        public string ciCode; // 词条词提编码
        public int ciCodeLength; // 词条词提编码长度
        public string ciRealCode; // 词条真实编码
        public int ciRealCodeLength; // 词条真实编码长度
        public int ciNo; // 词条候选
        public int end; // 词条右开区间边界（下一个词条起点）

        public bool hasChinese; // 词条是否含汉字，渲染时标点和含汉字词条采取不同策略
        public bool bold; // 渲染颜色相同时以加粗区分，作为参考；一般做法是真实码长和选重一样的同色

        public CityInfo()
        {
            bold = true;
        }
    }
}