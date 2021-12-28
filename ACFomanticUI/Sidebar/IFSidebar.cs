using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏
    /// 侧边栏隐藏了页面旁边的附加内容。
    /// A sidebar hides additional content beside a page.
    /// </summary>
    public interface IFSidebar : ISidebarConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get;}
    }
}
