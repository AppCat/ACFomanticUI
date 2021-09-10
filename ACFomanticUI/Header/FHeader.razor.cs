using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 标题
    /// </summary>
    public partial class FHeader : ACSonContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "header";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(_prefix, () => !AsSon || !Subheader)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .GetIf(() => Floating.ToClass(), () => Floating != null)
                .GetIf(() => Attached.ToClass(), () => Attached != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .If("icon", () => Icon)
                .If("sub", () => Sub || Subheader)
                .If("disabled", () => Disabled)
                .If("dividing", () => Dividing)
                .If("block", () => Block)
                .If("inverted", () => Inverted)
                //.If("sub", () => AsSon)
                .Add(_suffix)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 使用图标
        /// 标题可以包含一个图标
        /// A header may contain an icon
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }

        /// <summary>
        /// 副标题
        /// 标题可以被格式化为标记较小或不强调的内容。
        /// Headers may be formatted to label smaller or de-emphasized content.
        /// </summary>
        [Parameter]
        public bool Sub { get; set; }

        /// <summary>
        /// 子标题
        /// 标题可以包含子标题
        /// Headers may contain subheaders
        /// </summary>
        [Parameter]
        public bool Subheader { get; set; }

        /// <summary>
        /// 分割
        /// 可以对标题进行格式化，将其自身与下面的内容分开
        /// A header can be formatted to divide itself from the content below it
        /// </summary>
        [Parameter]
        public bool Dividing { get; set; }

        /// <summary>
        /// 块
        /// 可以格式化标头以显示在内容块中
        /// A header can be formatted to appear inside a content block
        /// </summary>
        [Parameter]
        public bool Block { get; set; }

        /// <summary>
        /// 颠倒
        /// 标题可以将其颜色倒置以形成对比
        /// 倒立标题使用修改过的浅色版本的网站配色方案，以便在深色背景上有更强的对比度
        /// A header can have its colors inverted for contrast
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// H类型 标题
        /// </summary>
        [Parameter]
        public EnumMix<FHeaderHtmlType> HtmlType { get; set; } = FHeaderHtmlType.Div;

        /// <summary>
        /// 依附
        /// 标题可以附加到其他内容，如段
        /// A header can be attached to other content, like a segment
        /// </summary>
        [Parameter]
        public EnumMix<FAttached>  Attached { get; set; }

        /// <summary>
        /// 浮动
        /// 标题可以位于其他内容的左边或右边
        /// A header can sit to the left or right of other content
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floating { get; set; }

        /// <summary>
        /// 颜色
        /// A button can have different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 对齐
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment>  TextAlignment { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
