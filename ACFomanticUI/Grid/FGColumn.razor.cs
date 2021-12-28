using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 栅格列
    /// </summary>
    public partial class FGColumn : ACContentComponentBase
    {
        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "column";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If("stretched", () => Stretched)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => $"{Wide.ToClass()} wide", () => Wide != null)
                .GetIf(() => $"{string.Join(" ", DeviceVisibilitys.Select(dv => dv.ToClass()))} only", () => DeviceVisibilitys != null)
                .GetIf(() => $"{MobileWide.ToClass()} wide mobile", () => MobileWide != null)
                .GetIf(() => $"{TabletWide.ToClass()} wide tablet", () => TabletWide != null)
                .GetIf(() => $"{ComputerWide.ToClass()} wide computer", () => ComputerWide != null)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .Add(_suffix)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 拉伸
        /// 行可以扩展其内容以占据整个列的高度
        /// A row can stretch its contents to take up the entire column height
        /// </summary>
        [Parameter]
        public bool Stretched { get; set; }

        /// <summary>
        /// 列宽
        /// 一个列可以在宽度上变化，占用一个以上的网格列。
        /// A column can vary in width taking up more than a single grid column.
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> Wide { get; set; }

        /// <summary>
        /// 浮动
        /// 一列可以与行的左边缘或右边缘齐平
        /// A column can sit flush against the left or right edge of a row
        /// </summary>
        [Parameter]
        public EnumMix<FFloated> Floated { get; set; }

        /// <summary>
        /// 颜色
        /// 行或列可以被着色
        /// A row or column can be colored
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 对齐
        /// 网格、行或列可以指定其文本对齐方式
        /// A grid, row, or column can specify its text alignment
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        /// <summary>
        /// 设备可见度
        /// 列或行只能出现在特定的设备或屏幕大小
        /// A columns or row can appear only for a specific device, or screen sizes
        /// </summary>
        [Parameter]
        public EnumMix<FColumnDeviceVisibility>[] DeviceVisibilitys { get; set; }

        /// <summary>
        /// 移动设备响应宽度
        /// 列可以指定特定设备的宽度。
        /// A column can specify a width for a specific device.
        /// <remarks>
        /// It's recommended to use a responsive pattern like doubling or stackable to reduce complexity when designing responsively, however in some circumstances specifying exact widths for screen sizes may be necessary.
        /// 在响应式设计时，建议使用响应模式，如加倍或堆叠，以减少复杂性，但在某些情况下，为屏幕尺寸指定精确的宽度可能是必要的。
        /// </remarks>
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> MobileWide { get; set; }

        /// <summary>
        /// 平板响应宽度
        /// 列可以指定特定设备的宽度。
        /// A column can specify a width for a specific device.
        /// <remarks>
        /// It's recommended to use a responsive pattern like doubling or stackable to reduce complexity when designing responsively, however in some circumstances specifying exact widths for screen sizes may be necessary.
        /// 在响应式设计时，建议使用响应模式，如加倍或堆叠，以减少复杂性，但在某些情况下，为屏幕尺寸指定精确的宽度可能是必要的。
        /// </remarks>
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> TabletWide { get; set; }

        /// <summary>
        /// 计算机响应宽度
        /// 列可以指定特定设备的宽度。
        /// A column can specify a width for a specific device.
        /// <remarks>
        /// It's recommended to use a responsive pattern like doubling or stackable to reduce complexity when designing responsively, however in some circumstances specifying exact widths for screen sizes may be necessary.
        /// 在响应式设计时，建议使用响应模式，如加倍或堆叠，以减少复杂性，但在某些情况下，为屏幕尺寸指定精确的宽度可能是必要的。
        /// </remarks>
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> ComputerWide { get; set; }

        #endregion
    }
}
