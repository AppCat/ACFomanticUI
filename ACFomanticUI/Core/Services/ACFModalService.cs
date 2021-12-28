using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态 服务
    /// </summary>
    public class ACFModalService
    {
        /// <summary>
        /// 显示消息事件
        /// </summary>
        internal Func<(FModalSettings settings, FMTemplateSettings templateSettings), Task> OnShowModal { get; set; }

        /// <summary>
        /// 显示模态
        /// </summary>
        /// <param name="templateSettings"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShowModalAsync(FMTemplateSettings templateSettings, FModalSettings settings = null)
        {
            if (templateSettings == null)
            {
                throw new ArgumentNullException(nameof(templateSettings));
            }
            await OnShowModal?.Invoke((settings, templateSettings));
        }
    }
}
