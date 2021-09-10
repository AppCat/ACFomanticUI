using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 轨道可以出现在主视口附近
    /// A rail can appear closer to the main viewport
    /// </summary>
    public enum FRailClose
    {
        /// <summary>
        /// 
        /// </summary>
        Close,
        /// <summary>
        /// 
        /// </summary>
        [EnumClass("very close")]
        VeryClose
    }
}
