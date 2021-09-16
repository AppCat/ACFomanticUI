using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表单项组
    /// 一组字段可以组合在一起显示
    /// A set of fields can appear grouped together
    /// Field groups automatically receive responsive styling, swapping to one field per row on mobile devices.
    /// </summary>
    public partial class FFieldGroup : ACContentComponentBase, IFFieldGroup
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "fields";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Inline).ToLowerInvariant(), () => Inline)
                .If(nameof(Grouped).ToLowerInvariant(), () => Grouped)
                .If("equal width", () => Disabled)
                .GetIf(() => FieldCount.ToClass(), () => FieldCount != null)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 表单
        /// </summary>
        [CascadingParameter]
        protected IFForm Form { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 内联
        /// Multiple fields may be inline in a row
        /// 多个字段可以内联在一行中
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 内联
        /// 字段可以显示相关的选择
        /// Fields can show related choices
        /// </summary>
        [Parameter]
        public bool Grouped { get; set; }

        /// <summary>
        /// 等宽
        /// 字段可以自动将字段划分为相等的宽度
        /// Fields can automatically divide fields to be equal width
        /// </summary>
        [Parameter]
        public bool EqualWidth { get; set; }

        /// <summary>
        /// Field数量
        /// 一个表可以指定它的列数来均匀地划分它的内容
        /// A table can specify its column count to divide its content evenly
        /// </summary>
        [Parameter]
        public EnumMix<FNumber>  FieldCount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumMix<FStates>  States { get; set; }

        #endregion

        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        void IFFieldGroup.AddFormItem(IFField field)
        {
            Form?.AddFormItem(field);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="valueAccessor"></param>
        void IFFieldGroup.AddControl(IControlValueAccessor valueAccessor)
        {
            Form?.AddControl(valueAccessor);
        }
    }
}
