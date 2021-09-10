using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 标签组
    /// </summary>
    public partial class FLabelGroup : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "labels";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Circular).ToLowerInvariant(), () => Circular)
                .If(nameof(Tag).ToLowerInvariant(), () => Tag)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter

        /// <summary>
        /// 标签
        /// 标签可以共享标签格式
        /// Labels can share tag formatting
        /// </summary>
        [Parameter]
        public bool Tag { get; set; }

        /// <summary>
        /// 圆的
        /// 标签可以共享形状
        /// Labels can share shapes
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 尺寸
        /// 标签可以共享尺寸
        /// Labels can share sizes together
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        /// <summary>
        /// 尺寸
        /// 标签可以共享颜色
        /// Labels can share colors together
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        #endregion
    }
}
