using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态管理
    /// </summary>
    public partial class FModalManager : ACContentComponentBase
    {
        /// <summary>
        /// 模态服务
        /// </summary>
        [Inject]
        protected ACFModalService ModalService { get; set; }

        /// <summary>
        /// 模态
        /// </summary>
        protected FModal Modal { get; set; }

        /// <summary>
        /// 模态 模板设置
        /// </summary>
        protected FMTemplateSettings TemplateSettings { get; set; } = new FMTemplateSettings();

        /// <summary>
        /// 
        /// </summary>
        protected FModalSettings Settings { get; set; } = new FModalSettings();

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (ModalService.OnShowModal == null)
            {
                ModalService.OnShowModal = HandleOnShowModal; 
            }
        }

        /// <summary>
        /// 处理显示模态
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        protected async Task HandleOnShowModal((FModalSettings settings, FMTemplateSettings templateSettings) tuple)
        {
            if (tuple.templateSettings == null)
                return;
            TemplateSettings = tuple.templateSettings;
            Settings = tuple.settings ?? new FModalSettings();
            await Modal.SettingsAsync(Settings);
            await InvokeStateHasChangedAsync();
            await Modal.ShowAsync();
        }

        /// <summary>
        /// 隐藏后
        /// </summary>
        /// <returns></returns>
        protected async Task HandleHiddenAsync()
        {
            //TemplateSettings = null;
            //await InvokeStateHasChangedAsync();
            TemplateSettings = new FMTemplateSettings();
            await InvokeStateHasChangedAsync();
        }

        ///// <summary>
        ///// 构建渲染树
        ///// </summary>
        ///// <param name="builder"></param>
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    builder.OpenComponent<FModal>(0);
        //    builder.AddAttribute(1, "TemplateSettings", TemplateSettings);
        //    builder.AddAttribute(2, "ref", Modal);
        //    builder.CloseComponent();
        //}
    }
}
