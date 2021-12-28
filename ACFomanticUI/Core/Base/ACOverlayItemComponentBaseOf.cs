using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 项目基础
    /// </summary>
    public abstract class ACOverlayItemComponentBase<TKey> : ACItemComponentBase<IFOverlayItemList<TKey>, IFOverlayItem<TKey>, TKey>, IFOverlayItem<TKey>
    {
        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Value ??= Key.ToString();
        }

        #endregion

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        [Parameter]
        public RenderFragment<IFOverlayItem<TKey>> ValueTemplate { get; set; }
    }
}
