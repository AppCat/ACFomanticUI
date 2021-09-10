using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 图像组
    /// </summary>
    public partial class FImageGroup : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "images";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 尺寸
        /// 一个图像可能以不同的尺寸出现
        /// An image may appear at different sizes
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
