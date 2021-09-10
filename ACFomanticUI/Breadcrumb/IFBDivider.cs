using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 面包屑分隔符
    /// </summary>
    public interface IFBDivider : IFBChip
    {
        /// <summary>
        /// 图标
        /// </summary>
        string Icon { get; set; }
    }
}
