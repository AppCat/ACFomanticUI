using ACUI.Extensions;
using ACUI.FomanticUI.JS;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI.JS
{
    /// <summary>
    /// sidebar JS 模块
    /// </summary>
    public sealed class SidebarJS : JSModuleBase
    {
        /// <summary>
        /// sidebar JS 模块
        /// </summary>
        /// <param name="runtime"></param>
        public SidebarJS(IJSRuntime runtime) : base(runtime, "./_content/ACFomanticUI/acui/acfomanticui_sidebar.js")
        {

        }

        /// <summary>
        /// 开关
        /// </summary>
        /// <param name="sidebar"></param>
        /// <returns></returns>
        public async Task Toggle(IFSidebar sidebar)
        {
            await VoidMethodAsync("toggle", args: new object[] { sidebar.Id });
        }

        /// <summary>
        /// 设置侧边栏
        /// </summary>
        /// <param name="sidebar"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task Settings(IFSidebar sidebar, FSidebarSettings settings = null)
        {
            await VoidMethodAsync("settings", args: new object[] { sidebar.Id, (settings ?? new FSidebarSettings()).ToTrimObject() });
        }
    }
}
