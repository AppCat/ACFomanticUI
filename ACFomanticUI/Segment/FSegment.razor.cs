using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 分段
    /// </summary>
    public partial class FSegment : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "segment";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Raised).ToLowerInvariant(), () => Raised)
                .If(nameof(Stacked).ToLowerInvariant(), () => Stacked)
                .If(nameof(Piled).ToLowerInvariant(), () => Piled)
                .If(nameof(Placeholder).ToLowerInvariant(), () => Placeholder)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Padded).ToLowerInvariant(), () => Padded)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .If(nameof(Circular).ToLowerInvariant(), () => Circular)
                .If(nameof(Clearing).ToLowerInvariant(), () => Clearing)
                .If(nameof(Basic).ToLowerInvariant(), () => Basic)
                .If(nameof(Loading).ToLowerInvariant(), () => Loading)

                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Direction.ToClass(), () => Direction != null)
                .GetIf(() => Attached.ToClass(), () => Attached != null)
                .GetIf(() => Variations.ToClass(), () => Variations != null)
                .GetIf(() => EmphasisRank.ToClass(), () => EmphasisRank != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .Add(_suffix)
                ;
        }

        #region Parameter 

        /// <summary>
        /// 加载 
        /// 一个段可以显示它的内容正在被加载
        /// A segment may show its content is being loaded
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 占位符
        /// A segment can be used to reserve space for conditionally displayed content.
        /// </summary>
        [Parameter]
        public bool Placeholder { get; set; }

        /// <summary>
        /// 凸起
        /// 段落可以格式化成凸出显示在页面上
        /// A segment may be formatted to raise above the page.
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }

        /// <summary>
        /// 二叠分
        /// 片段能够显示它所包含的多个页面
        /// A segment can be formatted to show it contains multiple pages
        /// </summary>
        [Parameter]
        public bool Stacked { get; set; }

        /// <summary>
        /// 堆
        /// 段落可以被格式化成一堆页面一样
        /// A segment can be formatted to show it contains multiple pages
        /// </summary>
        [Parameter]
        public bool Piled { get; set; }

        /// <summary>
        /// 颜色翻转
        /// 为了对比，段可以将其颜色颠倒
        /// A segment can have its colors inverted for contrast
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 填装
        /// 一个段可以增加它的填充
        /// A segment can increase its padding
        /// </summary>
        [Parameter]
        public bool Padded { get; set; }

        /// <summary>
        /// 袖珍
        /// 一个段可以只占用必要的空间
        /// A segment may take up only as much space as is necessary
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 圆
        /// 线段可以是圆形的
        /// A segment can be circular
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 清除
        /// 段可以清除浮动内容
        /// A segment can clear floated content
        /// </summary>
        [Parameter]
        public bool Clearing { get; set; }

        /// <summary>
        /// 基本
        /// 基本段没有特殊格式
        /// A basic segment has no special formatting
        /// </summary>
        [Parameter]
        public bool Basic { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [Parameter]
        public EnumMix<FDirection>  Direction { get; set; }

        /// <summary>
        /// 颜色
        /// A button can have different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 曲变
        /// </summary>
        [Parameter]
        public EnumMix<FVariations>  Variations { get; set; }

        /// <summary>
        /// 附属
        /// </summary>
        [Parameter]
        public EnumMix<FAttached>  Attached { get; set; }

        /// <summary>
        /// 重点
        /// </summary>
        [Parameter]
        public EnumMix<FEmphasisRank>  EmphasisRank { get; set; }

        /// <summary>
        /// 浮动的
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floated { get; set; }

        /// <summary>
        /// 文字对齐
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment>  TextAlignment { get; set; }

        #endregion

    }
}
