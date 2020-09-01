using FtpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpDAL
{
    /// <summary>
    ///文件Hash值
    /// <summary>
    [Serializable]
    public class FileHashDAL : CommonExDAL<FileHash>
    {
        public FileHashDAL()
        {
            TabAnnotation = "文件Hash值";
        }


        public FileHash GetModel(string FilePath, long ProjectId)
        {
            return GetModel("FilePath=@FilePath and ProjectId=@ProjectId", MakeInParam("@FilePath", FilePath), MakeInParam("@ProjectId", ProjectId));
        }
    }
}

