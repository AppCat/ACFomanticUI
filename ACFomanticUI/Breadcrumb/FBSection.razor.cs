using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 截面
    /// 用于面包屑的子标签
    /// </summary>
    public partial class FBSection : ACItemComponentBase, IFBSection, IFItem
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _fixed = "section";
        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            base.OnSetClass(classMapper);

            classMapper
                .Add(_fixed)
                //.If("disabled", () => Disabled)
                //.If("ordered", () => Ordered)
                //.If("link", () => Link)
                //.If("horizontal", () => Horizontal)
                //.If("inverted", () => Inverted)
                //.If("selection", () => Selection)
                //.If("animated", () => Animated)
                //.If("relaxed", () => Relaxed)
                //.If("divided", () => Divided)
                //.If("celled", () => Celled)
                //.If("bulleted", () => Bulleted)
                //.If("middle aligned", () => Middle)
                //.GetIf(() => Size.ToClass(), () => Size != null)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 自动
        /// </summary>
        [CascadingParameter(Name = "BreadcrumbAuto")]
        protected bool Aout { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 链接
        /// A section may be linkable or contain a link
        /// 一个节可以是可链接的，也可以包含一个链接
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 超链接
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string Content { get; set; }

        #endregion


        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Key ??= Content ?? Guid.NewGuid().ToString("N");
        }

        #endregion
    }
}
