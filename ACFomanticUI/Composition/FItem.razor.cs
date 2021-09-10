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
    /// 项目
    /// 项视图表示要显示的大量站点内容集合
    /// An item view presents large collections of site content for display
    /// </summary>
    public partial class FItem : ACSonContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "item";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("disabled", () => Disabled)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 显示结果
        /// </summary>
        [CascadingParameter(Name = "ParentType")]
        internal FItemParentType ParentType { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 超链接
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

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
        private async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await OnClick.InvokeAsync(args);         
        }

        #endregion
    }
}
