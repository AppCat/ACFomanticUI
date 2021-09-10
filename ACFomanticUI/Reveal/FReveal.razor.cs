using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 显示
    /// 当激活时，显示器会显示额外的内容来代替先前的内容
    /// A reveal displays additional content in place of previous content when activated
    /// </summary>
    public partial class FReveal : ACComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "reveal";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Fade).ToLowerInvariant(), () => Fade)
                .If(nameof(Image).ToLowerInvariant(), () => Image)
                .If(nameof(Active).ToLowerInvariant(), () => Active)
                .If(nameof(Instant).ToLowerInvariant(), () => Instant)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Move.ToClass(), () => Move != null)
                .GetIf(() => $"circular {Rotate.ToClass()}", () => Rotate != null)
                //.If("disabled", () => Disabled)
                .Add(_suffix)
                ;

            HiddenContentStyleMapper.Clear()
            .Get(() => HiddenConfig?.Style)
            ;

            HiddenContentClassMapper.Clear()
            .Add("hidden content")
            .Get(() => HiddenConfig?.Class)
            ;

            VisibleContentStyleMapper.Clear()
            .Get(() => VisibleConfig?.Style)
            ;

            VisibleContentClassMapper.Clear()
            .Add("visible content")
            .Get(() => VisibleConfig?.Class)
            ;
        }

        /// <summary>
        /// 隐藏部分样式 映射
        /// </summary>
        protected Mapper HiddenContentStyleMapper { get; set; }

        /// <summary>
        /// 隐藏部分类 映射
        /// </summary>
        protected Mapper HiddenContentClassMapper { get; set; }

        /// <summary>
        /// 显示部分样式 映射
        /// </summary>
        protected Mapper VisibleContentStyleMapper { get; set; }

        /// <summary>
        /// 显示部分类 映射
        /// </summary>
        protected Mapper VisibleContentClassMapper { get; set; }

        #region Parameter  

        /// <summary>
        /// 隐藏内容
        /// </summary>
        [Parameter]
        public RenderFragment HiddenContent { get; set; }

        /// <summary>
        /// 隐藏内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig HiddenConfig { get; set; }

        /// <summary>
        /// 显示内容
        /// </summary>
        [Parameter]
        public RenderFragment VisibleContent { get; set; }

        /// <summary>
        /// 显示内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig VisibleConfig { get; set; }

        /// <summary>
        /// 褪色
        /// 元素可以消失以显示下面的内容
        /// An element can disappear to reveal content below
        /// </summary>
        [Parameter]
        public bool Fade { get; set; }

        /// <summary>
        /// 用作图像
        /// </summary>
        [Parameter]
        public bool Image { get; set; }

        /// <summary>
        /// 活跃
        /// 一个活动的显示显示它隐藏的内容
        /// An active reveal displays its hidden content
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        /// <summary>
        /// 立即的
        /// 元素可以毫不延迟地显示其内容
        /// An element can show its content without delay
        /// </summary>
        [Parameter]
        public bool Instant { get; set; }

        /// <summary>
        /// 旋转
        /// 元素可以旋转以显示下面的内容
        /// An element can rotate to reveal content below
        /// </summary>
        [Parameter]
        public EnumMix<FRevealRotate> Rotate { get; set; }      

        /// <summary>
        /// 模式
        /// 元素可以向某个方向移动以显示内容
        /// An element can move in a direction to reveal content
        /// </summary>
        [Parameter]
        public EnumMix<FRevealMove> Move { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 切换隐藏时触发
        /// </summary>
        public EventCallback OnSwitchHiddenContent { get; set; }

        /// <summary>
        /// 切换显示时触发
        /// </summary>
        public EventCallback OnSwitchVisibleContent { get; set; }

        #endregion
    }
}
