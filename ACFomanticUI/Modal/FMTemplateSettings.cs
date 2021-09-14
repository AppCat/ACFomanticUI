using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态 模板 设置
    /// </summary>
    public class FMTemplateSettings
    {
        /// <summary>
        /// 附属
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 标题
        /// 模态标题的内容
        /// Content of the modal header
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        public RenderFragment<object> TitleTemplate { get; set; }

        /// <summary>
        /// 内容
        /// 模态内容的内容
        /// Content of the modal content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        public RenderFragment<object> ContentTemplate { get; set; }

        /// <summary>
        /// 关闭图标
        /// Whether the modal should include a close icon
        /// 模态是否应该包含一个关闭图标
        /// </summary>
        public bool CloseIcon { get; set; } = false;

        /// <summary>
        /// 尺寸
        /// </summary>
        public EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 颜色可以颠倒
        /// </summary>
        public bool Inverted { get; set; }

        /// <summary>
        /// 一个对象数组。每个对象都定义了一个具有文本、类、图标和单击属性的操作
        /// </summary>
        public FMATemplateSettings[] Actions { get; set; }

        /// <summary>
        /// 操作模板
        /// </summary>
        public RenderFragment<object> ActionsTemplate { get; set; }

        /// <summary>
        /// 保持HTML
        /// HTML是否包含在给定的标题，内容或动作应该被保留。如果您使用不受信任的第三方内容，则设置为false
        /// Whether HTML included in given title, content or actions should be preserved. Set to false in case you work with untrusted 3rd party content
        /// </summary>
        //public bool PreserveHTML { get; set; } = true;

        /// <summary>
        /// 可以保存要添加到模态类以控制其外观的字符串。
        /// Can hold a string to be added to the modal class to control its appearance.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 可以保存要添加到模态样式以控制其外观的字符串。
        /// Can hold a string to be added to the modal style to control its appearance.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 可以保存要添加到标题类以控制其外观的字符串。
        /// Can hold a string to be added to the title class to control its appearance.
        /// </summary>
        public string TitleClass { get; set; }

        /// <summary>
        /// 可以保存要添加到标题类以控制其外观的字符串。
        /// 可以保存要添加到标题样式以控制其外观的字符串。
        /// </summary>
        public string TitleStyle { get; set; }

        /// <summary>
        /// 可以保存要添加到内容类以控制其外观的字符串。
        /// Can hold a string to be added to the content class to control its appearance.
        /// </summary>
        public string ContentClass { get; set; }

        /// <summary>
        /// 可以保存要添加到内容样式以控制其外观的字符串。
        /// Can hold a string to be added to the content style to control its appearance.
        /// </summary>
        public string ContentStyle { get; set; }

        /// <summary>
        /// 可以保存要添加到actions类以控制其外观的字符串。
        /// Can hold a string to be added to the actions class to control its appearance.
        /// </summary>
        public string ActionsClass { get; set; }

        /// <summary>
        /// 可以保存要添加到动作样式的字符串以控制其外观。
        /// Can hold a string to be added to the actions style to control its appearance.
        /// </summary>
        public string ActionsStyle { get; set; }

        /// <summary>
        /// 在按下否定、拒绝或取消按钮后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a negative, deny or cancel button is pressed. If the function returns false the modal will not hide.
        /// </summary>
        public Func<bool> OnDeny { get; set; }

        /// <summary>
        /// 在模态开始隐藏后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a modal starts to hide. If the function returns false, the modal will not hide.
        /// </summary>
        public Func<bool> OnHide { get; set; }

        /// <summary>
        /// 在按下肯定、批准或ok按钮后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a positive, approve or ok button is pressed. If the function returns false, the modal will not hide.
        /// </summary>
        public Func<bool> OnApprove { get; set; }
    }
}
