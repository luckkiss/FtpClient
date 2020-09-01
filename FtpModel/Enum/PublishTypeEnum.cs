using System.ComponentModel;

namespace FtpModel
{
    /// <summary>
    /// 发布类型
    /// </summary>
    public enum PublishTypeEnum
    {
        /// <summary>
        /// 完整发布
        /// </summary>
        [Description("完整发布")]
        完整发布 = 0,

        /// <summary>
        /// 增量发布
        /// </summary>
        [Description("增量发布")]
        增量发布 = 1,

        /// <summary>
        /// 完整发布虚拟
        /// </summary>
        [Description("完整发布虚拟")]
        完整发布虚拟 = 2,

        /// <summary>
        /// 增量发布虚拟
        /// </summary>
        [Description("增量发布虚拟")]
        增量发布虚拟 = 3,

        /// <summary>
        /// 完整发布bin
        /// </summary>
        [Description("完整发布bin")]
        完整发布bin = 4,

        /// <summary>
        /// 完整发布Views
        /// </summary>
        [Description("完整发布Views")]
        完整发布Views = 5,
    }
}
