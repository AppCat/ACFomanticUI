using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 消息管理器
    /// </summary>
    public partial class NotificationManager : ComponentBase
    {
        /// <summary>
        /// 通知服务
        /// </summary>
        [Inject]
        private ACFNotificationService _notificationService { get; set; }

        /// <summary>
        /// 消息列表
        /// </summary>
        private IList<FMessageOptions> _optionsList = new List<FMessageOptions>();

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer _timer = new Timer(10);

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (_notificationService != null)
            {
                _notificationService.OnShowMessage += HandleShowMessage;
            }
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }
        
        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var expirations = _optionsList.Where(o => o.Expiration <= DateTime.Now);
            if (expirations.Any())
            {
                foreach (var item in expirations)
                {
                    _optionsList.Remove(item);
                    InvokeAsync(StateHasChanged);
                }
            }
        }

        /// <summary>
        /// 处理消息显示
        /// </summary>
        /// <param name="options"></param>
        private void HandleShowMessage(FMessageOptions options)
        {
            _optionsList.Add(options);
            InvokeAsync(StateHasChanged);
        }
    }
}
