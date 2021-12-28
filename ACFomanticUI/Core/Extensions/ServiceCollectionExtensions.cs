using ACUI.FomanticUI.JS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加语义
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddACFomanticUI(this IServiceCollection services)
        {
            services.AddSingleton<ACFNotificationService>();

            // Modal
            services.AddSingleton<ModalJS>();
            services.AddSingleton<ACFModalService>();

            // Toast
            services.AddSingleton<ToastJS>();
            services.AddSingleton<ACFToastService>();

            // Sidebar
            services.AddSingleton<SidebarJS>();
            services.AddSingleton<ACFSidebarService>();

            return services;
        }
    }
}
