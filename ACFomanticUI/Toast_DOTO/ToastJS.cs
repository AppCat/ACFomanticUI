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
    public sealed class ToastJS
    {
        /// <summary>
        /// 模块
        /// </summary>
        public Lazy<Task<IJSObjectReference>> ModuleTask { get; set; }

        /// <summary>
        /// modal JS 模块
        /// </summary>
        /// <param name="runtime"></param>
        public ToastJS(IJSRuntime runtime)
        {
            if (ModuleTask == null)
            {
                ModuleTask = new(() => runtime.InvokeAsync<IJSObjectReference>("import", "./_content/ACFomanticUI/acui/acfomanticui_toast.js").AsTask());
            }
        }

        /// <summary>
        /// 弹
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShotAsync(FToastSettings settings)
        {
            await VoidMethodAsync("shot", settings);
        }

        /// <summary>
        /// 弹
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShotAsync(object settings)
        {
            await VoidMethodAsync("shot", settings);
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
