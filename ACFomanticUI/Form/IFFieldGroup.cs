using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表单项目组
    /// </summary>
    public interface IFFieldGroup
    {
        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        internal void AddFormItem(IFField field);

        /// <summary>
        /// 添加控制组件
        /// </summary>
        /// <param name="valueAccessor"></param>
        internal void AddControl(IControlValueAccessor valueAccessor);
    }
}
