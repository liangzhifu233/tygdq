namespace Citi
{
    public class Edge
    {
        public int u; // 词条起点
        public int v; // 下一词条起点
        public string word; // 词条
        public bool single; // 是否单字

        public Edge(int u, int v, string word, bool single)
        {
            this.u = u;
            this.v = v;
            this.word = word;
            this.single = single;
        }
    }
}