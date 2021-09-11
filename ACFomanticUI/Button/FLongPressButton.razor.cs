using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 长按按钮
    /// </summary>
    public partial class FLongPressButton : FButton
    {
        /// <summary>
        /// 目标时间
        /// </summary>
        protected DateTime Terminus { get; set; }

        /// <summary>
        /// 计时Task
        /// </summary>
        protected Task TimeTask { get; set; }

        /// <summary>
        /// 计时Task 取消源
        /// </summary>
        protected CancellationTokenSource TokenSource = null;

        /// <summary>
        /// 是否上台
        /// </summary>
        protected bool IsMouseup { get; set; } = false;

        #region Parameter 

        /// <summary>
        /// 按下停止传播
        /// </summary>
        [Parameter]
        public bool OnMousedownStopPropagation { get; set; } = true;

        /// <summary>
        /// 点击松开传播
        /// </summary>
        [Parameter]
        public bool OnMouseupStopPropagation { get; set; } = true;

        /// <summary>
        /// 停止点击
        /// </summary>
        [Parameter]
        public bool OnClickStop { get; set; } = true;

        /// <summary>
        /// 延时
        /// 默认500
        /// </summary>
        [Parameter]
        public int Delay { get; set; } = 500;

        /// <summary>
        /// 延时
        /// </summary>
        [Parameter]
        public TimeSpan? DelayTimeSpan { get; set; }

        /// <summary>
        /// 进度条样式
        /// </summary>
        [Parameter]
        public string ProgressStyle { get; set; }

        /// <summary>
        /// 进度条类
        /// </summary>
        [Parameter]
        public string ProgressClass { get; set; }

        /// <summary>
        /// 进度条颜色
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  ProgressColored { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (!OnClickStop)
                return base.HandleOnClickAsync(args);
            else
                return Task.CompletedTask;
        }

        /// <summary>
        /// 处理鼠标按钮被按下。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMousedownAsync(MouseEventArgs args)
        {
            await Run(args);
        }

        /// <summary>
        /// 处理鼠标按键被松开。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMouseupAsync(MouseEventArgs args)
        {
            await Cancel();
        }

        /// <summary>
        /// 处理鼠标移走
        /// </summary>
        /// <param name="args"></param>
        protected async Task HandleOnMouseoutAsync(FocusEventArgs args)
        {
            await Cancel();
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="args"></param>
        protected virtual async Task Run(MouseEventArgs args)
        {
            if (Loading)
                return;
            IsMouseup = false;
            await InvokeStateHasChangedAsync();
            var delay = DelayTimeSpan ?? TimeSpan.FromMilliseconds(Delay);
            Terminus = DateTime.Now.Add(delay);
            TokenSource = new CancellationTokenSource(delay);
            var totalMilliseconds = delay.TotalMilliseconds;
            TimeTask?.Dispose();
            TimeTask = Task.Run(async () =>
            {
                while (DateTime.Now < Terminus && !TokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1);
                }
                if (!IsMouseup)
                {
                    await InvokeStateHasChangedAsync();
                    await Click(args);
                    await Cancel();
                }
            }, TokenSource.Token);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 取消
        /// </summary>
        protected virtual async Task Cancel()
        {
            if (Loading)
                return;
            IsMouseup = true;
            TokenSource?.Cancel();
            Terminus = DateTime.MinValue;
            await InvokeStateHasChangedAsync();
        }
    }
}
