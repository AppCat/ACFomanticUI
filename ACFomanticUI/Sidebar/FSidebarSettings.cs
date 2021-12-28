using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏 设置
    /// </summary>
    public class FSidebarSettings
    {
        /// <summary>
        /// 是否在侧边栏可见时调暗页面内容
        /// Whether to dim page contents when sidebar is visible
        /// </summary>
        public bool DimPage { get; set; } = true;

        /// <summary>
        /// 是否可以通过点击页面关闭侧边栏
        /// Whether sidebar can be closed by clicking on page
        /// </summary>
        public bool Closable { get; set; } = true;

        /// <summary>
        /// 当侧边栏被隐藏时，是否返回到原来的滚动位置，自动发生过渡:缩放
        /// Whether to return to original scroll position when sidebar is hidden, automatically occurs with transition: scale
        /// </summary>
        public bool ReturnScroll { get; set; } = false;

        /// <summary>
        /// 是否在侧边栏可见时锁定页面滚动
        /// Whether to lock page scroll when sidebar is visible
        /// </summary>
        public bool ScrollLock { get; set; } = false;

        /// <summary>
        /// 是否可以同时打开多个侧边栏
        /// Whether multiple sidebars can be open at once
        /// </summary>
        public bool Exclusive { get; set; } = false;

        /// <summary>
        /// 当侧栏在没有正确HTML的情况下初始化时，使用此选项将推迟DOM的创建，以使用requestAnimationFrame
        /// When sidebar is initialized without the proper HTML, using this option will defer creation of DOM to use requestAnimationFrame.
        /// </summary>
        public bool DelaySetup { get; set; } = false;

        /// <summary>
        /// 侧边栏将出现在这个Id元素里面
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// 在边栏动画时使用的命名过渡。默认为'auto'，它根据方向从defaultTransition选择过渡。
        /// Named transition to use when animating sidebar. Defaults to 'auto' which selects transition from defaultTransition based on direction.
        /// </summary>
        public string Transition { get; set; }

        /// <summary>
        /// 在检测移动设备时进行动画时使用的命名转换。默认为'auto'，它根据方向从defaultTransition选择过渡。
        /// Named transition to use when animating when detecting mobile device. Defaults to 'auto' which selects transition from defaultTransition based on direction.
        /// </summary>
        public string MobileTransition { get; set; }

        /// <summary>
        /// 是否应该使用Javascript动画。默认值为false。设置为auto将只对不支持CSS转换的浏览器使用传统动画
        /// Whether Javascript animations should be used. Defaults to false. Setting to auto will use legacy animations only for browsers that do not support CSS transforms
        /// </summary>
        public bool UseLegacy { get; set; } = false;

        /// <summary>
        /// 使用遗留Javascript动画时侧边栏动画的持续时间
        /// Duration of sidebar animation when using legacy Javascript animation
        /// </summary>
        public int Duration { get; set; }
    }
}
