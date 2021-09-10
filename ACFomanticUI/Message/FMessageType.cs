using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum FMessageType
    {
        /// <summary>
        /// 警告
        /// 可以将消息格式化为显示警告消息。
        /// A message may be formatted to display warning messages.
        /// </summary>
        Warning,
        /// <summary>
        /// 信息
        /// A message may be formatted to display information.
        /// 可以对消息进行格式化以显示信息。
        /// </summary>
        Info,
        /// <summary>
        /// 积极
        /// A message may be formatted to display a positive message.
        /// 可以对消息进行格式化，以显示积极的消息。
        /// </summary>
        Positive,
        /// <summary>
        /// 成功
        /// 同 Positive
        /// </summary>
        Success,
        /// <summary>
        /// 消极的
        /// 可以将消息格式化为显示消极消息。
        /// A message may be formatted to display a negative message.
        /// </summary>
        Negative,
        /// <summary>
        /// 错误
        /// 同 Negative
        /// </summary>
        Error
    }
}
