using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 肖像/Image
    /// 图像是对某物的图形表示
    /// An image is a graphic representation of something
    /// </summary>
    public partial class FImage : ACComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "image";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(nameof(Hidden).ToLowerInvariant(), () => Hidden)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .Add(_prefix)
                .If(nameof(Avatar).ToLowerInvariant(), () => Avatar)
                .If(nameof(Centered).ToLowerInvariant(), () => Centered)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Rounded).ToLowerInvariant(), () => Rounded)
                .If(nameof(Circular).ToLowerInvariant(), () => Circular)
                .If(nameof(Spaced).ToLowerInvariant(), () => Spaced)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .GetIf(() => VerticallyAligned.ToClass(), () => VerticallyAligned != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 链接
        /// 可以对图像进行格式化以链接到其他内容
        /// An image can be formatted to link to other content
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 超文本链接
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// 只有 Img
        /// </summary>
        [Parameter]
        public bool Img { get; set; } = true;

        /// <summary>
        /// 路径
        /// </summary>
        [Parameter]
        public string Src { get; set; }

        /// <summary>
        /// 隐藏
        /// 图像可以被隐藏。
        /// An image can be hidden
        /// </summary>
        [Parameter]
        public bool Hidden { get; set; }

        /// <summary>
        /// 具体化
        /// 可以将图像格式化为与文本一起作为头像显示。
        /// An image may be formatted to appear inline with text as an avatar
        /// </summary>
        [Parameter]
        public bool Avatar { get; set; }

        /// <summary>
        /// 有边的
        /// 图像可以包含边框，以强调白色或透明内容的边缘。
        /// An image may include a border to emphasize the edges of white or transparent content
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <summary>
        /// 流体
        /// 图像会占用容器的宽度
        /// An image can take up the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 圆角
        /// 图像可能是圆角的
        /// An image may appear rounded
        /// </summary>
        [Parameter]
        public bool Rounded { get; set; }

        /// <summary>
        /// 圆形
        /// 图像可能是圆形的
        /// An image may appear circular
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 居中
        /// 图像可以居中出现在内容块中
        /// An image can appear centered in a content block
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }

        /// <summary>
        /// 隔开
        /// 图像可以指定需要额外的间距来将其与附近的内容隔开
        /// An image can specify that it needs an additional spacing to separate it from nearby content
        /// </summary>
        [Parameter]
        public bool Spaced { get; set; }

        /// <summary>
        /// 浮动
        /// 图像可以位于其他内容的左边或右边
        /// An image can sit to the left or right of other content
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floated { get; set; }

        /// <summary>
        /// 垂直对齐方式
        /// 图像可以指定其垂直对齐方式
        /// An image can specify its vertical alignment
        /// </summary>
        [Parameter]
        public EnumMix<FVerticallyAligned>  VerticallyAligned { get; set; }


        /// <summary>
        /// 尺寸
        /// 一个图像可能以不同的尺寸出现
        /// An image may appear at different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
