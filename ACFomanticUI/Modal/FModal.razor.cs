using ACUI.FomanticUI.JS;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 模态
    /// 模态显示临时阻止与网站主视图交互的内容
    /// A modal displays content that temporarily blocks interactions with the main view of a site
    /// </summary>
    public partial class FModal : ACContentComponentBase, IFModal
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "modal";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Basic).ToLowerInvariant(), () => Basic)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Fullscreen).ToLowerInvariant(), () => Fullscreen)
                .If($"overlay fullscreen", () => Overlay)
                .GetIf(() => Size.ToClass(), () => Size != null)
                //.If("disabled", () => Disabled)
                .Add(_suffix)
                ;           
        }

        /// <summary>
        /// modal JS 模块
        /// </summary>
        [Inject]
        protected ModalJS ModalJS { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        private FModal _template { get; set; }

        #region Parameter  

        /// <summary>
        /// 基本
        /// 模态可以降低其复杂性
        /// A modal can reduce its complexity
        /// </summary>
        [Parameter]
        public bool Basic { get; set; }

        /// <summary>
        /// 翻转
        /// 占位符的颜色可以颠倒。
        /// A placeholder can have their colors inverted.
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 一个模态可以使用整个屏幕的大小
        /// A modal can use the entire size of the screen
        /// </summary>
        [Parameter]
        public bool Fullscreen { get; set; }

        /// <summary>
        /// 一个模态可以覆盖整个屏幕
        /// A modal can overlay the entire screen
        /// </summary>
        [Parameter]
        public bool Overlay { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 模态 设置
        /// </summary>
        [Parameter]
        public FModalSettings Settings { get; set; } = new FModalSettings();

        /// <summary>
        /// 模板设置
        /// </summary>
        [Parameter]
        public FMTemplateSettings TemplateSettings { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 在按下否定、拒绝或取消按钮后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a negative, deny or cancel button is pressed. If the function returns false the modal will not hide.
        /// </summary>
        [Parameter]
        public Func<Task<bool>> OnDeny { get; set; }

        /// <summary>
        /// 在模态开始隐藏后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a modal starts to hide. If the function returns false, the modal will not hide.
        /// </summary>
        [Parameter]
        public Func<Task<bool>> OnHide { get; set; }

        /// <summary>
        /// 在按下肯定、批准或ok按钮后调用。如果函数返回false，则不会隐藏模态。
        /// Is called after a positive, approve or ok button is pressed. If the function returns false, the modal will not hide.
        /// </summary>
        [Parameter]
        public Func<Task<bool>> OnApprove { get; set; }

        /// <summary>
        /// 在模态开始显示时调用。
        /// Is called when a modal starts to show.
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 在模态完成动画显示后调用。
        /// Is called after a modal has finished showing animating.
        /// </summary>
        [Parameter]
        public EventCallback OnVisible { get; set; }

        /// <summary>
        /// 在模态完成隐藏动画后调用。
        /// Is called after a modal has finished hiding animation.
        /// </summary>
        [Parameter]
        public EventCallback OnHidden { get; set; }

        /// <summary>
        /// 处理回调
        /// </summary>
        /// <param name="args"></param>
        protected void HandleCallback(CallbackEventArgs args)
        {
            if (args.Name == "onShow")
            {
                OnShow.InvokeAsync();
            }
            else if (args.Name == "onVisible")
            {
                OnVisible.InvokeAsync();
            }
            else if (args.Name == "onHidden")
            {
                OnHidden.InvokeAsync();
            }
        }

        #endregion

        #region SDLC

        private FModalSettings _settings;
        private Func<Task<bool>> _onDeny;
        private Func<Task<bool>> _onHide;
        private Func<Task<bool>> _onApprove;
        //private FMTemplateSettings _templateSettings;

        /// <summary>
        /// 属性设置
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            if (_settings != Settings)
            {
                _settings = Settings;
                await ModalJS.Set(this);
            }
            //if (_templateSettings != TemplateSettings)
            //{
            //    _templateSettings = TemplateSettings;
            //    await ModalJS.Set(this);
            //}

            //if (OnDeny != null && !OnDenyDic.ContainsKey(Id))
            //{
            //    OnDenyDic.TryAdd(Id, OnDeny);
            //}

            if(OnDeny != _onDeny)
            {
                OnDenyDic.Remove(Id);
                _onDeny = OnDeny;
                OnDenyDic.TryAdd(Id, OnDeny);
            }
            if (OnHide != _onHide)
            {
                OnHideDic.Remove(Id);
                _onDeny = _onHide;
                OnHideDic.TryAdd(Id, OnHide);
            }
            if (OnApprove != _onApprove)
            {
                OnApproveDic.Remove(Id);
                _onDeny = _onApprove;
                OnApproveDic.TryAdd(Id, OnApprove);
            }

            if (OnShow.HasDelegate || OnVisible.HasDelegate || OnHidden.HasDelegate)
            {
                ModalCallback += HandleCallback;
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            OnDenyDic.Remove(Id);
            OnHideDic.Remove(Id);
            OnApproveDic.Remove(Id);

            ModalCallback -= HandleCallback;
        }

        #endregion

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task ShowAsync()
        {
            if(_template != null)
            {
                await _template.ShowAsync();
            }
            else
            {
                await ModalJS.ShowAsync(this);
            }
        }

        #region JSInvokable

        /// <summary>
        /// 
        /// </summary>
        protected static IDictionary<string, Func<Task<bool>>> OnDenyDic { get; } = new Dictionary<string, Func<Task<bool>>>();

        /// <summary>
        /// 
        /// </summary>
        protected static IDictionary<string, Func<Task<bool>>> OnHideDic { get; } = new Dictionary<string, Func<Task<bool>>>();

        /// <summary>
        /// 
        /// </summary>
        protected static IDictionary<string, Func<Task<bool>>> OnApproveDic { get; } = new Dictionary<string, Func<Task<bool>>>();


        /// <summary>
        /// 模态回调 点击
        /// </summary>
        protected static event Action<CallbackEventArgs> ModalCallback;

        /// <summary>
        /// 处理 模态回调
        /// </summary>
        [JSInvokable]
        public static async Task<bool?> HandleModalCallbackAsync(CallbackEventArgs args)
        {
            try
            {
                switch (args.Name)
                {
                    case "onHide":
                        {
                            if (OnHideDic.TryGetValue(args.Id, out Func<Task<bool>> handler))
                            {
                                return await handler?.Invoke();
                            }
                        }
                        break;
                    case "onDeny":
                        {
                            if (OnDenyDic.TryGetValue(args.Id, out Func<Task<bool>> handler))
                            {
                                return await handler?.Invoke();
                            }
                        }
                        break;
                    case "onApprove":
                        {
                            if (OnApproveDic.TryGetValue(args.Id, out Func<Task<bool>> handler))
                            {
                                return await handler?.Invoke();
                            }
                        }
                        break;
                    case "onShow":
                    case "onVisible":
                    case "onHidden":
                        ModalCallback?.Invoke(args);
                        return null;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
            }
            return null;
        }

        #endregion
    }
}
