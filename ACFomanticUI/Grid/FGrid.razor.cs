using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 栅格
    /// 栅格用于协调布局中的负空间
    /// A grid is used to harmonize negative space in a layout
    /// </summary>
    public partial class FGrid : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "grid";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("equal width", () => EqualWidth)
                .If(nameof(Centered).ToLowerInvariant(), () => Centered)
                .If(nameof(Doubling).ToLowerInvariant(), () => Doubling)
                .If(nameof(Stackable).ToLowerInvariant(), () => Stackable)
                .GetIf(() => Padded.ToClass(), () => Padded != null)
                .GetIf(() => Divided.ToClass(), () => Divided != null)
                .GetIf(() => Relaxed.ToClass(), () => Relaxed != null)
                .GetIf(() => Reversed.ToClass(), () => Reversed != null)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .GetIf(() => $"{ColumnCount.ToClass()} column", () => ColumnCount != null)
                .Add(_suffix)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 平等宽度
        /// 网格可以自动调整所有元素的大小，以均匀地分割可用宽度
        /// A grid can automatically resize all elements to split the available width evenly
        /// </summary>
        [Parameter]
        public bool EqualWidth { get; set; }

        /// <summary>
        /// 剧中
        /// 网格的列可以居中
        /// A grid can have its columns centered
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }

        /// <summary>
        /// 并线
        /// 在平板电脑和移动设备上，网格的列宽可以翻倍
        /// A grid can double its column width on tablet and mobile sizes
        /// <remarks>
        /// A grid will round its columns to the closest reasonable value when doubling, for example a five column grid will use 2 mobile, 3 tablet, 5 desktop. To force 1 column on mobile you can add stackable
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool Doubling { get; set; }

        /// <summary>
        /// 堆叠
        /// 在到达移动断点后，网格的列可以堆叠在一起
        /// A grid can have its columns stack on-top of each other after reaching mobile breakpoints
        /// <remarks>
        /// 若要查看网格堆栈，请尝试将浏览器调整为较小的宽度
        /// To see a grid stack, try resizing your browser to a small width
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool Stackable { get; set; }

        /// <summary>
        /// 负空间
        /// A grid can increase its gutters to allow for more negative space
        /// 网格可以增加它的排水沟，以允许更多的负空间
        /// </summary>
        [Parameter]
        public EnumMix<FGridRelaxed> Relaxed { get; set; }

        /// <summary>
        /// 填充
        /// 网格可以在第一列和最后一列保留垂直和水平的排水沟
        /// A grid can preserve its vertical and horizontal gutters on first and last columns
        /// </summary>
        [Parameter]
        public EnumMix<FGridPadded> Padded { get; set; }

        /// <summary>
        /// 分隔符
        /// 网格的列之间可以有分隔符
        /// A grid can have dividers between its columns
        /// </summary>
        [Parameter]
        public EnumMix<FGridDivided> Divided { get; set; }

        /// <summary>
        /// 列数量
        /// 网格可以自动调整所有元素的大小，以均匀地分割可用宽度——网格每行可以有不同的列数
        /// A grid can have a different number of columns per row
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> ColumnCount { get; set; }

        /// <summary>
        /// 对齐
        /// 网格、行或列可以指定其文本对齐方式
        /// A grid, row, or column can specify its text alignment
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        /// <summary>
        /// 颠倒的
        /// 网格或行可以指定其列在不同设备大小时的顺序相反
        /// A grid or row can specify that its columns should reverse order at different device sizes
        /// <remarks>
        /// 反向网格与分割网格和其他复杂网格类型兼容。
        /// Reversed grids are compatible with divided grids and other complex grid types.
        /// </remarks>
        /// </summary>
        [Parameter]
        public EnumMix<FGridReversed> Reversed { get; set; }       

        #endregion
    }
}
