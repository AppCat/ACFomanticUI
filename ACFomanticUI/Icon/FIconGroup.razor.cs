using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 图标组
    /// 几个图标可以作为一个组一起使用
    /// Several icons can be used together as a group
    /// </summary>
    public partial class FIconGroup : ACContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "icons";

        /// <summary>
        /// 设置类
        /// </summary>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("disabled", () => Disabled)
                .GetIf(() => Size.ToClass(), () => Size != null)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 尺寸
        /// An icon can vary in size
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }


        #endregion
    }
}
