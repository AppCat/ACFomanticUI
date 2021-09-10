using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 颠倒的
    /// 网格或行可以指定其列在不同设备大小时的顺序相反
    /// A grid or row can specify that its columns should reverse order at different device sizes
    /// <remarks>
    /// 反向网格与分割网格和其他复杂网格类型兼容。
    /// Reversed grids are compatible with divided grids and other complex grid types.
    /// </remarks>
    /// </summary>
    public enum FGridReversed
    {
        /// <summary>
        /// 计算机
        /// </summary>
        [EnumClass("computer reversed")]
        Computer,
        /// <summary>
        /// 平板
        /// </summary>
        [EnumClass("tablet reversed")]
        Tablet,
        /// <summary>
        /// 移动设备
        /// </summary>
        [EnumClass("mobile reversed")]
        Mobile,
        /// <summary>
        /// 计算机 垂直
        /// </summary>
        [EnumClass("computer vertically reversed")]
        ComputerVertically,
        /// <summary>
        /// 平板 垂直
        /// </summary>
        [EnumClass("tablet vertically reversed")]       
        TabletVertically,
        /// <summary>
        /// 移动设备 垂直
        /// </summary>
        [EnumClass("mobile vertically reversed")]
        MobileVertically,
    }
}
