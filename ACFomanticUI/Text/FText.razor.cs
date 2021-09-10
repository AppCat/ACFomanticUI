using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 文本
    /// 文本总是内联使用，并使用FUI调色板中的一种颜色
    /// A text is always used inline and uses one color from the FUI color palette
    /// </summary>
    public partial class FText : ACContentComponentBase, IFTextConfig
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "text";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .GetIf(() => Emphasis.Value.ToClass(), () => Emphasis != null)
                .GetIf(() => Size.Value.ToClass(), () => Size != null)
                .GetIf(() => Colored.Value.ToClass(), () => Colored != null)
                .Add(_suffix)
                ;
        }

        #region Parameter

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string Content { get; set; }

        /// <summary>
        /// 颜色翻转
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 重点
        /// 可以被格式化以显示不同程度的强调
        /// </summary>
        [Parameter]
        public EnumMix<FEmphasisRank> Emphasis { get; set; }

        /// <summary>
        /// 尺寸
        /// 可以有不同的大小
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 颜色
        /// 可以有不同的颜色
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        #endregion
    }
}
