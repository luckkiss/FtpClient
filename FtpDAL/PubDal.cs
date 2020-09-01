using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpDAL
{
    public static class PubDal
    {

        private static FileHashDAL _filehashDal = null;
        ///<summary>
        ///文件Hash值
        ///</summary>
        public static FileHashDAL filehashDal { get { return _filehashDal == null ? (_filehashDal = new FileHashDAL()) : _filehashDal; } }

        private static ProjectDAL _projectDal = null;
        ///<summary>
        ///项目
        ///</summary>
        public static ProjectDAL projectDal { get { return _projectDal == null ? (_projectDal = new ProjectDAL()) : _projectDal; } }

    }
}
