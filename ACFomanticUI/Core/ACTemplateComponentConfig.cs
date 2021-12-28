using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 模板组件配置
    /// </summary>
    public class ACTemplateComponentConfig : ACComponentConfig
    {
        /// <summary>
        /// 模板
        /// </summary>
        public RenderFragment Template { get; set; }
    }
}
