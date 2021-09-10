using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 线长
    /// 一行可以指定它的内容应该出现多长时间
    /// A line can specify how long its contents should appear
    /// </summary>
    public enum FPLineLength
    {
        /// <summary>
        /// 完全
        /// </summary>
        Full,
        /// <summary>
        /// 很长
        /// </summary>
        [EnumClass("very long")]
        VeryLong,
        /// <summary>
        /// 长
        /// </summary>
        Long,
        /// <summary>
        /// 中长
        /// </summary>
        Medium,
        /// <summary>
        /// 短
        /// </summary>
        Short,
        /// <summary>
        /// 很短
        /// </summary>
        [EnumClass("very short")]
        VeryShort
    }
}
