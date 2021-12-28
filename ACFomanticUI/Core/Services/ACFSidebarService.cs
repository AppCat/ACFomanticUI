using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏 服务
    /// </summary>
    public class ACFSidebarService
    {
        /// <summary>
        /// 显示边栏事件
        /// </summary>
        internal Func<(FSidebarSettings, FSidebarTemplateSettings), Task> OnSidebarModal { get; set; }

        /// <summary>
        /// 显示边栏
        /// </summary>
        /// <param name="templateSettings"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShowSidebarAsync(FSidebarTemplateSettings templateSettings, FSidebarSettings settings = null)
        {
            if (templateSettings == null)
            {
                throw new ArgumentNullException(nameof(templateSettings));
            }
            await OnSidebarModal?.Invoke((settings, templateSettings));
        }
    }
}
