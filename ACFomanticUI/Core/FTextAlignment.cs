using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 文本对齐
    /// </summary>
    public enum FTextAlignment
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        [EnumClass("left aligned")]
        LeftAligned,
        /// <summary>
        /// 右对齐
        /// </summary>
        [EnumClass("right aligned")]
        RightAligned,
        /// <summary>
        /// 居中
        /// </summary>
        [EnumClass("center aligned")]
        CenterAligned,
        /// <summary>
        /// 充满
        /// </summary>
        Justified
    }
}
