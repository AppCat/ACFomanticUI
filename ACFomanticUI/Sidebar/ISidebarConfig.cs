using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏配置
    /// </summary>
    public interface ISidebarConfig
    {
        /// <summary>
        /// 设置
        /// </summary>
        public FSidebarSettings Settings { get; set; }

        /// <summary>
        /// 模板设置
        /// </summary>
        public FSidebarTemplateSettings TemplateSettings { get; set; }
        

    }
}
