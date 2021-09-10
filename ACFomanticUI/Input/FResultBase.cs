using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 结果基础
    /// </summary>
    public abstract class FResultBase : ACComponentBase, IFResult
    {
        /// <summary>
        /// 选中
        /// </summary>
        protected bool Selected => ResultContainer?.ResultIsSelected(this) ?? false;

        #region CascadingParameter

        /// <summary>
        /// 结果容器
        /// </summary>
        [CascadingParameter]
        protected IFResultContainer ResultContainer { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public string Key { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        [Parameter]
        public RenderFragment TitleTemplate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Parameter]
        public string Description { get; set; }

        /// <summary>
        /// 价值
        /// </summary>
        [Parameter]
        public string Price { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Parameter]
        public string Url { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        [Parameter]
        public object Tag { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ResultContainer?.AddResult(this);
        }

        #endregion

        /// <summary>
        /// 通知状态更新
        /// </summary>
        public void NotifyStateHasChanged() => InvokeStateHasChanged();
    }
}
