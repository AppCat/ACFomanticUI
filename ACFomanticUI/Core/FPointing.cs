using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 直指
    /// </summary>
    public enum FPointing
    {
        /// <summary>
        /// 顶部
        /// </summary>
        [EnumClass("top pointing")]
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        [EnumClass("bottom pointing")]
        Bottom,
        /// <summary>
        /// 左
        /// </summary>
        [EnumClass("left pointing")]
        Left,
        /// <summary>
        /// 右
        /// </summary>
        [EnumClass("right pointing")]
        Right,
        /// <summary>
        /// 顶左
        /// </summary>
        [EnumClass("top left pointing")]
        TopLeft,
        /// <summary>
        /// 顶右
        /// </summary>
        [EnumClass("top right pointing")]
        TopRight,
        /// <summary>
        /// 底左
        /// </summary>
        [EnumClass("bottom left pointing")]
        BottomLeft,
        /// <summary>
        /// 底右
        /// </summary>
        [EnumClass("bottom right pointing")]
        BottomRight
    }
}
