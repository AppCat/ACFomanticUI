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
    /// JS 模块基础
    /// </summary>
    public abstract class JSModuleBase
    {
        /// <summary>
        /// 模块
        /// </summary>
        public Lazy<Task<IJSObjectReference>> ModuleTask { get; set; }

        /// <summary>
        /// JS 模块
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="path"></param>
        public JSModuleBase(IJSRuntime runtime, string path)
        {
            if (ModuleTask == null)
            {
                //ModuleTask = new(() => runtime.InvokeAsync<IJSObjectReference>("import", "./_content/ACFomanticUI/acui/acfomanticui_modal.js").AsTask());
                ModuleTask = new(() => runtime.InvokeAsync<IJSObjectReference>("import", path).AsTask());
            }
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task<TResult> MethodAsync<TResult>([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            return await module.InvokeAsync<TResult>(method.ToInitialLower(), args);
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task VoidMethodAsync([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            await module.InvokeVoidAsync(method.ToInitialLower(), args);
        }
    }
}
