using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表格列
    /// </summary>
    /// <typeparam name="TField"></typeparam>
    public partial class FTColumn<TField> : FColumnBase
    {
        /// <summary>
        /// 属性反射器
        /// </summary>
        private PropertyReflector? _propertyReflector { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName => _propertyReflector?.DisplayName;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string FieldName => _propertyReflector?.PropertyName;

        #region Parameter        

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public TField Field { get; set; }

        /// <summary>
        /// 字符串格式
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// 字段表达式
        /// </summary>
        [Parameter]
        public Expression<Func<TField>> FieldExpression { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 内容变化
        /// </summary>
        [Parameter]
        public EventCallback<TField> FieldChanged { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            //FieldExpression = () => Field;
            if (FieldExpression != null && UseType == FColumUseType.Header)
            {
                _propertyReflector = PropertyReflector.Create(FieldExpression);
            }
            if (IsInitialize)
            {
                ColumnContext?.AddColumn(this);
            }
        }

        #endregion
    }
}
