using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 负空间
    /// A grid can increase its gutters to allow for more negative space
    /// 网格可以增加它的排水沟，以允许更多的负空间
    /// </summary>
    public enum FGridRelaxed
    {
        /// <summary>
        /// 默认
        /// </summary>
        [EnumClass("relaxed")]
        Default,
        /// <summary>
        /// 更多
        /// </summary>
        [EnumClass("very relaxed")]
        Very
    }
}
