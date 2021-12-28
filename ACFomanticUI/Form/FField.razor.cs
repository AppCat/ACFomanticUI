using Microsoft.AspNetCore.Components;
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
    public partial class FField : ACContentComponentBase, IFField
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "field";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Inline).ToLowerInvariant(), () => Inline)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Required).ToLowerInvariant(), () => Required)
                .If(nameof(Error).ToLowerInvariant(), () => Error)
                .GetIf(() => $"{Width.ToClass()} wide", () => Width != null)
                .GetIf(() => States.ToClass(), () => States != null)
                ;

            LabelStyleMapper.Clear()
            .Get(() => LabelConfig?.AsStyle)
            ;

            LabelClassMapper.Clear()
            .Get(() => LabelConfig?.AsClass)
            ;
        }

        /// <summary>
        /// 标签样式
        /// </summary>
        protected Mapper LabelStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 标签类
        /// </summary>
        protected Mapper LabelClassMapper { get; set; } = new Mapper();

        #region CascadingParameter

        /// <summary>
        /// 表单项组
        /// </summary>
        [CascadingParameter]
        protected IFFieldGroup FieldGroup { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// 内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig LabelConfig { get; set; }

        /// <summary>
        /// 内联
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 必需的
        /// </summary>
        [Parameter]
        public bool Required { get; set; }

        /// <summary>
        /// 错误的
        /// </summary>
        [Parameter]
        public bool Error { get; set; }

        /// <summary>
        /// 宽度
        /// 字段可以在网格列中指定其宽度
        /// A field can specify its width in grid columns
        /// </summary>
        [Parameter]
        public EnumMix<FNumber>  Width { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Parameter]
        public EnumMix<FStates>  States { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FieldGroup?.AddFormItem(this);
        }

        #endregion
    }
}
