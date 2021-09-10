using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 屑
    /// </summary>
    public abstract class FBChipBase : ACComponentConfig, IFBChip
    {
        /// <summary>
        /// 屑类型 About        
        /// </summary>
        public abstract FBChipType Type { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        public RenderFragment ContentTemplate { get; set; }
    }
}
