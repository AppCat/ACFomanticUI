using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    public partial class FSidebarManager : ACContentComponentBase
    {
        /// <summary>
        /// 边栏服务
        /// </summary>
        [Inject]
        protected ACFSidebarService SidebarService { get; set; }

        /// <summary>
        /// 边栏
        /// </summary>
        protected FSidebar Sidebar { get; set; }

        /// <summary>
        /// 边栏 模板设置
        /// </summary>
        protected FSidebarTemplateSettings TemplateSettings { get; set; } = new FSidebarTemplateSettings();

        /// <summary>
        /// 边栏 设置
        /// </summary>
        protected FSidebarSettings Settings { get; set; } = new FSidebarSettings();

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (SidebarService.OnSidebarModal == null)
            {
                SidebarService.OnSidebarModal = HandleOnShowModal;
            }
        }

        /// <summary>
        /// 处理显示模态
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        protected async Task HandleOnShowModal((FSidebarSettings settings, FSidebarTemplateSettings templateSettings) tuple)
        {
            if (tuple.templateSettings == null)
                return;
            TemplateSettings = tuple.templateSettings;
            Settings = tuple.settings ?? new FSidebarSettings();
            await Sidebar.SettingsAsync(Settings);
            await InvokeStateHasChangedAsync();
            await Sidebar.ToggleAsync();
        }

        /// <summary>
        /// 隐藏后
        /// </summary>
        /// <returns></returns>
        protected async Task HandleHiddenAsync()
        {
            //TemplateSettings = null;
            //await InvokeStateHasChangedAsync();
            TemplateSettings = new FSidebarTemplateSettings();
            await InvokeStateHasChangedAsync();
        }
    }
}
