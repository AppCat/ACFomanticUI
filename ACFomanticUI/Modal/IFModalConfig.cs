using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态 配置
    /// </summary>
    public interface IFModalConfig
    {
        /// <summary>
        /// 模态 设置
        /// </summary>
        public FModalSettings Settings { get; set; }

        /// <summary>
        /// 模板设置
        /// </summary>
        public FMTemplateSettings TemplateSettings { get; set; }
    }
}
