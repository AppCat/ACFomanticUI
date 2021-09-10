using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 通知服务
    /// </summary>
    public class ACFNotificationService
    {
        /// <summary>
        /// 显示消息事件
        /// </summary>
        internal event Action<FMessageOptions> OnShowMessage;

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <returns></returns>
        public void ShowMessage(FMessageOptions options)
        {
            OnShowMessage.Invoke(options ?? new FMessageOptions());
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public void ShowMessage(string message, FMessageType? type = null)
        {
            var mo = FMessageOptions.Info(message);
            if(type != null)
            {
                mo.Type = type;
            }
            OnShowMessage.Invoke(mo);
        }

        /// <summary>
        /// 完成的消息
        /// </summary>
        internal void CompleteMessage(string Id)
        {

        }
    }
}
