using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态 设置
    /// </summary>
    public class FModalSettings
    {
        /// <summary>
        /// 可拆式
        /// 如果设置为false将阻止模态被移动到调光器内部
        /// If set to false will prevent the modal from being moved to inside the dimmer
        /// </summary>
        public bool Detachable { get; set; } = true;

        /// <summary>
        /// 使用Flex
        /// Auto会在支持flex容器内绝对定位元素的浏览器中自动使用flex。设置为true/false将强制所有浏览器都进行此设置。
        /// Auto will automatically use flex in browsers that support absolutely positioned elements inside flex containers. Setting to true/false will force this setting for all browsers.
        /// </summary>
        public string UseFlex { get; set; } = "auto";

        /// <summary>
        /// 自动对焦
        /// 当为true时，模态中的第一个表单输入将在显示时接收焦点。将此设置为false以防止此行为。
        /// When true, the first form input inside the modal will receive focus when shown. Set this to false to prevent this behavior.
        /// </summary>
        public bool Autofocus { get; set; } = true;

        /// <summary>
        /// 恢复的焦点
        /// 当为false时，在显示模态之前的最后一个被聚焦的元素将不会在模态隐藏时再次被聚焦。这可以防止关闭模态后出现不必要的滚动行为。
        /// When false, the last focused element, before the modal was shown, will not get refocused again when the modal hides. This could prevent unwanted scrolling behaviors after closing a modal.
        /// </summary>
        public bool RestoreFocus { get; set; } = false;

        /// <summary>
        /// 自动显示
        /// 当为true时，立即在实例化时显示模态
        /// When true, immediately shows the modal at instantiation time
        /// </summary>
        public bool AutoShow { get; set; } = false;

        /// <summary>
        /// 观察变化
        /// 模态DOM中的任何更改是否应该自动刷新缓存的位置
        /// Whether any change in modal DOM should automatically refresh cached positions
        /// </summary>
        public bool ObserveChanges { get; set; } = false;

        /// <summary>
        /// 允许多个
        /// 如果设置为true，将不会在打开一个新模态时关闭其他可见模态
        /// If set to true will not close other visible modals when opening a new one
        /// </summary>
        public bool AllowMultiple { get; set; } = false;

        /// <summary>
        /// 倒置调光器
        /// 如果使用倒置调光器
        /// If inverted dimmer should be used
        /// </summary>
        public bool Inverted { get; set; } = false;

        /// <summary>
        /// 模糊
        /// 如果调光器应该模糊背景
        /// If dimmer should blur background
        /// </summary>
        public bool Blurring { get; set; } = false;

        /// <summary>
        /// 居中对齐
        /// 如果模态应居中对齐
        /// If modal should be center aligned
        /// </summary>
        public bool Centered { get; set; } = true;

        /// <summary>
        /// 模糊
        /// 是否自动绑定键盘快捷键
        /// Whether to automatically bind keyboard shortcuts
        /// </summary>
        public bool KeyboardShortcuts { get; set; } = true;

        /// <summary>
        /// 垂直偏移
        /// 一种垂直偏移，允许模态外的内容居中，例如关闭按钮。
        /// A vertical offset to allow for content outside of modal, for example a close button, to be centered.
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 选择器或jquery对象指定要暗淡的区域
        /// Selector or jquery object specifying the area to dim
        /// </summary>
        //public int Context { get; set; }

        /// <summary>
        /// 可闭
        /// 设置为false将不允许您通过点击调光器关闭模态
        /// Setting to false will not allow you to close the modal by clicking on the dimmer
        /// </summary>
        public bool Closable { get; set; } = true;

        /// <summary>
        /// 过度
        /// </summary>
        public object Transition { get; set; } = new
        {
            showMethod   = "zoom",
            showDuration = 50,
            hideMethod   = "zoom",
            hideDuration = 10,
        };

        /// <summary>
        /// 动画的持续时间
        /// 动画的持续时间。当通过转换设置提供单独的隐藏/显示持续时间值时，该值将被忽略
        /// Duration of animation. The value will be ignored when individual hide/show duration values are provided via the transition setting
        /// </summary>
        public int Duration { get; set; } = 50;

        /// <summary>
        /// 动画排队
        /// Whether additional animations should queue
        /// 其他动画是否应该排队
        /// </summary>
        public bool Queue { get; set; } = false;

        /// <summary>
        /// 滚动条的宽度
        /// 在内部用于确定webkit自定义滚动条是否被单击以防止隐藏调光器。这应该设置为与@customScrollbarWidth在站点中定义的相同(数值)值。如果你使用的是不同的主题，就会少一些
        /// Used internally to determine if the webkit custom scrollbar was clicked to prevent hiding the dimmer. This should be set to the same (numeric) value as defined for @customScrollbarWidth in site.less in case you are using a different theme
        /// </summary>
        public int ScrollbarWidth { get; set; } = 10;
    }
}
