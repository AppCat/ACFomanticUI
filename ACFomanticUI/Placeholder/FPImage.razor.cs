using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 图像
    /// 一个占位符可以包含一个图像
    /// A placeholder can contain an image
    /// </summary>
    public partial class FPImage : ACComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "image";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .GetIf(() => AspectRatio.ToClass(), () => AspectRatio != null)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 纵横比
        /// </summary>
        [Parameter]
        public FPAspectRatio? AspectRatio { get; set; }

        #endregion
    }
}
