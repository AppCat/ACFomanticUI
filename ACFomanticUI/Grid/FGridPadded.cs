using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 填充
    /// 网格可以在第一列和最后一列保留垂直和水平的排水沟
    /// A grid can preserve its vertical and horizontal gutters on first and last columns
    /// </summary>
    public enum FGridPadded
    {
        /// <summary>
        /// 默认
        /// </summary>
        [EnumClass("padded")]
        Default,
        /// <summary>
        /// 水平
        /// </summary>
        [EnumClass("horizontally padded")]
        Horizontally,
        /// <summary>
        /// 垂直
        /// </summary>
        [EnumClass("vertically padded")]
        Vertically
    }
}
