using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模式
    /// 元素可以向某个方向移动以显示内容
    /// An element can move in a direction to reveal content
    /// </summary>
    public enum FRevealMove
    {
        /// <summary>
        /// 左
        /// </summary>
        [EnumClass("move")]
        Left,
        /// <summary>
        /// 右
        /// </summary>
        [EnumClass("move right")]
        Right,
        /// <summary>
        /// 上
        /// </summary>
        [EnumClass("move up")]
        Up,
        /// <summary>
        /// 下
        /// </summary>
        [EnumClass("move down")]
        Down
    }
}
