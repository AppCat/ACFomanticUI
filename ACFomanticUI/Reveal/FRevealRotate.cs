using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 旋转
    /// 元素可以旋转以显示下面的内容
    /// An element can rotate to reveal content below
    /// </summary>
    public enum FRevealRotate
    {
        /// <summary>
        /// 左
        /// </summary>
        [EnumClass("rotate left")]
        Left,
        /// <summary>
        /// 右
        /// </summary>
        [EnumClass("rotate")]
        Right,
    }
}
