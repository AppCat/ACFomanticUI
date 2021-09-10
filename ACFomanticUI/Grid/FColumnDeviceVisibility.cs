using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 设备可见度
    /// 列或行只能出现在特定的设备或屏幕大小
    /// A columns or row can appear only for a specific device, or screen sizes
    /// </summary>
    public enum FColumnDeviceVisibility
    {
        /// <summary>
        /// 大屏幕
        /// </summary>
        [EnumClass("large screen")]
        LargeScreen,
        /// <summary>
        /// 计算机
        /// </summary>
        [EnumClass("computer")]
        Computer,
        /// <summary>
        /// 平板
        /// </summary>
        [EnumClass("tablet")]
        Tablet,
        /// <summary>
        /// 移动设备
        /// </summary>
        [EnumClass("mobile")]
        Mobile,
    }
}
