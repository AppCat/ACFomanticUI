using ACUI.FomanticUI.JS;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 边栏
    /// 侧边栏隐藏了页面旁边的附加内容。
    /// A sidebar hides additional content beside a page.
    /// </summary>
    public partial class FSidebar : ACContentComponentBase, IFSidebar
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "sidebar";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
                .Add(_prefix)
                .If("animating", () => !Visible)
                .If("inverted vertical menu", () => Inverted)
                .If(nameof(Visible).ToLowerInvariant(), () => Visible)
                .GetIf(() => Direction.ToClass(), () => Direction != null)
                .GetIf(() => Width.ToClass(), () => Width != null)
                .GetIf(() => Mode.ToClass(), () => Mode != null)
                .Add(_suffix)
                ;
        }

        /// <summary>
        /// 显示锁
        /// </summary>
        private object _visibleLock = new object();

        /// <summary>
        /// sidebar JS 模块
        /// </summary>
        [Inject]
        protected SidebarJS SidebarJS { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        protected FSidebar Template { get; set; }

        #region Parameter

        /// <summary>
        /// 模板设置
        /// </summary>
        [Parameter]
        public FSidebarTemplateSettings TemplateSettings { get; set; }

        /// <summary>
        /// 设置
        /// </summary>
        [Parameter]
        public FSidebarSettings Settings { get; set; }

        /// <summary>
        /// 显示
        /// 在页面上可以看到一个边栏
        /// A sidebar can be visible on the page
        /// </summary>
        [Parameter]
        public bool Visible
        {
            get => _visible; set
            {
                lock (_visibleLock)
                {
                    if (_visible == value)
                        return;
                    _visible = value;
                    if (!_visible && OnHide.HasDelegate)
                        OnHide.InvokeAsync();
                    if (_visible && OnShow.HasDelegate)
                        OnShow.InvokeAsync();
                }
            }
        }
        private bool _visible;

        /// <summary>
        /// 颜色翻转
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 方向
        /// 侧边栏可以出现在页面的不同侧面
        /// A sidebar can appear on different sides of the page
        /// </summary>
        [Parameter]
        public EnumMix<FSidebarDirection> Direction { get; set; } = FSidebarDirection.Left;

        /// <summary>
        /// 宽度
        /// 侧边栏可以指定它的宽度
        /// A sidebar can specify its width
        /// </summary>
        [Parameter]
        public EnumMix<FSidebarWidth> Width { get; set; }

        /// <summary>
        /// 模式
        /// </summary>
        [Parameter]
        public EnumMix<FSidebarMode> Mode { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 当侧边栏开始显示动画时调用。
        /// Is called when a sidebar begins animating in.
        /// </summary>
        [Parameter]
        public EventCallback OnVisible { get; set; }

        /// <summary>
        /// 在边栏完成动画时调用。
        /// Is called when a sidebar has finished animating in.
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 当侧边栏开始隐藏或显示时调用。
        /// Is called when a sidebar begins to hide or show
        /// </summary>
        [Parameter]
        public EventCallback OnChange { get; set; }

        /// <summary>
        /// 在侧边栏开始动画输出之前调用。
        /// Is called before a sidebar begins to animate out.
        /// </summary>
        [Parameter]
        public EventCallback OnHide { get; set; }

        /// <summary>
        /// 在边栏完成动画输出后调用。
        /// Is called after a sidebar has finished animating out.
        /// </summary>
        [Parameter]
        public EventCallback OnHidden { get; set; }

        #endregion

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task SettingsAsync(FSidebarSettings settings = null)
        {
            if (Template != null)
            {
                await Template.SettingsAsync(settings);
            }
            else
            {
                if (settings != Settings)
                {
                    _settings = settings;
                    Settings = settings;
                    await SettingsAsync(settings);
                }
                else
                {
                    await SidebarJS.Settings(this, settings);
                }
            }
        }

        /// <summary>
        /// Toggle 异步
        /// </summary>
        /// <returns></returns>
        public async Task ToggleAsync()
        {
            if (Template != null)
            {
                await Template.ToggleAsync();
            }
            else
            {
                await SidebarJS.Toggle(this);
            }
        }

        #region SDLC

        private bool alreadyEvent;
        private FSidebarSettings _settings;

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            await SetSettings();
        }

        /// <summary>
        /// 设置参数后
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            if ((
                OnVisible.HasDelegate ||
                OnShow.HasDelegate ||
                OnChange.HasDelegate ||
                OnHide.HasDelegate ||
                OnHidden.HasDelegate) && !alreadyEvent)
            {
                alreadyEvent = true;
                SidebarCallback += HandleCallback;
            }
            await SetSettings();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <returns></returns>
        protected async Task SetSettings()
        {
            if (_settings != Settings)
            {
                _settings = Settings;
                await SettingsAsync(_settings);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposing || IsDisposed) return;

            base.Dispose(disposing);
            if (alreadyEvent)
            {
                SidebarCallback -= HandleCallback;
            }
        }

        #endregion

        #region Abandon

        new bool Disabled { get; set; }

        #endregion

        /// <summary>
        /// 处理回调
        /// </summary>
        /// <param name="args"></param>
        protected void HandleCallback(CallbackEventArgs args)
        {
            if (args.Name == "onVisible")
            {
                OnVisible.InvokeAsync();
            }
            else if (args.Name == "onShow")
            {
                OnShow.InvokeAsync();
            }
            else if (args.Name == "onChange")
            {
                OnChange.InvokeAsync();
            }
            else if (args.Name == "onHide")
            {
                OnHide.InvokeAsync();
            }
            else if (args.Name == "onHidden")
            {
                OnHidden.InvokeAsync();
            }
        }

        /// <summary>
        /// 边栏回调 点击
        /// </summary>
        protected static event Action<CallbackEventArgs> SidebarCallback;

        #region JSInvokable

        /// <summary>
        /// 处理 边栏回调
        /// </summary>
        [JSInvokable]
        public static void HandleSidebarCallback(CallbackEventArgs args)
        {
            try
            {
                SidebarCallback?.Invoke(args);
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
            }

            #endregion
        }
    }
}
