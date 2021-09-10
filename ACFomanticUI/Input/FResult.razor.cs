using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 结果 可 用于多个组件
    /// </summary>
    public partial class FResult : FResultBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "result";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                ;
        }

        #region Parameter

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool OnClickStopPropagation { get; set; } = true;

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task HandleClickAsync(MouseEventArgs args)
        {
            await ResultContainer?.SelectedResultAsync(this, true);
            await OnClick.InvokeAsync(args);
        }

        #endregion

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="key"></param>
        /// <param name="title"></param>
        /// <param name="titleTemplate"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="url"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static IFResult Create(string key, string title, RenderFragment titleTemplate = null, string description = null, string price = null, string url = null, object tag = null)
        {
            return new FResult
            {
                Key = key,
                Title = title,
                TitleTemplate = titleTemplate,
                Description = description,
                Price = price,
                Url = url,
                Tag = tag
            };
        }
    }
}
