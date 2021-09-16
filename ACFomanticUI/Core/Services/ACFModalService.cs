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
        internal Func<FMTemplateSettings, Task> OnShowModal { get; set; }

        /// <summary>
        /// 显示模态
        /// </summary>
        /// <returns></returns>
        public async Task ShowModalAsync(FMTemplateSettings templateSettings)
        {
            if (templateSettings != null)
            {
                await OnShowModal?.Invoke(templateSettings);
            }
        }
    }
}
