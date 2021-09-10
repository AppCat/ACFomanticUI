using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 轨道
    /// 轨道用于显示网站主视图边界之外的附带内容
    /// A rail is used to show accompanying content outside the boundaries of the main view of a site
    /// </summary>
    public abstract class FRailBase : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        protected const string Prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        protected abstract string Suffix { get; }

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(Prefix)
                .If(nameof(Dividing).ToLowerInvariant(), () => Dividing)
                .If(nameof(Internal).ToLowerInvariant(), () => Internal)
                .If(nameof(Attached).ToLowerInvariant(), () => Attached)

                .GetIf(() => Close.ToClass(), () => Close != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                //.If("disabled", () => Disabled)
                .Add(Suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 界线
        /// 轨道可以在它自己和容器之间创建一个分隔
        /// A rail can create a division between itself and a container
        /// </summary>
        [Parameter]
        public bool Dividing { get; set; }

        /// <summary>
        /// 内部
        /// 轨道可以固定在集装箱内部。
        /// A rail can attach itself to the inside of a container
        /// </summary>
        [Parameter]
        public bool Internal { get; set; }

        /// <summary>
        /// 附加的
        /// 轨道可以出现在主视口上。
        /// A rail can appear attached to the main viewport
        /// </summary>
        [Parameter]
        public bool Attached { get; set; }

        /// <summary>
        /// 轨道可以出现在主视口附近
        /// A rail can appear closer to the main viewport
        /// </summary>
        [Parameter]
        public EnumMix<FRailClose> Close { get; set; }

        /// <summary>
        /// 尺寸
        /// 轨道可以有不同的尺寸
        /// A rail can have different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
