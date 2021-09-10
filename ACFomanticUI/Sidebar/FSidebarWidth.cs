using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏宽度
    /// </summary>
    public enum FSidebarWidth
    {
        /// <summary>
        /// 薄
        /// </summary>
        Thin,
        /// <summary>
        /// 很薄
        /// </summary>
        [EnumClass("very thin")]
        VeryThin,
        /// <summary>
        /// 宽
        /// </summary>
        Wide,
        /// <summary>
        /// 很宽
        /// </summary>
        [EnumClass("very wide")]
        VeryWide
    }
}
