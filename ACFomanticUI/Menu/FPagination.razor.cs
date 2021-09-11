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
    /// 页码
    /// </summary>
    public partial class FPagination : ACComponentBase
    {
        /// <summary>
        /// 固定
        /// </summary>
        private const string _fixed = "ui pagination menu";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Size.ToClass(), () => Size != null)
                ;
        }

        /// <summary>
        /// 页码项参数
        /// </summary>
        private IEnumerable<(int? index, bool active)> _itemParams => GenerateItems();

        /// <summary>
        /// 生成页码项
        /// </summary>
        private IEnumerable<(int? index, bool active)> GenerateItems()
        {
            int show = BothShow * 2 + 1;
            int start;
            int end;
            if (PageTotal < PageIndex)
            {
                PageTotal = PageIndex;
            }
            var items = new List<(int?, bool)>();
            if (PageIndex < BothShow * 2)
            {
                start = 1;
                end = 1 + BothShow * 2;
            }
            else if (PageIndex + BothShow >= PageTotal)
            {
                start = PageTotal - BothShow * 2;
                end = PageTotal;
            }
            else
            {
                start = PageIndex - BothShow;
                end = PageIndex + BothShow; ;
            }
            if (end > PageTotal)
                end = PageTotal;
            if (start <= 0)
                start = 1;
            if (PageIndex > (BothShow + 1) && PageTotal > BothShow * 2 && start != 1)
            {
                items.Add((1, false));
                //items.Add((null, false));
            }
            for (int i = start; i <= end; i++)
            {
                var index = i;
                items.Add((index, index == PageIndex));
            }
            if (PageIndex < (PageTotal - BothShow) && PageTotal > BothShow * 2 && end != PageTotal)
            {
                //items.Add((null, false));
                items.Add((PageTotal, false));
            }
            if (PageIndex > end)
            {
                HandleOnClickItemAsync(end).Wait();
            }
            return items;
        }

        /// <summary>
        /// 跳的页
        /// </summary>
        private int _jumpPage { get; set; } = 1;

        #region Parameter        

        /// <summary>
        /// 项目样式
        /// </summary>
        [Parameter]
        public string ItemStyle { get; set; }

        /// <summary>
        /// 菜单样式
        /// </summary>
        [Parameter]
        public string MenuStyle { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Parameter]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 页总数
        /// </summary>
        [Parameter]
        public int PageTotal { get; set; } = 0;

        /// <summary>
        /// 两边显示数量
        /// </summary>
        [Parameter]
        public int BothShow { get; set; } = 2;

        /// <summary>
        /// 能跳
        /// </summary>
        [Parameter]
        public bool CanJump { get; set; }

        /// <summary>
        /// 能下一页
        /// </summary>
        [Parameter]
        public bool CanNext { get; set; } = true;

        /// <summary>
        /// 次要的 
        /// A menu can adjust its appearance to de-emphasize its contents
        /// </summary>
        [Parameter]
        public bool Secondary { get; set; }

        /// <summary>
        /// 直指
        /// A menu can point to show its relationship to nearby content
        /// </summary>
        [Parameter]
        public bool Pointing { get; set; }

        /// <summary>
        /// 文本
        /// A menu can be formatted for text content
        /// </summary>
        [Parameter]
        public bool Text { get; set; }

        /// <summary>
        /// 无边界
        /// 菜单项或菜单可以没有边框
        /// A menu item or menu can have no borders
        /// </summary>
        [Parameter]
        public bool Borderless { get; set; }

        /// <summary>
        /// 可以取其容器的宽度
        /// A button can take the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 紧凑
        /// 一个菜单可以只占用必要的空间来适应它的内容
        /// A menu can take up only the space necessary to fit its content
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 页码变化
        /// </summary>
        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        /// <summary>
        /// 叶总数
        /// </summary>
        [Parameter]
        public EventCallback<int> PageTotalChanged { get; set; }

        /// <summary>
        /// 跳页
        /// </summary>
        [Parameter]
        public EventCallback<int> OnJumpPage { get; set; }

        /// <summary>
        /// 页码变化事件
        /// </summary>
        [Parameter]
        public EventCallback<FPaginationEventArgs> OnPageIndexChange { get; set; }

        #endregion

        /// <summary>
        /// 点击页码项
        /// </summary>
        /// <returns></returns>
        private async Task HandleOnClickItemAsync(int index)
        {
            if (Disabled)
                return;
            if (index < 1)
                PageIndex = 1;
            else if (index > PageTotal)
                PageIndex = PageTotal;
            else
                PageIndex = index;
            //PageIndex = index < 1 || index > PageTotal ? PageIndex : index;
            if (PageIndexChanged.HasDelegate)
            {
                await PageIndexChanged.InvokeAsync(PageIndex);
            }
            if (OnPageIndexChange.HasDelegate)
            {
                await OnPageIndexChange.InvokeAsync(new FPaginationEventArgs(PageIndex, PageTotal));
            }
        }

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task HandleOnKeyPress(KeyboardEventArgs args)
        {
            if (Disabled)
                return;
            await Task.CompletedTask;

        }

        /// <summary>
        /// 处理跳点击
        /// </summary>
        /// <returns></returns>
        private async Task HandleJumpClick()
        {
            if (!CanJump || Disabled)
                return;
            await HandleOnClickItemAsync(_jumpPage);
            _jumpPage = PageIndex;
            await OnJumpPage.InvokeAsync(_jumpPage);
        }
    }

}
