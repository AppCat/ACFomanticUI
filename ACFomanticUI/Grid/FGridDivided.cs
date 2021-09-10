using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 栅格分隔符
    /// </summary>
    public enum FGridDivided
    {
        /// <summary>
        /// 水平
        /// </summary>
        [EnumClass("divided")]
        Horizontal,
        /// <summary>
        /// 垂直
        /// </summary>
        [EnumClass("vertically divided")]
        Vertically,
        /// <summary>
        /// 全部
        /// </summary>
        Celled,
        /// <summary>
        /// 全部内部的
        /// </summary>
        [EnumClass("internally celled")]
        InternallyCelled
    }
}
