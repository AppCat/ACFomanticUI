using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表单项
    /// </summary>
    public interface IFField
    {
        /// <summary>
        /// 状态
        /// </summary>
        EnumMix<FStates>  States { get; }
    }
}
