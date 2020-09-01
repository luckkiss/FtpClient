using FtpModel;
using System;

namespace FtpDAL
{
    /// <summary>
    ///项目配置
    /// <summary>
    [Serializable]
    public class ProjectDAL : CommonExDAL<Project>
    {
        public ProjectDAL()
        {
            TabAnnotation = "项目";
        }
    }
}