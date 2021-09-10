using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 占位符
    /// A placeholder is used to reserve a place for content that soon will appear in a layout
    /// 占位符用于为即将出现在布局中的内容预留位置
    /// </summary>
    public partial class FPlaceholder : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "placeholder";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                //.If("disabled", () => Disabled)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 流体
        /// 流体占位符占用其容器的宽度
        /// A fluid placeholder takes up the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 翻转
        /// 占位符的颜色可以颠倒。
        /// A placeholder can have their colors inverted.
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        #endregion
    }
}
