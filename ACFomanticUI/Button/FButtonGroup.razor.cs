using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 按钮组
    /// </summary>
    public partial class SButtonGroup : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "buttons";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Attached.ToClass(), () => Attached != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .If("fluid", () => Fluid)
                .If("disabled", () => Disabled)
                .If("icon", () => Icon)
                .If("compact", () => Compact)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 使用图标
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }

        /// <summary>
        /// 袖珍
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 按钮可以取其容器的宽度
        /// A button can take the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 尺寸
        /// A button can have different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        /// <summary>
        /// 颜色
        /// A button can have different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 依附
        /// A button can be attached to the top or bottom of other content
        /// </summary>
        [Parameter]
        public EnumMix<FAttached>  Attached { get; set; }

        #endregion

        #region SDLC



        #endregion
    }
}
