using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsFormsApplication2
{
    public class ConfigManager
    {
        private Dictionary<string, Dictionary<string, string>> config;
        private string filePath;

        public ConfigManager(string filePath)
        {
            this.filePath = filePath;
            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            config = new Dictionary<string, Dictionary<string, string>>();
            string[] lines = File.ReadAllLines(filePath, new UTF8Encoding(false));
            string currentSection = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Trim('[', ']');
                    config[currentSection] = new Dictionary<string, string>();
                }
                else
                {
                    var parts = line.Split(new char[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        config[currentSection][parts[0]] = parts[1];
                    }
                }
            }
        }

        public string GetConfigurationValue(string section, string key, string _default, bool reload = false)
        {
            if (reload)
            {
                LoadConfigurations();
            }

            if (config.ContainsKey(section) && config[section].ContainsKey(key))
            {
                return config[section][key];
            }

            return _default;
        }


        public void SetConfigurationValue(string section, string key, string value)
        {
            if (!config.ContainsKey(section))
            {
                config[section] = new Dictionary<string, string>();
            }

            config[section][key] = value;
            SaveConfigurations();
        }

        private void SaveConfigurations()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(false)))
            {
                foreach (var section in config)
                {
                    sw.WriteLine($"[{section.Key}]");
                    foreach (var kvp in section.Value)
                    {
                        sw.WriteLine($"{kvp.Key}={kvp.Value}");
                    }
                }
            }
        }
    }
}