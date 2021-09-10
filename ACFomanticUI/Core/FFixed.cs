using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 固定
    /// </summary>
    public enum FFixed
    {
        /// <summary>
        /// 左固定
        /// </summary>
        [EnumClass("left fixed")]   
        Left,
        /// <summary>
        /// 右固定
        /// </summary>
        [EnumClass("right fixed")]
        Right,
        /// <summary>
        /// 上固定
        /// </summary>
        [EnumClass("top fixed")]
        Top,
        /// <summary>
        /// 下固定
        /// </summary>
        [EnumClass("bottom  fixed")]
        Bottom
    }
}
