using System.Drawing;

namespace FtpModel
{
    public class RetunFileInfo
    {

        public RetunFileInfo()
        {

        }

        public RetunFileInfo(string Name, string CreateTime)
        {
            this.Name = Name;          
            this.CreateTime = CreateTime;           
        }
      
        public string Name { get; set; }
        public string Size { get; set; }
        public string CreateTime { get; set; }
        public string Type { get; set; }
    }
}
