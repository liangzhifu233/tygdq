using System.Collections.Generic;
using System.Text;

namespace Citi
{
    public class UnicodeUtil
    {
        private static byte LEFT_0 = 0b00000000;
        private static byte LEFT_1 = 0b10000000;
        private static byte LEFT_2 = 0b11000000;
        private static byte LEFT_3 = 0b11100000;
        private static byte LEFT_4 = 0b11110000;
        private static byte LEFT_5 = 0b11111000;
        private static byte LEFT_6 = 0b11111100;
        private static byte LEFT_7 = 0b11111110;
        private static byte LEFT_8 = 0b11111111;

        /**
         * 获取真实字数
         */
        public static int GetLength(string s)
        {
            return ToStringList(s).Count;
        }

        /**
         * 按UTF8编码规则分成一个一个汉字的字符串列表
         */
        public static List<string> ToStringList(string s)
        {
            List<string> list = new List<string>(s.Length);
            byte[] bytes;
            bytes = Encoding.UTF8.GetBytes(s);
            int i = 0;
            while (i < bytes.Length)
            {
                byte b = bytes[i];
                int rest;
                if (b < LEFT_2)
                {
                    rest = 0;
                }
                else if (b < LEFT_3)
                {
                    rest = 1;
                }
                else if (b < LEFT_4)
                {
                    rest = 2;
                }
                else if (b < LEFT_5)
                {
                    rest = 3;
                }
                else if (b < LEFT_6)
                {
                    rest = 4;
                }
                else if (b < LEFT_7)
                {
                    rest = 5;
                }
                else if (b < LEFT_8)
                {
                    rest = 6;
                }
                else if (b == LEFT_8)
                {
                    rest = 7;
                }
                else
                {
                    rest = 0;
                }

                List<byte> byteList = new List<byte>(rest + 1);
                byteList.Add(b);
                for (int j = 0; j < rest; j++)
                {
                    byteList.Add(bytes[++i]);
                }

                list.Add(Encoding.UTF8.GetString(ToByteArray(byteList)));
                i++;
            }

            return list;
        }

        /**
         * 判断是否含汉字
         */
        public static bool HasChinese(string ss)
        {
            char[] s = ss.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((0x4E00 <= c && c <= 0x9FA5) || (0x9FA6 <= c && c <= 0x9FEF) || (0x3400 <= c && c <= 0x4DB5) ||
                    (0x20000 <= c && c <= 0x2A6D6) || (0x2A700 <= c && c <= 0x2B734) ||
                    (0x2B740 <= c && c <= 0x2B81D) || (0x2B820 <= c && c <= 0x2CEA1) ||
                    (0x2CEB0 <= c && c <= 0x2EBE0) || (0x2F00 <= c && c <= 0x2FD5) || (0x2E80 <= c && c <= 0x2EF3) ||
                    (0xF900 <= c && c <= 0xFAD9) || (0x2F800 <= c && c <= 0x2FA1D) || (0xE815 <= c && c <= 0xE86F) ||
                    (0xE400 <= c && c <= 0xE5E8) || (0xE600 <= c && c <= 0xE6CF) || (0x31C0 <= c && c <= 0x31E3) ||
                    (0x2FF0 <= c && c <= 0x2FFB) || (0x3105 <= c && c <= 0x312F) || (0x31A0 <= c && c <= 0x31BA) ||
                    (0x3007 <= c && c <= 0x3007))
                    return true;
            }

            return false;
        }

        public static string ToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        private static byte[] ToByteArray(List<byte> byteList)
        {
            byte[] bytes = new byte[byteList.Count];
            int i = 0;
            foreach (byte b in byteList)
            {
                bytes[i++] = b;
            }

            return bytes;
        }
    }
}