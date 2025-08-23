namespace Citi
{
    public class CodeInfo
    {
        public string code; // 词条词提编码
        public int length; // 词条词提编码长度
        public string realCode; // 词条真实编码
        public int realLength; // 词条真实编码长度
        public int no; // 词条候选（从1开始）

        public bool hasChinese; // 词条是否含汉字

        public CodeInfo(string code, int length, string realCode, int realLength, int no, bool hasChinese)
        {
            this.code = code;
            this.length = length;
            this.realCode = realCode;
            this.realLength = realLength;
            this.no = no;
            this.hasChinese = hasChinese;
        }
    }
}