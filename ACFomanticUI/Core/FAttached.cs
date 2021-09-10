using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 依附
    /// </summary>
    public enum FAttached
    {
        /// <summary>
        /// 依附
        /// </summary>
        [EnumClass("attached")]
        Attached,
        /// <summary>
        /// 顶部
        /// </summary>
        [EnumClass("top attached")]
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        [EnumClass("bottom attached")]
        Bottom,
        /// <summary>
        /// 左
        /// </summary>
        [EnumClass("left attached")]
        Left,
        /// <summary>
        /// 右
        /// </summary>
        [EnumClass("right attached")]
        Right,
        /// <summary>
        /// 顶右
        /// </summary>
        [EnumClass("top right attached")]
        TopRight,
        /// <summary>
        /// 顶左
        /// </summary>
        [EnumClass("top left attached")]
        TopLeft,
        /// <summary>
        /// 底左
        /// </summary>
        [EnumClass("bottom left attached")]
        BottomLeft,
        /// <summary>
        /// 底右
        /// </summary>
        [EnumClass("bottom right attached")]
        BottomRight,
    }
}
