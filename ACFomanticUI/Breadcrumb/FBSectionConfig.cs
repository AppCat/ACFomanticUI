using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 截面配置
    /// </summary>
    public class FBSectionConfig : FBChipBase, IFBSection
    {
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
        /// 屑类型
        /// </summary>
        public override FBChipType Type => FBChipType.Section;
    }
}
