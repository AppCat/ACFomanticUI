using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 行为 模板
    /// </summary>
    public class FMATemplateSettings
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 点击
        /// </summary>
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
