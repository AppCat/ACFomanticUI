using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 选择框
    /// </summary>
    public partial class FCheckbox : ACInuptComponentBase<bool?>
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "checkbox";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("read-only", () => ReadOnly)
                .If("checked", () => Checked != null && (bool)Checked)
                .If("indeterminate", () => Checked == null)
                .If("disabled", () => Disabled)
                .GetIf(() => CheckboxType.ToClass(), () => CheckboxType != null)
                .Add(_suffix)
                ;
        }

        #region Parameter

        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// 选中
        /// </summary>
        [Parameter]
        public bool? Checked { get; set; }

        /// <summary>
        /// 点击框类型
        /// </summary>
        [Parameter]
        public EnumMix<FCheckboxType> CheckboxType { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 获取或设置一个更新绑定选中的回调函数, 配合 @bin 使用
        /// </summary>
        [Parameter]
        public EventCallback<bool?> CheckedChanged { get; set; }

        /// <summary>
        /// 选中变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool?> OnCheckedChange { get; set; }

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <returns></returns>
        private async Task HandleClick()
        {
            //Checked = Checked == null ? true : !Checked;
            await SetChecked(Checked == null ? true : !Checked);
        }

        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        public override void Reset()
        {
            Checked = FirstValue;
            SetChecked(Checked).ConfigureAwait(false);
            base.Reset();
        }

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FirstValue = Checked;
        }

        /// <summary>
        /// 设置 Checked
        /// </summary>
        /// <param name="checked"></param>
        /// <returns></returns>
        protected virtual async Task SetChecked(bool? @checked)
        {
            Checked = @checked;
            await CheckedChanged.InvokeAsync(Checked);
            await OnCheckedChange.InvokeAsync(Checked);
            Value = Checked;
        }
    }
}
