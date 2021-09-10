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
    /// 标签
    /// </summary>
    public partial class FLabel : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "label";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Image).ToLowerInvariant(), () => Image)
                .If(nameof(Tag).ToLowerInvariant(), () => Tag)
                .If(nameof(Horizontal).ToLowerInvariant(), () => Horizontal)
                .If(nameof(Floating).ToLowerInvariant(), () => Floating)
                .If(nameof(Circular).ToLowerInvariant(), () => Circular)
                .If(nameof(Empty).ToLowerInvariant(), () => Empty)
                .If(nameof(Basic).ToLowerInvariant(), () => Basic)
                .GetIf(() => Pointing.ToClass(), () => Pointing != null)
                .GetIf(() => Corner.ToClass(), () => Corner != null)
                .GetIf(() => $"{Attached.ToClass()} attached", () => Attached != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 图像
        /// 标签可以被格式化以强调图像
        /// A label can be formatted to emphasize an image
        /// </summary>
        [Parameter]
        public bool Image { get; set; }

        /// <summary>
        /// 标记
        /// 标签可以作为标记出现
        /// A label can appear as a tag
        /// </summary>
        [Parameter]
        public bool Tag { get; set; }

        /// <summary>
        /// 水平
        /// 水平标签被格式化为水平地标记其旁边的内容
        /// A horizontal label is formatted to label content along-side it horizontally
        /// </summary>
        [Parameter]
        public bool Horizontal { get; set; }

        /// <summary>
        /// 流动的
        /// 一个标签可以浮动在另一个元素之上
        /// A label can float above another element.
        /// </summary>
        [Parameter]
        public bool Floating { get; set; }

        /// <summary>
        /// 连接
        /// 标签可以是链接，也可以包含链接的项
        /// A label can be a link or contain an item that links
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 圆的
        /// 标签可以是圆的
        /// A label can be circular
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 空的
        /// 标签可以是空的
        /// </summary>
        [Parameter]
        public bool Empty { get; set; }

        /// <summary>
        /// 基本
        /// 标签可以降低它的复杂性
        /// A label can reduce its complexity
        /// </summary>
        [Parameter]
        public bool Basic { get; set; }

        /// <summary>
        /// 角落
        /// 标签可以将自己放置在元素的角落里
        /// A label can position itself in the corner of an element
        /// </summary>
        [Parameter]
        public EnumMix<FCorner>  Corner { get; set; }

        /// <summary>
        /// 直指
        /// 标签可以指向它旁边的内容
        /// A label can point to content next to it
        /// </summary>
        [Parameter]
        public EnumMix<FPointing>  Pointing { get; set; }

        /// <summary>
        /// 依附
        /// 标签可以附加到内容段
        /// A label can attach to a content segment
        /// </summary>
        [Parameter]
        public EnumMix<FAttached>  Attached { get; set; }

        /// <summary>
        /// 颜色
        /// 标签可以有不同的颜色
        /// A label can have different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 尺寸
        /// 标签可以是大或小
        /// A label can be small or large
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #endregion
    }
}
