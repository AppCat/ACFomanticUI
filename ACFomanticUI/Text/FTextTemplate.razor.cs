using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 文本模板
    /// </summary>
    public partial class FTextTemplate : ComponentBase
    {
        /// <summary>
        /// 变量 正则
        /// </summary>
        protected static readonly Regex VariableRegex = new Regex(@"(\$\{(\w+)\})", RegexOptions.Compiled);

        /// <summary>
        /// 构建渲染树
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (string.IsNullOrEmpty(Content))
                return;

            var values = new List<string>();
            var jump = 0;

            foreach (var item in VariableRegex.Split(Content))
            {
                if (jump > 0)
                {
                    jump--;
                    continue;
                }
                if (string.IsNullOrEmpty(item))
                    continue;

                values.Add(item);
                if (VariableRegex.IsMatch(item))
                {
                    jump = 1;
                }
            }

            var seq = 0;

            foreach (var value in values)
            {
                var match = VariableRegex.Match(value);
                if (match.Success)
                {
                    var config = VariableHandler.Invoke(match.Groups[2].Value);
                    config ??= new FTextConfig { Content = value };

                    builder.OpenComponent(seq++, typeof(FText));
                    builder.AddAttribute(seq++, nameof(config.Colored), config.Colored);
                    builder.AddAttribute(seq++, nameof(config.Size), config.Size);
                    builder.AddAttribute(seq++, nameof(config.Emphasis), config.Emphasis);
                    builder.AddAttribute(seq++, nameof(config.Content), config.Content);
                    builder.AddAttribute(seq++, nameof(config.Style), config.Style);
                    builder.AddAttribute(seq++, nameof(config.Class), config.Class);
                    if (config.Attributes != null)
                        builder.AddAttribute(seq++, nameof(config.Attributes), config.Attributes);
                    builder.CloseComponent();
                }
                else
                {
                    builder.AddContent(seq++, value);
                }
            }

        }

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string Content { get; set; }

        /// <summary>
        /// 变量处理程序
        /// </summary>
        [Parameter]
        public Func<string, FTextConfig> VariableHandler { get; set; }
    }
}