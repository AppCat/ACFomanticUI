using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态
    /// A modal displays content that temporarily blocks interactions with the main view of a site
    /// 模态显示临时阻止与网站主视图交互的内容
    /// </summary>
    public interface IFModal : IFModalConfig
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; }
    }
}
