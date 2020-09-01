using BingYing.DataBase.Sql;
using System;
using System.ComponentModel;
using System.Data;
namespace FtpModel
{
    ///<summary>
    ///项目
    ///</summary>
    [Serializable]
    public class Project
    {

        public Project()
        {


        }

        public Project(string Name, string IpAddr, string UserName, string Password, string WebDir, string LocalDir, string DomainName)
        {
            this.Name = Name;
            this.IpAddr = IpAddr;
            this.UserName = UserName;
            this.Password = Password;
            this.WebDir = WebDir;
            this.LocalDir = LocalDir;
            this.DomainName = DomainName;
        }

        ///<summary>
        ///标识Id
        ///</summary>
        [DataField(SqlDbType.BigInt, false, 8, true, true, "标识Id")]
        [DisplayName("标识Id")]
        public long Id { get; set; }
        ///<summary>
        ///项目名称
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "项目名称")]
        [DisplayName("项目名称")]
        public string Name { get; set; }
        ///<summary>
        ///地址
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "地址")]
        [DisplayName("地址")]
        public string IpAddr { get; set; }
        ///<summary>
        ///账号
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "账号")]
        [DisplayName("账号")]
        public string UserName { get; set; }
        ///<summary>
        ///密码
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "密码")]
        [DisplayName("密码")]
        public string Password { get; set; }
        ///<summary>
        ///远程目录
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "远程目录")]
        [DisplayName("远程目录")]
        public string WebDir { get; set; }
        ///<summary>
        ///本地目录
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "本地目录")]
        [DisplayName("本地目录")]
        public string LocalDir { get; set; }
        ///<summary>
        ///域名
        ///</summary>
        [DataField(SqlDbType.VarChar, true, 50, false, false, "域名")]
        [DisplayName("域名")]
        public string DomainName { get; set; }
        ///<summary>
        ///排序号
        ///</summary>
        [DataField(SqlDbType.Int, true, 4, false, false, "排序号")]
        [DisplayName("排序号")]
        public int Pxh { get; set; }
    }
}