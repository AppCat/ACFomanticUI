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
    /// 按钮
    /// </summary>
    public partial class FContainer : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "container";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("disabled", () => Disabled)
                .If("text", () => Text)
                .If("fluid", () => Fluid)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .Add(_suffix)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 文本容器
        /// 容器可以减少其最大宽度，以便更自然地容纳单个文本列
        /// A container can reduce its maximum width to more naturally accomodate a single column of text
        /// </summary>
        [Parameter]
        public bool Text { get; set; }

        /// <summary>
        /// 流体
        /// 流体容器没有最大宽度
        /// A fluid container has no maximum width
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 文本对齐
        /// 容器可以指定其文本对齐方式
        /// A container can specify its text alignment
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment>  TextAlignment { get; set; }

        #endregion
    }
}
