using ACUI.Shared.Core.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 
    /// </summary>
    public class ACOverlayListComponentBase<TKey> : ACListComponentBase<IFOverlayItem<TKey>, TKey>, IFOverlayItemList<TKey>
    {
        /// <summary>
        /// 可见度
        /// </summary>
        [Parameter]
        public EnumMix<FVisibility> Visibility { get; set; }

        /// <summary>
        /// 能见度变化
        /// </summary>
        [Parameter]
        public EventCallback<EnumMix<FVisibility>> VisibilityChanged { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public virtual async Task Show()
        {
            if (Visibility?.Value == FVisibility.Visible)
                return;
            Visibility = FVisibility.Visible;
            await VisibilityChanged.InvokeAsync(Visibility);
            SelectClear();
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        public virtual async Task Hide()
        {
            if (Visibility?.Value == FVisibility.Hidden)
                return;
            Visibility = FVisibility.Hidden;
            await VisibilityChanged.InvokeAsync(Visibility);
            StateHasChanged();
        }
    }
}
