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
    /// 按钮
    /// 按钮表示可能的用户操作
    /// A button indicates a possible user action
    /// </summary>
    public partial class FButton : ACContentComponentBase
    {

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "button";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Animated.ToClass(), () => Animated != null)
                .GetIf(() => Emphasis.ToClass(), () => Emphasis != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .GetIf(() => Attached.ToClass(), () => Attached != null)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Icon).ToLowerInvariant(), () => Icon)
                .If(nameof(Labeled).ToLowerInvariant(), () => Labeled)
                .If(nameof(Loading).ToLowerInvariant(), () => Loading)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .If(nameof(Circular).ToLowerInvariant(), () => Circular)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Basic).ToLowerInvariant(), () => Basic)
                .Add(_suffix)
                ;

            HiddenStyleMapper.Clear()
            .Get(() => HiddenConfig?.Style)
            ;

            HiddenClassMapper.Clear()
            .Add("hidden content")
            .Get(() => HiddenConfig?.Class)
            ;

            VisibleStyleMapper.Clear()
            .Get(() => VisibleConfig?.Style)
            ;

            VisibleClassMapper.Clear()
            .Add("visible content")
            .Get(() => VisibleConfig?.Class)
            ;
        }

        /// <summary>
        /// 隐藏部分样式 映射
        /// </summary>
        protected Mapper HiddenStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 隐藏部分类 映射
        /// </summary>
        protected Mapper HiddenClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 显示部分样式 映射
        /// </summary>
        protected Mapper VisibleStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 显示部分类 映射
        /// </summary>
        protected Mapper VisibleClassMapper { get; set; } = new Mapper();

        #region CascadingParameter

        ///// <summary>
        ///// 表单
        ///// </summary>
        //[CascadingParameter]
        //protected ISForm _form { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// Html 类型
        /// </summary>
        [Parameter]
        public string HtmlType { get; set; } = "button";

        /// <summary>
        /// 隐藏内容
        /// </summary>
        [Parameter]
        public RenderFragment HiddenContent { get; set; }

        /// <summary>
        /// 显示内容配置
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
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool OnClickStopPropagation { get; set; } = true;

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 翻转
        /// 一个按钮可以格式化显示在黑暗的背景
        /// A button can be formatted to appear on dark backgrounds
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 基础
        /// 按钮组可以不那么明显
        /// A button group can be less pronounced
        /// </summary>
        [Parameter]
        public bool Basic { get; set; }

        /// <summary>
        /// 使用图标
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }

        /// <summary>
        /// 标签
        /// 一个按钮可以出现在标签旁边
        /// A button can appear alongside a label
        /// </summary>
        [Parameter]
        public bool Labeled { get; set; }

        /// <summary>
        /// 按钮可以取其容器的宽度
        /// A button can take the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 加载
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 袖珍
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 圆形
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 尺寸
        /// 一个按钮可以有不同的大小
        /// A button can have different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        /// <summary>
        /// 颜色
        /// 按钮可以有不同的颜色
        /// A button can have different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 动画
        /// 一个按钮可以动画显示隐藏的内容
        /// A button can animate to show hidden content
        /// </summary>
        [Parameter]
        public EnumMix<FButtonAnimated> Animated { get; set; }

        /// <summary>
        /// 重点
        /// 一个按钮可以被格式化以显示不同程度的强调
        /// A button can be formatted to show different levels of emphasis
        /// </summary>
        [Parameter]
        public EnumMix<FEmphasisRank>  Emphasis { get; set; }

        /// <summary>
        /// 浮动
        /// 按钮可以在其容器的左边或右边对齐
        /// A button can be aligned to the left or right of its container
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floated { get; set; }

        /// <summary>
        /// 依附
        /// 按钮可以附加到其他内容的顶部或底部
        /// A button can be attached to the top or bottom of other content
        /// </summary>
        [Parameter]
        public EnumMix<FAttached>  Attached { get; set; }

        /// <summary>
        /// 表单行为
        /// </summary>
        [Parameter]
        public EnumMix<FFormAction>  FormAction { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 加载事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await Click(args);
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <returns></returns>
        protected async Task Click(MouseEventArgs args)
        {
            if (Loading)
                return;
            Loading = true;
            await LoadingChanged.InvokeAsync(Loading);
            await OnClick.InvokeAsync(args);
            //if (FormAction != null && _form != null)
            //{
            //    switch ((SFormAction)FormAction)
            //    {
            //        case SFormAction.Submit:
            //            _form.Submit();
            //            break;
            //        case SFormAction.Validate:
            //            _form.Validate();
            //            break;
            //        case SFormAction.Reset:
            //            _form.Reset();
            //            break;
            //    }
            //}
            Loading = false;
            await LoadingChanged.InvokeAsync(Loading);
        }

        /// <summary>
        /// 切换隐藏时触发
        /// </summary>
        public EventCallback OnSwitchHiddenContent { get; set; }

        /// <summary>
        /// 切换显示时触发
        /// </summary>
        public EventCallback OnSwitchVisibleContent { get; set; }

        #endregion

        #region SDLC


        #endregion
    }
}
