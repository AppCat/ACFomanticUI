using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 消息
    /// 消息显示解释附近内容的信息
    /// A message displays information that explains nearby content
    /// </summary>
    public partial class FMessage : ACComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "message";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("icon", () => !string.IsNullOrEmpty(Icon))
                .GetIf(() => Visibility.ToClass(), () => Visibility != null)
                .GetIf(() => $"{Attached.ToClass()} attached", () => Attached != null)
                .GetIf(() => Type.ToClass(), () => Type != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .If(nameof(Floating).ToLowerInvariant(), () => Floating)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .Add(_suffix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                ;

            ContentClassMapper.Clear()
            .Add("content")
            .Get(() => ContentConfig?.AsStyle)
            ;

            ContentStyleMapper.Clear()
            .Get(() => ContentConfig?.AsClass)
            ;

            HeaderClassMapper.Clear()
            .Add("header")
            .Get(() => HeaderConfig?.AsStyle)
            ;

            HeaderStyleMapper.Clear()
            .Get(() => HeaderConfig?.AsClass)
            ;

            MessageClassMapper.Clear()
            .Get(() => MessageConfig?.AsStyle)
            ;

            MessageStyleMapper.Clear()
            .Get(() => MessageConfig?.AsClass)
            ;

            MessageListClassMapper.Clear()
            .Add("list")
            .Get(() => MessageListConfig?.AsStyle)
            ;

            MessageListStyleMapper.Clear()
            .Get(() => MessageListConfig?.AsClass)
            ;
        }

        /// <summary>
        /// 内容样式 映射
        /// </summary>
        protected Mapper ContentStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 内容类 映射
        /// </summary>
        protected Mapper ContentClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 头样式 映射
        /// </summary>
        protected Mapper HeaderStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 头类 映射
        /// </summary>
        protected Mapper HeaderClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 消息样式 映射
        /// </summary>
        protected Mapper MessageStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 消息类 映射
        /// </summary>
        protected Mapper MessageClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 消息列表样式 映射
        /// </summary>
        protected Mapper MessageListStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 消息列表类 映射
        /// </summary>
        protected Mapper MessageListClassMapper { get; set; } = new Mapper();

        #region Parameter 

        /// <summary>
        /// 内容配置
        /// </summary> 
        [Parameter]
        public ACComponentConfig ContentConfig { get; set; }

        /// <summary>
        /// 头配置
        /// </summary>
        [Parameter]
        public ACComponentConfig HeaderConfig { get; set; }

        /// <summary>
        /// 消息配置
        /// </summary>
        [Parameter]
        public ACComponentConfig MessageConfig { get; set; }

        /// <summary>
        /// 消息列表配置
        /// </summary>
        [Parameter]
        public ACComponentConfig MessageListConfig { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string Header { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [Parameter]
        public string Message { get; set; }

        /// <summary>
        /// 消息列表
        /// 带有列表的消息
        /// A message with a list
        /// </summary>
        [Parameter]
        public string[] MessageList { get; set; }

        /// <summary>
        /// 图标
        /// 一条消息可以包含一个图标。
        /// A message can contain an icon.
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// 加载
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 可关闭
        /// 用户可以选择隐藏的消息
        /// A message that the user can choose to hide
        /// </summary>
        [Parameter]
        public bool DismissableBlock { get; set; }

        /// <summary>
        /// 浮动
        /// 消息可以浮在与之相关的内容之上
        /// A message can float above content that it is related to
        /// </summary>
        [Parameter]
        public bool Floating { get; set; }

        /// <summary>
        /// 紧凑
        /// 消息只能占用其内容的宽度。
        /// A message can only take up the width of its content.
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 能见度
        /// 可以将消息设置为可见，以强制显示其本身。
        /// 信息可以被隐藏
        /// A message can be set to visible to force itself to be shown.
        /// A message can be hidden
        /// </summary>
        [Parameter]
        public EnumMix<FVisibility> Visibility { get; set; }

        /// <summary>
        /// 依附
        /// 可以对消息进行格式化，以便将其附加到其他内容
        /// A message can be formatted to attach itself to other content
        /// 仅支持 Top, Bottom
        /// </summary>
        [Parameter]
        public EnumMix<FAttached> Attached { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [Parameter]
        public EnumMix<FMessageType> Type { get; set; }

        /// <summary>
        /// 颜色
        /// A message can be formatted to be different colors
        /// 消息可以被格式化为不同的颜色
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 尺寸
        /// A message can have different sizes
        /// 消息可以有不同的大小
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 退出事件
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 处理 Close 点击
        /// </summary>
        public async Task HandleCloseClick()
        {
            Visibility = FVisibility.Hidden;
            await OnClose.InvokeAsync();
        }

        #endregion
    }
}
