using BingYing.DataBase.Sql;
using System;
using System.ComponentModel;
using System.Data;
namespace FtpModel
{
    ///<summary>
    ///文件Hash值
    ///</summary>
    [Serializable]
    public class FileHash
    {

        public FileHash()
        {

        }
        /// <summary>
        /// 文件Hash值
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Hash"></param>
        /// <param name="ProjectId"></param>
        public FileHash(string FilePath, string Hash, long ProjectId)
        {
            this.FilePath = FilePath;
            this.Hash = Hash;
            this.ProjectId = ProjectId;
        }

        ///<summary>
        ///标识Id
        ///</summary>
        [DataField(SqlDbType.BigInt, false, 8, true, true, "标识Id")]
        [DisplayName("标识Id")]
        public long Id { get; set; }
        ///<summary>
        ///文件路径
        ///</summary>
        [DataField(SqlDbType.VarChar, false, 256, false, false, "文件路径")]
        [DisplayName("文件路径")]
        public string FilePath { get; set; }
        ///<summary>
        ///Hash值
        ///</summary>
        [DataField(SqlDbType.VarChar, false, 64, false, false, "Hash值")]
        [DisplayName("Hash值")]
        public string Hash { get; set; }
        ///<summary>
        ///项目Id
        ///</summary>
        [DataField(SqlDbType.BigInt, false, 8, false, false, "项目Id")]
        [DisplayName("项目Id")]
        public long ProjectId { get; set; }

    }
}
