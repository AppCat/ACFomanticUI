using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 列表
    /// 列表用于对相关内容进行分组
    /// A list is used to group related content
    /// </summary>
    public partial class FList : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "list";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(_prefix, () => !IsSonList)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Ordered).ToLowerInvariant(), () => Ordered)
                .If(nameof(Link).ToLowerInvariant(), () => Link)
                .If(nameof(Horizontal).ToLowerInvariant(), () => Horizontal)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Selection).ToLowerInvariant(), () => Selection)
                .If(nameof(Animated).ToLowerInvariant(), () => Animated)
                .If(nameof(Relaxed).ToLowerInvariant(), () => Relaxed)
                .If(nameof(Divided).ToLowerInvariant(), () => Divided)
                .If(nameof(Celled).ToLowerInvariant(), () => Celled)
                .If(nameof(Bulleted).ToLowerInvariant(), () => Bulleted)
                .If("middle aligned", () => Middle)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 是否为子列表
        /// </summary>
        [CascadingParameter(Name = "IsSonList")]
        protected bool IsSonList { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 加点符
        /// 列表可以用项目符号标记项目
        /// A list can mark items with a bullet
        /// </summary>
        [Parameter]
        public bool Bulleted { get; set; }

        /// <summary>
        /// 有序的
        /// 列表可以按数字排序
        /// A list can be ordered numerically
        /// </summary>
        [Parameter]
        public bool Ordered { get; set; }

        /// <summary>
        /// 链接
        /// 列表可以为导航链接专门设置格式
        /// A list can be specially formatted for navigation links
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 水平
        /// 可以将列表格式化为水平显示项
        /// A list can be formatted to have items appear horizontally
        /// </summary>
        [Parameter]
        public bool Horizontal { get; set; }

        /// <summary>
        /// 颠倒
        /// 列表可以倒过来显示在一个黑色的背景上
        /// A list can be inverted to appear on a dark background
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 选择
        /// 选择列表将列表项格式化为可能的选项
        /// A selection list formats list items as possible choices
        /// </summary>
        [Parameter]
        public bool Selection { get; set; }

        /// <summary>
        /// 活生生的
        /// 列表可以以动画形式将当前项与列表分开
        /// A list can animate to set the current item apart from the list
        /// </summary>
        [Parameter]
        public bool Animated { get; set; }

        /// <summary>
        /// 放松
        /// 列表可以放松其填充以提供更多的负空间
        /// A list can relax its padding to provide more negative space
        /// </summary>
        [Parameter]
        public bool Relaxed { get; set; }

        /// <summary>
        /// 划分
        /// 列表可以显示内容之间的划分
        /// A list can show divisions between content
        /// </summary>
        [Parameter]
        public bool Divided { get; set; }

        /// <summary>
        /// 单元格
        /// 列表可以将其项划分为单元格
        /// A list can divide its items into cells
        /// </summary>
        [Parameter]
        public bool Celled { get; set; }

        /// <summary>
        /// 使项目在中间
        /// </summary>
        [Parameter]
        public bool Middle { get; set; }

        /// <summary>
        /// 尺寸
        /// 列表的大小可以不同
        /// A list can vary in size
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
