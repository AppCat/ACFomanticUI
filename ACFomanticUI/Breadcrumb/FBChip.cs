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
    public class FBChip : ACComponentConfig
    {
        /// <summary>
        /// 屑类型 About        
        /// </summary>
        public FBChipType Type { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 链接
        /// A section may be linkable or contain a link
        /// 一个节可以是可链接的，也可以包含一个链接
        /// </summary>
        public bool Link { get; set; }

        /// <summary>
        /// 超链接
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        public RenderFragment Template { get; set; }
    }
}
