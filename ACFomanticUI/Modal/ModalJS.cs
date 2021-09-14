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
    public sealed class ModalJS
    {
        /// <summary>
        /// 模块
        /// </summary>
        public Lazy<Task<IJSObjectReference>> ModuleTask { get; set; }

        /// <summary>
        /// modal JS 模块
        /// </summary>
        /// <param name="runtime"></param>
        public ModalJS(IJSRuntime runtime)
        {
            if (ModuleTask == null)
            {
                ModuleTask = new(() => runtime.InvokeAsync<IJSObjectReference>("import", "./_content/ACFomanticUI/acui/acfomanticui_modal.js").AsTask());
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="modal"></param>
        /// <returns></returns>
        public async Task Set(IFModal modal)
        {
            await VoidMethodAsync("set", args: new object[] { modal.Id, modal.Settings?.ToTrimObject() });
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="modal"></param>
        public async Task ShowAsync(IFModal modal)
        {
            await VoidMethodAsync("show", args: new object[] { modal.Id });
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task<object> MethodAsync([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            return await module.InvokeAsync<object>(method.ToInitialLower(), args);
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task VoidMethodAsync([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            await module.InvokeVoidAsync(method.ToInitialLower(), args);
        }
    }
}
