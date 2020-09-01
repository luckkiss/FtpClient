using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace Common
{
    public class FtpHelper
    {
        #region 属性与构造函数

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddr { get; set; }

        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelatePath { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }



        public FtpHelper()
        {

        }

        public FtpHelper(string ipAddr, string userName, string password)
        {
            this.IpAddr = ipAddr;
            this.UserName = userName;
            this.Password = password;
        }
        #endregion

        #region 方法


        /// <summary>
        /// 文件大小格式化
        /// </summary>
        /// <param name="Size"></param>
        /// <returns></returns>
        public string CountSize(string Size)
        {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Convert.ToInt64(Size.Trim());
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + "Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + "KB";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + "MB";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + "GB";
            return m_strSize;
        }


        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="uri">文件夹全路径</param>
        public bool MakeDir(string uri)
        {            
            try
            {
                var response = CallFtp(uri, "MKD");
                var stream = response.GetResponseStream();
                stream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isOk"></param>
        public void DownLoad(string filePath, out bool isOk)
        {
            var uri = string.Format("ftp://{0}{1}", this.IpAddr, this.RelatePath);
            FtpWebResponse response = CallFtp(uri, "RETR");
            ReadByBytes(filePath, response, FtpStatusCode.DataAlreadyOpen, out isOk);
        }

        public void UpLoad(string file, out bool isOk, int times = 2)
        {
            isOk = false;
            FileStream fs = new FileInfo(file).OpenRead();
            var uri = "ftp://" + this.IpAddr + this.RelatePath;
            var request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = "STOR";
            request.UseBinary = true;
            request.ContentLength = fs.Length;
            request.Timeout = 10 * 1000;
            try
            {
                var stream = request.GetRequestStream();
                int BufferLength = 2048; //2K   
                byte[] b = new byte[BufferLength];
                int i;
                while ((i = fs.Read(b, 0, BufferLength)) > 0)
                {
                    stream.Write(b, 0, i);
                }
                stream.Close();
                stream.Dispose();
                isOk = true;
            }
            catch (Exception ex)
            {
                //创建目录
                times--;
                if (MakeDir(Path.GetDirectoryName(uri).Replace(@"ftp:\", "ftp://").Replace(@"\", "/")))
                    if (times > 0)
                        UpLoad(file, out isOk, times);
            }
            finally
            {
                fs.Close();//重要
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">文件完整路径</param>
        public bool DeleteFile(string path, int times = 4)
        {
            try
            {
                var result = String.Empty;
                var response = CallFtp(path, "DELE");
                //Stream stream = response.GetResponseStream();
                //StreamReader sr = new StreamReader(stream);
                //result = sr.ReadToEnd();
                //sr.Close();
                //stream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                times--;
                if (times > 0)
                    return DeleteFile(path, times);
                return false;
            }
        }
        /// <summary>
        /// 删除目录和目录下的文件
        /// </summary>
        /// <param name="path">目录完整路径</param>
        /// <returns></returns>
        public bool DeleteDirectory(string path)
        {
            var isOk = false;
            var times = 10;
            try
            {              
                var list = ListDirectory(out isOk, path);
                for (int i = 0; i < times; i++)
                {
                    if (isOk) break;
                    else list = ListDirectory(out isOk, path);
                }
                foreach (string accept in list)
                {
                    var name = accept.Substring(39);
                    if (accept.IndexOf("<DIR>") != -1)                    
                        DeleteDirectory(path + "/" + name);                   
                    else                                        
                        DeleteFile(path + "/" + name);                   
                }               
                var response = CallFtp(path, "RMD");
                //Stream stream = response.GetResponseStream();
                //StreamReader sr = new StreamReader(stream);
                //sr.Close();
                //stream.Close();
                response.Close();
                isOk = true;
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 展示目录
        /// </summary>
        public string[] ListDirectory(out bool isOk, string uri = "")
        {
            if (uri == "")
                uri = string.Format("ftp://{0}{1}", this.IpAddr, this.RelatePath);
            var response = CallFtp(uri, "LIST");
            return ReadByLine(response, FtpStatusCode.DataAlreadyOpen, out isOk);
        }      


        /// <summary>
        /// 设置上级目录
        /// </summary>
        public void SetPrePath()
        {
            string relatePath = this.RelatePath;
            if (string.IsNullOrEmpty(relatePath) || relatePath.LastIndexOf("/") == 0)
            {
                relatePath = "";
            }
            else
            {
                relatePath = relatePath.Substring(0, relatePath.LastIndexOf("/"));
            }
            this.RelatePath = relatePath;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// CallFtp
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private FtpWebResponse CallFtp(string uri, string method)
        {
            var request = (FtpWebRequest)FtpWebRequest.Create(uri);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = false;
            request.Method = method;
            try
            {
                return (FtpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return null;
            }    
        }


        /// <summary>
        /// 按行读取
        /// </summary>
        /// <param name="response"></param>
        /// <param name="statusCode"></param>
        /// <param name="isOk"></param>
        /// <returns></returns>
        private string[] ReadByLine(FtpWebResponse response, FtpStatusCode statusCode, out bool isOk)
        {
            isOk = false;
            List<string> lstAccpet = new List<string>();
            if (response == null) return lstAccpet.ToArray();
            int i = 0;
            while (true)
            {
                if (response.StatusCode == statusCode)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            lstAccpet.Add(line);
                            line = sr.ReadLine();
                        }
                    }
                    isOk = true;
                    break;
                }
                i++;
                if (i > 10)
                {
                    isOk = false;
                    break;
                }
                Thread.Sleep(50);
            }
            response.Close();
            return lstAccpet.ToArray();
        }

        private void ReadByBytes(string filePath, FtpWebResponse response, FtpStatusCode statusCode, out bool isOk)
        {
            isOk = false;
            int i = 0;
            while (true)

            {
                if (response.StatusCode == statusCode)
                {
                    long length = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];
                    using (FileStream outputStream = new FileStream(filePath, FileMode.Create))
                    {

                        using (Stream ftpStream = response.GetResponseStream())
                        {
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }
                    isOk = true;
                    break;
                }
                i++;
                if (i > 10)
                {
                    isOk = false;
                    break;
                }
                Thread.Sleep(50);
            }
            response.Close();
        }
        #endregion
    }
}