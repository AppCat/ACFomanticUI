using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 通知选项
    /// </summary>
    public class FMessageOptions
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        internal string Id { get; }

        /// <summary>
        /// 头
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public EnumMix<FMessageType> Type { get; set; } = FMessageType.Info;

        /// <summary>
        /// 颜色
        /// A message can be formatted to be different colors
        /// 消息可以被格式化为不同的颜色
        /// </summary>
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 尺寸
        /// A message can have different sizes
        /// 消息可以有不同的大小
        /// </summary>
        public EnumMix<FSize> Size { get; set; } = FSize.Mini;

        /// <summary>
        /// 层叠值
        /// </summary>
        public int Zindex { get; set; } = 99;

        /// <summary>
        /// 退出延时 (毫秒)
        /// </summary>
        public int TimeDelay
        {
            get => _timeDelay;
            set
            {
                Expiration = Expiration.AddMilliseconds(value - _timeDelay);
                _timeDelay = value;
            }
        }
        private int _timeDelay = 5000;

        /// <summary>
        /// 过期时间
        /// </summary>
        internal DateTime Expiration { get; private set; }

        /// <summary>
        /// 通知选项
        /// </summary>
        public FMessageOptions()
        {
            Expiration = DateTime.Now.AddMilliseconds(TimeDelay);
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static FMessageOptions Warning(string message, string header = null) => new FMessageOptions
        {
            Type = FMessageType.Warning,
            Message = message,
            Header = header
        };

        /// <summary>
        /// 信息
        /// </summary>
        public static FMessageOptions Info(string message, string header = null) => new FMessageOptions
        {
            Type = FMessageType.Info,
            Message = message,
            Header = header
        };

        /// <summary>
        /// 成功
        /// </summary>
        public static FMessageOptions Success(string message, string header = null) => new FMessageOptions
        {
            Type = FMessageType.Success,
            Message = message,
            Header = header
        };

        /// <summary>
        /// 成功
        /// </summary>
        public static FMessageOptions Error(string message, string header = null) => new FMessageOptions
        {
            Type = FMessageType.Error,
            Message = message,
            Header = header
        };
    }
}
