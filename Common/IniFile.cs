using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    public class IniFile
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string filePath;       

        public IniFile(string INIPath)
        {
            filePath = INIPath;
        }
        public void WriteInivalue(string Key, long value)
        {
            WriteInivalue(Key, value.ToString());
        }

        public void WriteInivalue(string Key, string value)
        {
            WriteInivalue("fbq", Key, value);
        }
        public void WriteInivalue(string Section, string Key, string value)
        {
            WritePrivateProfileString(Section, Key, value, filePath);
        }

        public string ReadInivalue(string Key)
        {
            return ReadInivalue("fbq", Key);
        }
        public string ReadInivalue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filePath);
            return temp.ToString();
        }
    }
}
