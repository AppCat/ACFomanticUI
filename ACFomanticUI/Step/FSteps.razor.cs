using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 步骤
    /// 一个步骤
    /// A single step
    /// </summary>
    public partial class FSteps : ACListComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "steps";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Ordered).ToLowerInvariant(), () => Ordered)
                .If(nameof(Vertical).ToLowerInvariant(), () => Vertical)
                .If(nameof(Stackable).ToLowerInvariant(), () => Stackable)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)

                .GetIf(() => EvenlyDivided.ToClass(), () => EvenlyDivided != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter 

        /// <summary>
        /// 反转颜色
        /// 步骤的颜色可以反转
        /// A step's color can be inverted
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 步骤序列 
        /// 一个步骤可以显示一个有序的步骤序列
        /// A step can show a ordered sequence of steps
        /// </summary>
        [Parameter]
        public bool Ordered { get; set; }

        /// <summary>
        /// 垂直
        /// 步骤可以垂直堆叠显示
        /// A step can be displayed stacked vertically
        /// </summary>
        [Parameter]
        public bool Vertical { get; set; }

        /// <summary>
        /// 堆叠
        /// 一个台阶只能在较小的屏幕上垂直堆叠
        /// A step can stack vertically only on smaller screens
        /// </summary>
        [Parameter]
        public bool Stackable { get; set; }

        /// <summary>
        /// 流体
        /// 一个流体台阶占用了它的容器的宽度
        /// A fluid step takes up the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 不堆叠
        /// 一个台阶可以防止自己在移动上堆叠
        /// A step can prevent itself from stacking on mobile
        /// </summary>
        [Parameter]
        public bool Unstackable { get; set; }

        /// <summary>
        /// 附加
        /// 步骤可以附加到其他元素上
        /// Steps can be attached to other elements
        /// </summary>
        [Parameter]
        public bool Attached { get; set; }

        /// <summary>
        /// 均分
        /// 步骤可以在它们的父级内部均匀划分
        /// Steps can be divided evenly inside their parent
        /// </summary>
        [Parameter]
        public EnumMix<FNumber>  EvenlyDivided { get; set; }

        /// <summary>
        /// 尺寸
        /// 步骤可以有不同的大小
        /// Steps can have different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        /// <summary>
        /// 源项目
        /// </summary>
        [Parameter]
        public IEnumerable<IFStepItem> SourceItems { get; set; }

        #endregion
    }
}
