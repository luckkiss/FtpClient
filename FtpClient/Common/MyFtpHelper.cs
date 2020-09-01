using Common;
using FtpModel;

namespace FtpClient
{
    public class MyFtpHelper : FtpHelper
    {
        public MyFtpHelper(Project model)
        {
            this.IpAddr = model.IpAddr;
            this.UserName = model.UserName;
            this.Password = model.Password;
        }    

    }
}
