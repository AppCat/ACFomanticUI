using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 动画
    /// 一个按钮可以动画显示隐藏的内容
    /// A button can animate to show hidden content
    /// </summary>
    public enum FButtonAnimated
    {
        /// <summary>
        /// 默认动画
        /// </summary>
        [EnumClass("animated")]
        Animated,
        /// <summary>
        /// 垂直
        /// </summary>
        [EnumClass("animated vertical")]
        Vertical,
        /// <summary>
        /// 凋谢
        /// </summary>
        [EnumClass("animated fade")]
        Fade
    }
}
