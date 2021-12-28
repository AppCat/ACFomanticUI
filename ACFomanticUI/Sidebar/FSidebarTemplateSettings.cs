using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模板设置
    /// </summary>
    public class FSidebarTemplateSettings
    {
        /// <summary>
        /// 附属
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 可以保存要添加到内容类以控制其外观的字符串。
        /// Can hold a string to be added to the content class to control its appearance.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 可以保存要添加到内容样式以控制其外观的字符串。
        /// Can hold a string to be added to the content style to control its appearance.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        public RenderFragment<object> ContentTemplate { get; set; }

        /// <summary>
        /// 当侧边栏开始显示动画时调用。
        /// Is called when a sidebar begins animating in.
        /// </summary>
        [Parameter]
        public EventCallback OnVisible { get; set; }

        /// <summary>
        /// 在边栏完成动画时调用。
        /// Is called when a sidebar has finished animating in.
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 当侧边栏开始隐藏或显示时调用。
        /// Is called when a sidebar begins to hide or show
        /// </summary>
        [Parameter]
        public EventCallback OnChange { get; set; }

        /// <summary>
        /// 在侧边栏开始动画输出之前调用。
        /// Is called before a sidebar begins to animate out.
        /// </summary>
        public EventCallback OnHide { get; set; }

        /// <summary>
        /// 在边栏完成动画输出后调用。
        /// Is called after a sidebar has finished animating out.
        /// </summary>
        public EventCallback OnHidden { get; set; }

        /// <summary>
        /// 颜色翻转
        /// </summary>
        public bool Inverted { get; set; }

        /// <summary>
        /// 宽度
        /// 侧边栏可以指定它的宽度
        /// A sidebar can specify its width
        /// </summary>
        [Parameter]
        public EnumMix<FSidebarWidth> Width { get; set; }

        /// <summary>
        /// 方向
        /// 侧边栏可以出现在页面的不同侧面
        /// A sidebar can appear on different sides of the page
        /// </summary>
        [Parameter]
        public EnumMix<FSidebarDirection> Direction { get; set; } = FSidebarDirection.Left;
    }
}
