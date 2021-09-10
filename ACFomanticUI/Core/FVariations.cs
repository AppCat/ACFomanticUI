using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 变奏曲
    /// </summary>
    public enum FVariations
    {
        /// <summary>
        /// 翻转
        /// </summary>
        Inverted,
        /// <summary>
        /// 基本
        /// </summary>
        Basic,
        /// <summary>
        /// 基本与倒转
        /// </summary>
        [EnumClass("basic inverted")]
        BasicAndInverted
    }
}
