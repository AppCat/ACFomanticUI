using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 类型 Input
    /// </summary>
    public partial class FTypeInput : FInput<object>
    {
        /// <summary>
        /// Input 特性
        /// </summary>
        protected Dictionary<string, object> InputAttributes { get; set; }

        #region Parameter        

        /// <summary>
        /// 内容类型
        /// </summary>
        [Parameter]
        public Type ValueType { get; set; }

        #endregion

        /// <summary>
        /// 参数变化
        /// </summary>
        protected override void OnParametersSet()
        {           
            InputAttributes = GetParameters().ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(this));
            InputAttributes.Remove("OnValueChange");
            InputAttributes.Remove("ValueChanged");
            InputAttributes.Remove("Attributes");
            InputAttributes.Remove("InputType");
            InputAttributes.Remove("Min");
            InputAttributes.Remove("Max");
            InputAttributes.Remove("Value");
            InputAttributes.Remove("ValueType");
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value"></param>
        public void SetValue<TValue>(TValue value)
        {
            Value = value;
        }
    }
}
