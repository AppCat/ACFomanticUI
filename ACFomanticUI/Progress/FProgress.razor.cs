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
    /// 进度条
    /// 进度条显示任务的进度
    /// A progress bar shows the progression of a task.
    /// </summary>
    public partial class FProgress : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "progress";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
                .Add(_prefix)
                .If("active", () => Active)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Status.ToClass(), () => Status != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => $"{Attached.ToClass()} attached", () => Attached != null)
                .Add(_suffix)
                ;

            BarStyleMapper.Clear()
            .Add("min-width: 4px;")
            .Add("transition-duration: 300ms;")
            .Add("display: block;")
            .Get(() => $"width: { _percent * 100}%;")
            .Get(() => BarConfig?.AsStyle)
            ;

            BarClassMapper.Clear()
            .Add("bar")
            .Get(() => BarConfig?.AsClass)
            ;

            LabelStyleMapper.Clear()
            .Get(() => LabelConfig?.AsStyle)
            ;

            LabelClassMapper.Clear()
            .Add("label")
            .Get(() => LabelConfig?.AsClass)
            ;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// 百分比
        /// </summary>
        private double _percent { get; set; } = 0;

        /// <summary>
        /// 条样式
        /// </summary>
        protected Mapper BarStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 条类
        /// </summary>
        protected Mapper BarClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 标签样式
        /// </summary>
        protected Mapper LabelStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 标签类
        /// </summary>
        protected Mapper LabelClassMapper { get; set; } = new Mapper();

        #region CascadingParameter

        /// <summary>
        /// 完成时间
        /// </summary>
        [CascadingParameter]
        private DateTime CompleteTime { get; set; } = DateTime.MinValue;

        #endregion

        #region Parameter 

        /// <summary>
        /// 显示内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig BarConfig { get; set; }

        /// <summary>
        /// 显示内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig LabelConfig { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [Parameter]
        public uint? MaxValue { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        [Parameter]
        public uint? CurrentValue
        {
            get => _currentValue; set
            {
                if (_currentValue != value)
                {
                    _currentValue = value;
                    HandlePercent();
                }
            }
        }
        private uint? _currentValue;

        /// <summary>
        /// 进度条可以包含指示当前进度的文本值
        /// A progress bar can contain a text value indicating current progress
        /// </summary>
        [Parameter]
        public bool Progress { get; set; }

        /// <summary>
        /// 标签
        /// 进度条可以包含一个标签
        /// A progress element can contain a label
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// 标签内容
        /// 进度条可以包含一个标签
        /// A progress element can contain a label
        /// </summary>
        [Parameter]
        public RenderFragment<double> LabelContent { get; set; }

        /// <summary>
        /// 活跃的
        /// A progress bar can show activity
        /// 进度条可以显示活动
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        /// <summary>
        /// 颠倒
        /// A progress bar can have its colors inverted
        /// 进度条的颜色可以颠倒
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 进度条状态
        /// </summary>
        [Parameter]
        public FProgressStatus? Status { get; set; }

        /// <summary>
        /// 依附
        /// 进度条可以显示元素的进度
        /// A progress bar can show progress of an element
        /// 仅支持 Top, Bottom
        /// </summary>
        [Parameter]
        public FAttached? Attached { get; set; }

        /// <summary>
        /// 尺寸
        /// 进度条的大小可以不同
        /// A progress bar can vary in size
        /// 仅支持 Tiny, Small, Large, Big
        /// </summary>
        [Parameter]
        public FSize? Size { get; set; }

        /// <summary>
        /// 颜色
        /// 进度条可以有不同的颜色
        /// Can have different colors
        /// </summary>
        [Parameter]
        public FColored? Colored { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 状态变化
        /// </summary>
        [Parameter]
        public EventCallback<FProgressStatus?> StatusChanged { get; set; }

        /// <summary>
        /// 进度条完成事件
        /// </summary>
        [Parameter]
        public EventCallback OnComplete { get; set; }

        #endregion

        /// <summary>
        /// 百分比
        /// </summary>
        private void HandlePercent()
        {
            _percent = (double)CurrentValue / (double)MaxValue;
            if (CurrentValue > MaxValue)
                _percent = 1;
            if (_percent >= 1)
            {
                Status = FProgressStatus.Success;
                StatusChanged.InvokeAsync(Status);
                OnComplete.InvokeAsync();
            }
            else
            {
                if(Status == FProgressStatus.Success)
                {
                    Status = null;
                }
            }
            //JsInvokeAsync("jqfunc.width", $"{Id}_bar", $"{_percent * 100}%").ConfigureAwait(false);
        }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if(CompleteTime != DateTime.MinValue && MaxValue == null && CurrentValue == null)
            {
                _timer = new Timer(5);
                MaxValue = (uint)(CompleteTime - DateTime.Now).TotalMilliseconds;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(_percent >= 1)
            {
                CurrentValue = MaxValue;
                InvokeAsync(StateHasChanged);
                _timer.Stop();
                _timer.Dispose();
            }
            else
            {
                CurrentValue = (MaxValue) - (uint)(CompleteTime - DateTime.Now).TotalMilliseconds;
            }
            InvokeAsync(StateHasChanged);
        }

        #endregion
    }
}
