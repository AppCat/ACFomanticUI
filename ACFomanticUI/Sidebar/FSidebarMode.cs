using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏模式
    /// </summary>
    public enum FSidebarMode
    {
        Overlay,
        Push,
        [EnumClass("scale down")]
        ScaleDown,
        Uncover,
        [EnumClass("slide along")]
        SlideAlong,
        [EnumClass("slide out")]
        SlideOut
    }
}
