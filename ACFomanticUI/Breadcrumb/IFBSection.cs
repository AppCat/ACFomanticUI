using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 截面
    /// 用于面包屑的子标签
    /// </summary>
    public interface IFBSection
    {
        /// <summary>
        /// 内容
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        bool Link { get; set; }


        /// <summary>
        /// 超链接
        /// </summary>
        string Href { get; set; }
    }
}
