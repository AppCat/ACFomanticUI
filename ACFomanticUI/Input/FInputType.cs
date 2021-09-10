using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 输入框类型
    /// </summary>
    public enum FInputType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 密码
        /// </summary>
        Password,
        /// <summary>
        /// 数字
        /// </summary>
        Number,
        /// <summary>
        /// 无符号数字
        /// </summary>
        [EnumClass("datetime-local")]
        Datetime
    }
}
