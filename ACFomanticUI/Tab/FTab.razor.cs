using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 标签页
    /// </summary>
    public partial class FTab : ACContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "ui menu";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("tabular", () => !Pointing)
                .If(TabAttached.ToClass(), () => !(Pointing || Secondary) && TabAttached != null && (TabAttached.Value == FAttached.Bottom || TabAttached.Value == FAttached.Top))
                .If("fluid vertical", () => TabAttached != null && (TabAttached.Value == FAttached.Left || TabAttached.Value == FAttached.Right))
                .If("right", () => TabAttached != null && TabAttached.Value == FAttached.Right)
                .GetIf(() => $"{((FNumber)TabItems.Count).ToClass()} item", () => Fluid && TabAttached != null && (TabAttached.Value == FAttached.Bottom || TabAttached.Value == FAttached.Top))
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Secondary).ToLowerInvariant(), () => Secondary)
                .If(nameof(Pointing).ToLowerInvariant(), () => Secondary && !Pointing)
                .If(nameof(Pointing).ToLowerInvariant(), () => Pointing)
                ;
        }

        /// <summary>
        /// 标签页
        /// </summary>
        internal IList<FTabItem> TabItems { get; set; } = new List<FTabItem>();

        /// <summary>
        /// 状态变化
        /// </summary>
        internal async Task ActiveTap(FTabItem item)
        {
            var key = item.Key;
            if (ActiveKey == key || Disabled)
                return;
            ActiveKey = key;
            StateHasChanged();
            if (ActiveKeyChanged.HasDelegate)
            {
                await ActiveKeyChanged.InvokeAsync(ActiveKey);
            }
            if (OnActiveKeyChange.HasDelegate)
            {
                await OnActiveKeyChange.InvokeAsync(ActiveKey);
            }
        }

        #region Parameter        

        /// <summary>
        /// 加载
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 选中的标签页键
        /// </summary>
        [Parameter]
        public string ActiveKey { get; set; }

        /// <summary>
        /// 可以取其容器的宽度
        /// A button can take the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 指向
        /// </summary>
        [Parameter]
        public bool Pointing { get; set; }

        /// <summary>
        /// 第二指向
        /// </summary>
        [Parameter]
        public bool Secondary { get; set; }

        /// <summary>
        /// 内容依附位置
        /// </summary>
        [Parameter]
        public EnumMix<FAttached> TabAttached { get; set; } = FAttached.Top;

        /// <summary>
        /// 右边内容
        /// </summary>
        [Parameter]
        public RenderFragment RightMenuContent { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<string> ActiveKeyChanged { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<string> OnActiveKeyChange { get; set; }

        #endregion
    }
}
