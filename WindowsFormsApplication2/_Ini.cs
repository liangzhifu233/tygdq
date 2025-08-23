using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class _Ini
    {
        private static ConfigManager configManager;

        public string path; //INI文件名

        public _Ini(string inipath)
        {
            if (configManager != null)
            {
                return;
            }

            this.path = Application.StartupPath + "\\" + inipath;
            configManager = new ConfigManager(path);
            //this.path = inipath;
        }

        //声明读写INI文件的API函数    
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
            int size, string filePath);

        //写INI文件　　　    
        public void IniWriteValue(string section, string Key, string Value)
        {
            // WritePrivateProfileString(section, Key, Value, this.path);
            configManager.SetConfigurationValue(section, Key, Value);
        }

        //读取INI文件指定
        public string IniReadValue(string section, string Key, string def, bool reload = false)
        {
            // try
            // {
            //     StringBuilder temp = new StringBuilder(2048);
            //     int i = GetPrivateProfileString(section, Key, def, temp, 2048, this.path);
            //
            //     return temp.ToString().Trim();
            // }
            // catch
            // {
            //     return null;
            // }
            return configManager.GetConfigurationValue(section, Key, def, reload);
        }
    }
}