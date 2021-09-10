﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 可选地支持的任何输入控件的基类
    /// </summary>
    public abstract class ACInuptComponentBase<TValue> : ACContentComponentBase<TValue>,
        IControlValueAccessor
    {
        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        internal FieldIdentifier FieldIdentifier { get; set; }

        #region CascadingParameter

        /// <summary>
        /// 表单项组
        /// </summary>
        [CascadingParameter]
        protected IFFieldGroup FieldGroup { get; set; }

        /// <summary>
        /// 表单项
        /// </summary>
        [CascadingParameter]
        protected IFField Field { get; set; }

        /// <summary>
        /// 编辑上下文
        /// </summary>
        [CascadingParameter]
        protected EditContext EditContext { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [CascadingParameter(Name = "FieldName")]
        protected string FieldName { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 获取或设置值 used with two-way binding.
        /// </summary>
        /// <example>
        /// @bind-Value="model.PropertyName"
        /// </example>
        [Parameter]
        public virtual TValue Value
        {
            get => _value;
            set
            {
                var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    _value = value;
                    if (ValueChanged.HasDelegate)
                        ValueChanged.InvokeAsync(Value).Wait();
                    if (FieldIdentifier.FieldName != null && FieldIdentifier.Model != null)
                        EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
            }
        }
        private TValue _value;
        private TValue _firstValue;

        /// <summary>
        /// Gets or sets a callback that updates the bound value.
        /// </summary>
        [Parameter]
        public virtual EventCallback<TValue> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TValue>> ValueExpression { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        void IControlValueAccessor.Reset()
        {
            Value = _firstValue;
            ValueChanged.InvokeAsync(Value).Wait();
            StateHasChanged();
        }

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _firstValue = Value;
            FieldGroup?.AddControl(this);
            if (EditContext != null)
            {
                if (ValueExpression != null)
                    FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                else if (!string.IsNullOrEmpty(FieldName))
                {
                    FieldIdentifier = EditContext.Field(FieldName);
                }
            }
        }
    }
}
