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
    public interface IFBChip : IACComponentConfig
    {
        /// <summary>
        /// 屑类型
        /// </summary>
        public FBChipType Type { get; }

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
