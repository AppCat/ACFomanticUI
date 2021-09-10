using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 标题
    /// 占位符可以包含标题
    /// A placeholder can contain a header
    /// Header content will have a slightly larger block size from paragraph
    /// </summary>
    public partial class FPHeader : ACContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "header";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Image).ToLowerInvariant(), () => Image)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 图像
        /// </summary>
        [Parameter]
        public bool Image { get; set; }

        #endregion
    }
}
