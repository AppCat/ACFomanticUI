using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 项目列表
    /// </summary>
    public interface IFOverlayItemList<TKey> : IFItemList<IFOverlayItem<TKey>, TKey>
    {
        /// <summary>
        /// 可见度
        /// </summary>
        EnumMix<FVisibility> Visibility { get; set; }

        /// <summary>
        /// 能见度变化
        /// </summary>
        EventCallback<EnumMix<FVisibility>> VisibilityChanged { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        Task Show();

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        Task Hide();
    }
}
