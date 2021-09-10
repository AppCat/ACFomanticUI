using ACUI.Shared.Core.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 搜索
    /// </summary>
    public partial class FSearch : FInput<string>, IFResultContainer
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "ui search";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Focus).ToLowerInvariant(), () => Focus)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                ;
        }

        /// <summary>
        /// 是否聚焦
        /// </summary>
        protected bool Focus { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        protected Dictionary<string, IFResult> Results = new();

        /// <summary>
        /// 选中的结果
        /// </summary>
        protected IFResult SelectedResult { get; set; }

        /// <summary>
        /// 显示结果
        /// </summary>
        protected bool VisibleResults { get; set; }

        /// <summary>
        /// 导航管理器
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// 结果源
        /// </summary>
        protected IFResult[] ResultsSource { get; set; }

        /// <summary>
        /// 输入框
        /// </summary>
        protected FInput<string> _input { get; set; }

        #region Parameter        

        /// <summary>
        /// 选中的结果键
        /// </summary>
        [Parameter]
        public string SelectedResultKey
        {
            get => _selectedResultKey; set
            {
                if (value == _selectedResultKey)
                    return;
                var notifyKeys = new string[] { value, _selectedResultKey };
                _selectedResultKey = value;
                NotifyResultStateHasChanged(notifyKeys);
            }
        }
        private string _selectedResultKey;

        /// <summary>
        /// 结果模板
        /// </summary>
        [Parameter]
        public RenderFragment<IFResult> ResultTemplate { get; set; }

        /// <summary>
        /// 停止导航
        /// </summary>
        [Parameter]
        public bool StopNavigate { get; set; }

        /// <summary>
        /// 聚焦搜索
        /// 聚焦时出发搜索
        /// </summary>
        [Parameter]
        public bool FocusSearch { get; set; } = true;

        /// <summary>
        /// 消息空结果模板
        /// </summary>
        [Parameter]
        public RenderFragment<string> MessageEmptyTemplate { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 响应
        /// </summary>
        [Parameter]
        public Func<string, Task<IFResult[]>> OnResponse { get; set; }

        /// <summary>
        /// 选中的结果键变化 用于@bind
        /// </summary>
        [Parameter]
        public EventCallback<string> SelectedResultKeyChanged { get; set; }

        /// <summary>
        /// 选中的结果键变化
        /// </summary>
        [Parameter]
        public EventCallback<string> OnSelectedResultKeyChange { get; set; }

        /// <summary>
        /// 选中的结果
        /// </summary>
        [Parameter]
        public EventCallback<IFResult> OnSelectedResult { get; set; }

        /// <summary>
        /// 点击的结果
        /// </summary>
        [Parameter]
        public EventCallback<IFResult> OnClickResult { get; set; }

        /// <summary>
        /// 搜索事件
        /// </summary>
        [Parameter]
        public EventCallback<string> OnSearch { get; set; }

        /// <summary>
        /// 显示结果事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnVisibleResult { get; set; }

        /// <summary>
        /// 处理 OnValueChange
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected async Task HandleValueChangeAsync(string value)
        {
            if (value == Value)
                return;
            Value = value;
            if (OnValueChange.HasDelegate)
            {
                await OnValueChange.InvokeAsync(value);
            }
            await JsInvokeAsync("ac.setInputValue", _input.InputElement, Value);
            StateHasChanged();
        }

        /// <summary>
        /// 处理 聚焦
        /// </summary>
        /// <returns></returns>
        protected void HandelFocusin() => Focus = true;

        /// <summary>
        /// 处理 散焦
        /// </summary>
        /// <returns></returns>
        protected void HandelFocusout() => Focus = false;

        /// <summary>
        /// 处理 输入框 回车
        /// </summary>
        /// <returns></returns>
        protected async Task HandleInputEnterAsync(KeyboardEventArgs args)
        {
            await SearchAsync();
            await OnEnter.InvokeAsync(args);
        }

        /// <summary>
        /// 处理 输入框 聚焦
        /// </summary>
        /// <returns></returns>
        protected async Task HandleInputFocusAsync(FocusEventArgs args)
        {
            if (FocusSearch)
                await SearchAsync();
            await OnFocus.InvokeAsync(args);
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            DocumentClick += HandleExternalClick;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            DocumentClick -= HandleExternalClick;
        }

        #endregion

        /// <summary>
        /// 搜索
        /// </summary>
        /// <returns></returns>
        public async Task SearchAsync()
        {
            if (Loading || string.IsNullOrEmpty(Value))
                return;
            var olb = Value;
            Loading = true;
            await LoadingChanged.InvokeAsync(Loading);
            if (OnSearch.HasDelegate)
            {
                await OnSearch.InvokeAsync(Value);
            }
            if (OnResponse != null)
            {
                ResultsSource = await OnResponse.Invoke(Value);
            }
            Loading = false;
            await LoadingChanged.InvokeAsync(Loading);
            if (!VisibleResults)
                Show();
            else
                StateHasChanged();
            if (olb != Value)
                await SearchAsync();
        }

        /// <summary>
        /// 添加结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool AddResult(IFResult result)
        {
            if (result == null || string.IsNullOrEmpty(result.Key))
                return false;
            var key = result.Key;
            if (Results.ContainsKey(key))
            {
                Results[key] = result;
            }
            return Results.TryAdd(key, result) || Results[key] == result;
        }

        /// <summary>
        /// 选中结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public async Task SelectedResultAsync(IFResult result, bool isClick = false)
        {
            if (result != null || !string.IsNullOrEmpty(result.Key) || result.Key != SelectedResultKey)
            {
                await HandleValueChangeAsync(result.Title);
                SelectedResult = result;
                SelectedResultKey = result.Key;
                await SelectedResultKeyChanged.InvokeAsync(SelectedResultKey);
                await OnSelectedResultKeyChange.InvokeAsync(SelectedResultKey);
                await OnSelectedResult.InvokeAsync(result);
            }
            if (isClick)
                await OnClickResult.InvokeAsync(result);
            Hide();
            if (!StopNavigate && !string.IsNullOrEmpty(result.Url))
            {
                NavigationManager.NavigateTo(result.Url);
            }
        }

        /// <summary>
        /// 结果是否选中
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ResultIsSelected(IFResult result)
        {
            if (result == null)
                return false;
            return result.Key == SelectedResultKey;
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            if (VisibleResults)
                return;
            VisibleResults = true;
            StateHasChanged();
            OnVisibleResult.InvokeAsync(VisibleResults).Wait();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide()
        {
            if (!VisibleResults)
                return;
            VisibleResults = false;
            StateHasChanged();
            OnVisibleResult.InvokeAsync(VisibleResults).Wait();
        }

        /// <summary>
        /// 通知项目状态变化
        /// </summary>
        /// <param name="notifyKeys"></param>
        protected virtual void NotifyResultStateHasChanged(string[] notifyKeys = null)
        {
            if (Results == null && Results.Count <= 0)
                return;
            notifyKeys ??= Results.Select(kv => kv.Key).ToArray();
            notifyKeys.Where(nk => !string.IsNullOrEmpty(nk))
                .Where(nk => Results.ContainsKey(nk))
                .Select(nk => Results[nk])
                .ForEach(item => item.NotifyStateHasChanged());
        }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        protected void HandleExternalClick(ClickElement[] path)
        {
            if (!VisibleResults)
                return;
            if (path.Any(e => e.Id == _input?.Id)) // 包含自己不隐藏
                return;
            if (!VisibleResults)
                return;
            InvokeAsync(() =>
            {
                Hide();
            });
        }
    }
}
