using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 菜单
    /// 菜单显示分组导航操作
    /// A menu displays grouped navigation actions
    /// </summary>
    public partial class FMenu : ACListOverlayComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "menu";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(_prefix, () => Parent == null)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Secondary).ToLowerInvariant(), () => Secondary)
                .If(nameof(Pointing).ToLowerInvariant(), () => Pointing)
                .If(nameof(Tabular).ToLowerInvariant(), () => Tabular)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Text).ToLowerInvariant(), () => Text)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .If(nameof(Borderless).ToLowerInvariant(), () => Borderless)
                .If(nameof(Stackable).ToLowerInvariant(), () => Stackable)
                .If(nameof(Icon).ToLowerInvariant(), () => Icon)
                .If(nameof(Vertical).ToLowerInvariant(), () => Vertical)
                .If(nameof(Right).ToLowerInvariant(), () => Right)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Pagination).ToLowerInvariant(), () => Pagination)
                .GetIf(() => Attached.ToClass(), () => Attached != null && Tabular)
                .GetIf(() => Direction.ToClass(), () => Direction != null && Fluid)
                .GetIf(() => $"{ItemCount.ToClass()} item", () => ItemCount != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                //.GetIf(() => Variations.ToClass(), () => Variations != null)
                .GetIf(() => Fixed.ToClass(), () => Fixed != null)
                .GetIf(() => $"transition {Visibility.ToClass()}", () => Visibility != null && Visibility?.Value == FVisibility.Hidden)
                .Add(_suffix)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 父类
        /// </summary>
        [CascadingParameter]
        protected FMenu Parent { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 右边
        /// </summary>
        [Parameter]
        public bool Right { get; set; }

        /// <summary>
        /// 页码
        /// 分页菜单是经过特殊格式化的，用来显示到内容页的链接
        /// A pagination menu is specially formatted to present links to pages of content
        /// </summary>
        [Parameter]
        public bool Pagination { get; set; }

        /// <summary>
        /// 颜色翻转
        /// 菜单的颜色可以倒置以显示更大的对比
        /// A menu may have its colors inverted to show greater contrast
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 流体
        /// 垂直菜单的大小可能与其容器的大小相同。(水平菜单默认会这样做)
        /// A vertical menu may take the size of its container. (A horizontal menu does this by default)
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 次要的 
        /// A menu can adjust its appearance to de-emphasize its contents
        /// </summary>
        [Parameter]
        public bool Secondary { get; set; }

        /// <summary>
        /// 直指
        /// A menu can point to show its relationship to nearby content
        /// </summary>
        [Parameter]
        public bool Pointing { get; set; }

        /// <summary>
        /// 表格式的
        /// A menu can be formatted to show tabs of information
        /// </summary>
        [Parameter]
        public bool Tabular { get; set; }

        /// <summary>
        /// 文本
        /// A menu can be formatted for text content
        /// </summary>
        [Parameter]
        public bool Text { get; set; }

        /// <summary>
        /// 垂直的
        /// 垂直菜单垂直地显示元素
        /// A vertical menu displays elements vertically
        /// </summary>
        [Parameter]
        public bool Vertical { get; set; }

        /// <summary>
        /// 堆叠
        /// 菜单可以在移动分辨率上堆叠
        /// A menu can stack at mobile resolutions
        /// </summary>
        [Parameter]
        public bool Stackable { get; set; }

        /// <summary>
        /// 紧凑
        /// 一个菜单可以只占用必要的空间来适应它的内容
        /// A menu can take up only the space necessary to fit its content
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 无边界
        /// 菜单项或菜单可以没有边框
        /// A menu item or menu can have no borders
        /// </summary>
        [Parameter]
        public bool Borderless { get; set; }

        /// <summary>
        /// 图标
        /// 菜单可能只有图标
        /// A menu may have just icons
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }

        /// <summary>
        /// 依附
        /// 按钮可以附加到其他内容的顶部或底部
        /// A button can be attached to the top or bottom of other content
        /// </summary>
        [Parameter]
        public EnumMix<FAttached> Attached { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [Parameter]
        public EnumMix<FDirection> Direction { get; set; }

        /// <summary>
        /// 项目数量
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> ItemCount { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 固定
        /// A menu can be fixed to a side of its context
        /// 菜单可以固定在其上下文的一侧
        /// </summary>
        [Parameter]
        public EnumMix<FFixed> Fixed { get; set; }

        ///// <summary>
        ///// 变曲
        ///// </summary>
        //[Parameter]
        //public EnumMix<FVariations> Variations { get; set; }

        /// <summary>
        /// 颜色
        /// 可以指定其他颜色。
        /// Additional colors can be specified.
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 浮动
        /// </summary>
        [Parameter]
        public EnumMix<FFloated> Floated { get; set; }

        #endregion

        #region Event



        #endregion

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            Visibility = FVisibility.Visible;
            base.OnInitialized();
        }

        #endregion

        /// <summary>
        /// 选择选项异步
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public override Task SelectedItemAsync(IFOverlayItem item, bool isClick = false)
        {
            var key = item?.Key ?? string.Empty;
            if (SelectedKeys?.Contains(key) ?? false && SelectedKeys.Length <= 1)
            {
                return Task.CompletedTask;
            }
            return base.SelectedItemAsync(item, isClick);
        }
    }
}
