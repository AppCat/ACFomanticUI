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
    /// 下拉框
    /// </summary>
    public partial class FDropdown : ACListOverlayComponentBase, IControlValueAccessor
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "dropdown";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                .If("floating", () => Floating)
                .If("labeled icon", () => LabeledIcon)
                .If("link item", () => LinkItem)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Selection).ToLowerInvariant(), () => Selection)
                .If(nameof(Search).ToLowerInvariant(), () => Search)
                .If(nameof(Multiple).ToLowerInvariant(), () => Multiple)
                .If(nameof(Button).ToLowerInvariant(), () => Button)
                .If(nameof(Scrolling).ToLowerInvariant(), () => Scrolling)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .If(nameof(Inline).ToLowerInvariant(), () => Inline)
                .If(nameof(Floating).ToLowerInvariant(), () => Floating)
                .If(nameof(Loading).ToLowerInvariant(), () => Loading)
                .If("read-only", () => ReadOnly)
                .GetIf(() => $"active visible", () => Visibility?.Value == FVisibility.Visible)
                .GetIf(() => Pointing.ToClass(), () => Pointing != null)
                //.GetIf(() => Direction.ToClass(), () => Direction != null)
                ;

            TextStyleMapper.Clear()
            .Get(() => TextConfig?.Style)
            ;

            TextClassMapper.Clear()
            .Add("text")
            .GetIf(() => $"default{(string.IsNullOrEmpty(Filtrate) ? "" : " filtered")}", () => (Selection && !IsSelected() && !Inherent))
            .Get(() => TextConfig?.Class)
            ;

            FrameStyleMapper.Clear()
            .Add("min-width: 100px;")
            .Get(() => FrameConfig?.Style)
            ;

            FrameClassMapper.Clear()
            .Add("menu transition")
            .GetIf(() => Visibility.Value.ToString().ToLower(), () => Visibility != null)
            .Get(() => FrameConfig?.Class)
            ;
        }

        /// <summary>
        /// 第一次值
        /// </summary>
        protected string[] FirstSelectedKeys { get; set; }

        /// <summary>
        /// 没结果
        /// </summary>
        private bool _noResults { get; set; }

        /// <summary>
        /// 选择限制
        /// </summary>
        private bool _selectLimit => Multiple && (SelectedKeys?.Length ?? 0) >= MaxMultiple;

        /// <summary>
        /// 搜索输入框
        /// </summary>
        private ElementReference _searchInput;

        /// <summary>
        /// 文本样式 映射
        /// </summary>
        protected Mapper TextStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 文本类 映射
        /// </summary>
        protected Mapper TextClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 框样式 映射
        /// </summary>
        protected Mapper FrameStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 框类 映射
        /// </summary>
        protected Mapper FrameClassMapper { get; set; } = new Mapper();

        #region CascadingParameter

        /// <summary>
        /// 作为Menu子组件的存在
        /// </summary>
        [CascadingParameter(Name = "LinkItem")]
        protected bool LinkItem { get; set; }

        /// <summary>
        /// 表单项组
        /// </summary>
        [CascadingParameter]
        protected IFFieldGroup FieldGroup { get; set; }

        #endregion

        #region Parameter        

        /// <summary>
        /// 文本配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TextConfig { get; set; }

        /// <summary>
        /// 框配置
        /// </summary>
        [Parameter]
        public ACComponentConfig FrameConfig { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Parameter]
        public string Icon { get; set; } = "dropdown";

        /// <summary>
        /// 内容固有 (选取无法改变内容)
        /// </summary>
        [Parameter]
        public bool Inherent { get; set; }

        /// <summary>
        /// 只读
        /// A dropdown can be read-only and does not allow user interaction
        /// 下拉菜单可以是只读的，并且不允许用户交互
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 选择框默认文字
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// 流体
        /// 下拉列表可以取其父列表的全部宽度
        /// A dropdown can take the full width of its parent
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 选择
        /// 下拉菜单可以用来在表单的选项中进行选择
        /// A dropdown can be used to select between choices in a form
        /// </summary>
        [Parameter]
        public bool Selection { get; set; }

        /// <summary>
        /// 搜索
        /// 一个选择下拉菜单可以让用户搜索大量的选项。
        /// A selection dropdown can allow a user to search through a large list of choices
        /// </summary>
        [Parameter]
        public bool Search { get; set; }

        /// <summary>
        /// 按钮
        /// </summary>
        [Parameter]
        public bool Button { get; set; }

        /// <summary>
        /// 滚动条
        /// 下拉菜单可以有滚动菜单
        /// A dropdown can have its menu scroll
        /// </summary>
        [Parameter]
        public bool Scrolling { get; set; }

        /// <summary>
        /// 紧凑
        /// 一个紧凑的下拉菜单没有最小宽度
        /// A compact dropdown has no minimum width
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 内联
        /// 下拉菜单可以被格式化，以内联显示在其他内容中
        /// A dropdown can be formatted to appear inline in other content
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 流动的
        /// 下拉菜单可以显示在元素下面。
        /// A dropdown menu can appear to be floating below an element.
        /// </summary>
        [Parameter]
        public bool Floating { get; set; }

        /// <summary>
        /// 标签图标
        /// </summary>
        [Parameter]
        public bool LabeledIcon { get; set; }

        /// <summary>
        /// 加载
        /// 下拉菜单可以显示当前正在加载数据
        /// A dropdown can show that it is currently loading data
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 能清除
        /// </summary>
        [Parameter]
        public bool CanClear { get; set; } = true;

        /// <summary>
        /// 直指
        /// </summary>
        [Parameter]
        public EnumMix<FPointing> Pointing { get; set; }

        /// <summary>
        /// 尺寸
        /// 设置 Labeled 时有效
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 搜索事件
        /// </summary>
        [Parameter]
        public EventCallback<string> OnSearch { get; set; }

        /// <summary>
        /// Keyboard事件
        /// </summary>
        public EventCallback<KeyboardEventArgs> OnKeyup { get; set; }

        /// <summary>
        /// 图标点击
        /// </summary>
        /// <returns></returns>
        private async Task HandleIconOnClickAsync()
        {
            if (ReadOnly || Disabled)
                return;

            if (CanClear && (SelectedKeys?.Length ?? 0) > 0)
            {
                await Clear();
            }
            else if (Visibility?.Value == FVisibility.Hidden)
            {
                await Show();
            }
            else
            {
                await Hide();
            }
        }

        /// <summary>
        /// 处理 Onblur 失去焦点
        /// </summary>
        /// <returns></returns>
        private async Task HandleOnblurAsync(FocusEventArgs args)
        {
            await Hide();
        }

        /// <summary>
        /// 键盘按键按下
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task HandleDropdownOnKeyupAsync(KeyboardEventArgs args)
        {
            if (Items.Count > 0)
            {
                if (FocusItem != null)
                {
                    switch (args.Key)
                    {
                        case "ArrowUp":
                            FocusItemIndex--;
                            break;
                        case "ArrowDown" when Visibility?.Value == FVisibility.Hidden:
                            await Show();
                            break;
                        case "ArrowDown":
                            FocusItemIndex++;
                            break;
                        case "Enter" when FocusItem != null:
                            await SelectedItemAsync(FocusItem);
                            break;
                    }
                }
                FocusItemIndex = FocusItemIndex < 0 ? 0 : FocusItemIndex >= Items.Count ? Items.Count - 1 : FocusItemIndex;
                await FocusItemAsync(Items.ElementAt(FocusItemIndex).Value);
            }
            await OnKeyup.InvokeAsync(args);
        }

        /// <summary>
        /// 处理下拉框 OnClick
        /// </summary>
        /// <returns></returns>
        private async Task HandleDropdownOnClickAsync()
        {
            if (Search)
            {
                await _searchInput.FocusAsync();
            }
            if (Visibility?.Value != FVisibility.Visible)
                await Show();
            else
                await Hide();
        }

        /// <summary>
        /// 处理搜索栏 OnInput
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task HandleSearchOnInputAsync(ChangeEventArgs args)
        {
            if (!Multiple)
                await Clear();
            Filtrate = args.Value.ToString();
            await OnSearch.InvokeAsync(Filtrate);
            await FiltrateItem();
        }

        /// <summary>
        /// 处理搜索栏 OnClick
        /// </summary>
        /// <returns></returns>
        private async Task HandleSearchOnClickAsync()
        {
            await Show();
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化后
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            FieldGroup?.AddControl(this);
            if (SelectedKeys != null)
            {
                FirstSelectedKeys = SelectedKeys;
            }
            else if (!string.IsNullOrEmpty(DefaultSelectedKey))
            {

            }
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Tabindex ??= -1;
        }

        #endregion

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public override async Task Show()
        {
            await base.Show();
            if (Inherent)
            {
                SelectedKeys = Array.Empty<string>();
            }
        }

        /// <summary>
        /// 筛选项目
        /// </summary>
        /// <returns></returns>
        internal async Task FiltrateItem()
        {
            if (string.IsNullOrEmpty(Filtrate))
            {
                FilteredKeys = Array.Empty<string>();
                _noResults = false;
                return;
            }

            var keys = Items.Values.Where(item => !item.Value.Contains(Filtrate)).Select(item => item.Key);
            FilteredKeys = keys.ToArray();
            _noResults = (FilteredKeys?.Length ?? 0) > 0 && FilteredKeys.Length == Items.Count;

            if (Visibility?.Value == FVisibility.Hidden)
            {
                await Show();
            }
        }

        /// <summary>
        /// 活跃的项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isClick"></param>
        /// <returns></returns>
        public override async Task SelectedItemAsync(IFOverlayItem item, bool isClick = false)
        {
            await base.SelectedItemAsync(item, isClick);
            if (Inherent)
            {
                SelectedKeys = Array.Empty<string>();
            }
            if (!Multiple)
            {
                Filtrate = null;
                await Hide();
            }
            else if (Multiple && (SelectedKeys?.Length ?? 0) >= MaxMultiple)
            {
                //await Hide();
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public virtual void Reset()
        {
            if(FirstSelectedKeys != null)
            {
                SetSelectedKeys(FirstSelectedKeys).ConfigureAwait(false);
            }
            else
            {
                Clear().Wait();
            }
        }
    }
}
