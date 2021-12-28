using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 输入框
    /// </summary>
    public partial class FInput<TValue> : ACInuptComponentBase<TValue>
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "input";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Loading).ToLowerInvariant(), () => Loading)
                .If(nameof(Error).ToLowerInvariant(), () => Error)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Action).ToLowerInvariant(), () => Action)
                .If(nameof(Transparent).ToLowerInvariant(), () => Transparent)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .GetIf(() => $"{(IconLeft ? "left " : string.Empty)}icon", () => Icon || IconLeft)
                .GetIf(() => $"labeled", () => Labeled)
                .GetIf(() => $"right labeled", () => LabeledRight)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        /// <summary>
        /// 输入框内容
        /// </summary>
        private string _inputValue => string.IsNullOrEmpty(Format) ? Value?.ToString() ?? string.Empty : Formatter<TValue>.Format(Value, Format);

        /// <summary>
        /// 输入框
        /// </summary>
        internal ElementReference InputElement;

        #region Parameter        

        /// <summary>
        /// 在Top下面的内容
        /// </summary>
        [Parameter]
        public RenderFragment<TValue> TopContent { get; set; }

        /// <summary>
        /// 在Input下面的内容
        /// </summary>
        [Parameter]
        public RenderFragment<TValue> BottomContent { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [Parameter]
        public int? Max { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        [Parameter]
        public int? Min { get; set; }

        /// <summary>
        /// 加载
        /// 一个图标输入字段可以显示它正在加载数据
        /// An icon input field can show that it is currently loading data
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 使用图标
        /// 输入可以用图标进行格式化
        /// An input can be formatted with an icon
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }

        /// <summary>
        /// 使图标在左边
        /// </summary>
        [Parameter]
        public bool IconLeft { get; set; }

        /// <summary>
        /// 使用标签
        /// 输入可以用标签进行格式化
        /// An input can be formatted with a label
        /// </summary>
        [Parameter]
        public bool Labeled { get; set; }

        /// <summary>
        /// 标签在右边
        /// </summary>
        [Parameter]
        public bool LabeledRight { get; set; }

        /// <summary>
        /// 错误
        /// 输入字段可以显示数据包含错误
        /// An input field can show the data contains errors
        /// </summary>
        [Parameter]
        public bool Error { get; set; }

        /// <summary>
        /// 流体
        /// 输入可以取其容器的大小
        /// An input can take the size of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 行动
        /// 可以对输入进行格式化，以提醒用户可能执行的操作
        /// An input can be formatted to alert the user to an action they may perform
        /// </summary>
        [Parameter]
        public bool Action { get; set; }

        /// <summary>
        /// 透明
        /// 透明的输入没有背景
        /// A transparent input has no background
        /// </summary>
        [Parameter]
        public bool Transparent { get; set; }

        /// <summary>
        /// 翻转
        /// 输入可以被格式化以显示在黑色背景上
        /// An input can be formatted to appear on dark backgrounds
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 快速响应 (当输入时就触发改变事件，原先需要失去焦点)
        /// </summary>
        [Parameter]
        public bool QuickResponse { get; set; }

        /// <summary>
        /// 输入框类型
        /// </summary>
        [Parameter]
        public EnumMix<FInputType> InputType { get; set; } = FInputType.Text;

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 加载事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> LoadingChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<TValue> OnValueChange { get; set; }

        /// <summary>
        /// 按Enter键
        /// </summary>
        [Parameter]
        public EventCallback<KeyboardEventArgs> OnEnter { get; set; }

        /// <summary>
        /// 处理 OnChange
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task OnChangeAsync(ChangeEventArgs args)
        {
            var value = args.Value != null ? args.Value.ToString() : string.Empty;
            if (Max != null && value.Length > Max)
            {
                value = new string(value.Take((int)Max).ToArray());
            }
            if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TValue parsedValue))
            {
                if (Value?.Equals(parsedValue) ?? false)
                    return;
                Value = parsedValue;
                if (OnValueChange.HasDelegate)
                {
                    await OnValueChange.InvokeAsync(Value);
                }
            }
            //await JsInvokeAsync("ac.setInputValue", InputElement, _inputValue);
            //await InputElement.Val<TValue>(parsedValue);
        }

        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task OnKeyupAsync(KeyboardEventArgs args)
        {
            if (args != null && args.Key == "Enter")
            {
                await OnEnter.InvokeAsync(args);
            }
        }

        /// <summary>
        /// 输入
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task OnInputAsync(ChangeEventArgs args)
        {
            if (QuickResponse)
            {
                await OnChangeAsync(args);
            }
        }

        /// <summary>
        /// 聚焦
        /// </summary>
        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (typeof(TValue) == typeof(DateTime) && string.IsNullOrEmpty(Format))
            {
                Format = "yyyy-MM-ddThh:mm:ss";
            }
        }

        #endregion
    }
}
