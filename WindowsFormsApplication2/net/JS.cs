using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WindowsFormsApplication2;

namespace Net
{
    public class JS
    {
        private string inputMethod = "";

        private string title = "";
        string article = "";
        private string wordNum = "";

        private string jsTitle = "";
        string jsArticle = "";
        private string jsWordNum = "";

        private Dictionary<string, string> headers = new Dictionary<string, string>
        {
            { "cookie", "" },
            {
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36"
            },
            { "x-requested-with", "XMLHttpRequest" }
        };

        public JS()
        {
        }

        public JS(string userName, string password)
        {
            Init(userName, password);
        }

        public JS(string userName, string password, string inputMethod)
        {
            Init(userName, password);
            this.inputMethod = Glob.FilterEmoji(inputMethod);
        }

        private void Init(string userName, string password)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["u_truename"] = userName;
            data["u_password"] = password;

            string url = "https://www.jsxiaoshi.com/Home/User/login";
            Dictionary<string, string> dictionary = Util.DoPostAddHeaders(url, data);
            if (dictionary.ContainsKey("msg") && "登录成功".Equals(dictionary["msg"]))
            {
                headers["cookie"] = dictionary["cookie"];
            }
            else
            {
                throw new Exception("登录失败！" +
                                    (dictionary.ContainsKey("msg") ? dictionary["msg"] : "请在Ttyping.ty文件检查用户名、密码。"));
            }
        }

        public string GetJBSArticle()
        {
            string url = "https://www.jsxiaoshi.com/index.php/Home/Common/getJbSaiWen";
            Dictionary<string, object> response = Util.DoPost(url, headers, new Dictionary<string, string>());

            try
            {
                JObject msg = (JObject)response["msg"];
                wordNum = msg["6"].ToString();
                title = msg["a_name"].ToString();
                article = msg["a_content"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取锦标赛赛文失败！" + response["msg"].ToString());
                // return article;
            }

            return title + "\r\n" + article + "\r\n" + "-----第100000段-" + title;
        }

        /**
         * @param
         * speed 速度
         * keystrokes 击键
         * maChang 码长
         * typingTime 时间  格式："04:39.266"
         * huiGai 回改
         * huiChe 回车
         * jianShu 键数
         * jianZhun 键准  格式："96.73%"
         * daCi 打词率  格式："63.40%"
         * wrongNum 错字数  
         * inputMethod 输入法
         */
        public string SendJBSScore(
            string speed,
            string keystrokes,
            string maChang,
            string typingTime,
            string huiGai,
            string huiChe,
            string jianShu,
            string jianZhun,
            string daCi,
            string wrongNum
        )
        {
            string url = "https://www.jsxiaoshi.com/index.php/Home/Rank/uploadResult";
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["textTitle"] = title;
            data["speed"] = speed;
            data["keystrokes"] = keystrokes;
            data["maChang"] = maChang;
            data["wordNum"] = wordNum;
            data["typingTime"] = typingTime;
            data["huiGai"] = huiGai;
            data["huiChe"] = huiChe;
            data["jianShu"] = jianShu;
            data["jianZhun"] = jianZhun;
            data["repeatNum"] = "0";
            data["daCi"] = daCi;
            data["wrongNum"] = wrongNum;
            data["inputMethod"] = inputMethod;
            data["challengeFlag"] = "0";
            data["challengeWinner"] = "";
            data["isFirstSubmit"] = "1";

            Dictionary<string, object> response = Util.DoPost(url, headers, data);
            string msg = "上传锦标赛成绩异常！";
            if (response.ContainsKey("msg"))
            {
                msg = (string)response["msg"];
            }

            return msg;
        }

        public string SendJBSScore(
            double speed,
            double keystrokes,
            double maChang,
            TimeSpan typingTime,
            int huiGai,
            int huiChe,
            int jianShu,
            double jianZhun,
            double daCi,
            int wrongNum,
            string imeName
        )
        {
            string url = "https://www.jsxiaoshi.com/index.php/Home/Rank/uploadResult";
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["textTitle"] = title;
            data["speed"] = speed.ToString("F2");
            data["keystrokes"] = keystrokes.ToString("F2");
            data["maChang"] = maChang.ToString("F2");
            data["wordNum"] = wordNum;

            string t = typingTime.ToString();
            int semi = t.LastIndexOf(":");
            if (t.Length > semi + 7)
                t = t.Substring(0, semi + 7);

            if (t.Length > 3 && t.Substring(0, 3) == "00:")
                t = t.Substring(3);


            data["typingTime"] = t;
            data["huiGai"] = huiGai.ToString("F0");
            data["huiChe"] = huiChe.ToString("F0");
            data["jianShu"] = jianShu.ToString("F0");
            data["jianZhun"] = jianZhun.ToString("P2");
            data["repeatNum"] = "0";
            data["daCi"] = daCi.ToString("P2");
            data["wrongNum"] = wrongNum.ToString();
            data["inputMethod"] = imeName;
            data["challengeFlag"] = "0";
            data["challengeWinner"] = "";
            data["isFirstSubmit"] = "1";

            Dictionary<string, object> response = Util.DoPost(url, headers, data);
            string msg = "上传成绩异常！";
            if (response.ContainsKey("msg"))
            {
                msg = (string)response["msg"];
            }

            return msg;
        }

        public string GetJSArticle()
        {
            string url = "http://www.jsxiaoshi.com/index.php/Home/Common/getSaiWen";
            Dictionary<string, object> response = Util.DoPost(url, headers, new Dictionary<string, string>());

            try
            {
                JObject msg = (JObject)response["msg"];
                jsWordNum = msg["6"].ToString();
                jsTitle = msg["a_name"].ToString();
                jsArticle = msg["a_content"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取极速赛文失败！" + response["msg"].ToString());
                // return article;
            }

            return jsTitle + "\r\n" + jsArticle + "\r\n" + "-----第99999段-" + jsTitle;
        }

        /**
         * @param
         * speed 速度
         * keystrokes 击键
         * maChang 码长
         * typingTime 时间  格式："04:39.266"
         * huiGai 回改
         * huiChe 回车
         * jianShu 键数
         * jianZhun 键准  格式："96.73%"
         * daCi 打词率  格式："63.40%"
         * wrongNum 错字数  
         * inputMethod 输入法
         */
        public string SendJSScore(
            string speed,
            string keystrokes,
            string maChang,
            string typingTime,
            string huiGai,
            string huiChe,
            string jianShu,
            string jianZhun,
            string daCi,
            string wrongNum
        )
        {
            string url = "http://www.jsxiaoshi.com/index.php/Home/Rank/uploadResult";
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["textTitle"] = jsTitle;
            data["speed"] = speed;
            data["keystrokes"] = keystrokes;
            data["maChang"] = maChang;
            data["wordNum"] = jsWordNum;
            data["typingTime"] = typingTime;
            data["huiGai"] = huiGai;
            data["huiChe"] = huiChe;
            data["jianShu"] = jianShu;
            data["jianZhun"] = jianZhun;
            data["repeatNum"] = "0";
            data["daCi"] = daCi;
            data["wrongNum"] = wrongNum;
            data["inputMethod"] = inputMethod;
            data["challengeFlag"] = "0";
            data["challengeWinner"] = "";
            data["isFirstSubmit"] = "1";

            Dictionary<string, object> response = Util.DoPost(url, headers, data);
            string msg = "上传日赛成绩异常！";
            if (response.ContainsKey("msg"))
            {
                msg = (string)response["msg"];
            }

            return msg;
        }
    }
}