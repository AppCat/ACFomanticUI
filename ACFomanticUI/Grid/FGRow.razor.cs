using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 栅格行
    /// </summary>
    public partial class FGRow : ACContentComponentBase
    {
        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "row";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If("stretched", () => Stretched)
                .GetIf(() => $"{ColumnCount.ToClass()} column", () => ColumnCount != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => $"{string.Join(" ", DeviceVisibilitys.Select(dv => dv.ToClass()))} only", () => DeviceVisibilitys != null)
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
        /// 列数量
        /// 网格可以自动调整所有元素的大小，以均匀地分割可用宽度——网格每行可以有不同的列数
        /// A grid can have a different number of columns per row
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> ColumnCount { get; set; }

        /// <summary>
        /// 颜色
        /// 行或列可以被着色
        /// A row or column can be colored
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 设备可见度
        /// 列或行只能出现在特定的设备或屏幕大小
        /// A columns or row can appear only for a specific device, or screen sizes
        /// </summary>
        [Parameter]
        public FColumnDeviceVisibility[] DeviceVisibilitys { get; set; }

        #endregion
    }
}
