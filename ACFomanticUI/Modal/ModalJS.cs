using ACUI.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI.JS
{
    /// <summary>
    /// modal JS 模块
    /// </summary>
    public sealed class ModalJS : JSModuleBase
    {

        /// <summary>
        /// modal JS 模块
        /// </summary>
        /// <param name="runtime"></param>
        public ModalJS(IJSRuntime runtime) : base(runtime, "./_content/ACFomanticUI/acui/acfomanticui_modal.js")
        {
            
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="modal"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task Settings(IFModal modal, FModalSettings settings = null)
        {
            await VoidMethodAsync("settings", args: new object[] { modal.Id, (settings ?? new FModalSettings()).ToTrimObject() });
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="modal"></param>
        public async Task ShowAsync(IFModal modal)
        {
            await VoidMethodAsync("show", args: new object[] { modal.Id });
        }
    }
}
