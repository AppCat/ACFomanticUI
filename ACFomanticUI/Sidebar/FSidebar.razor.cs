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
    /// 边栏
    /// 侧边栏隐藏了页面旁边的附加内容。
    /// A sidebar hides additional content beside a page.
    /// </summary>
    public partial class FSidebar : ACContentComponentBase
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
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
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

        #region Parameter

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
        /// 自动隐藏
        /// 点击其他 标签元素 时会自动隐藏
        /// </summary>
        [Parameter]
        public bool AutoHide { get; set; }

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
        /// 显示
        /// 在页面上可以看到一个边栏
        /// A sidebar can be visible on the page
        /// </summary>
        [Parameter]
        public EventCallback<bool> VisibleChanged { get; set; }

        /// <summary>
        /// 隐藏事件
        /// </summary>
        [Parameter]
        public EventCallback OnHide { get; set; }

        /// <summary>
        /// 显示事件
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 处理外部点击
        /// </summary>
        private void HandleExternalClick(ClickElement[] path)
        {
            if (!Visible || !AutoHide)
                return;
            lock (_visibleLock)
            {
                if (path.Any(e => e.Id == Id)) // 包含自己不隐藏
                    return;
                if (!Visible)
                    return;
                InvokeAsync(() =>
                {
                    Hide();
                });
            }
        }

        #endregion

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            if (Visible)
                return;
            Visible = true;
            if (Visible)
                VisibleChanged.InvokeAsync(Visible).Wait();
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide()
        {
            if (!Visible)
                return;
            Visible = false;
            if (!Visible)
                VisibleChanged.InvokeAsync(Visible).Wait();
            StateHasChanged();
        }

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

        #region Abandon

        new bool Disabled { get; set; }

        #endregion
    }
}
