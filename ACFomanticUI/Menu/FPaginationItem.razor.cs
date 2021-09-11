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
    /// 页码项
    /// </summary>
    public partial class FPaginationItem : ACComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "item";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Active).ToLowerInvariant(), () => Active)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled || Index == null)
                ;
        }

        /// <summary>
        /// 页码
        /// </summary>
        [CascadingParameter]
        protected FPagination Pagination { get; set; }

        /// <summary>
        /// 页码类型
        /// </summary>

        [CascadingParameter]
        protected FPaginationType Type { get; set; }

        #region Parameter    

        /// <summary>
        /// 是否禁用
        /// </summary>
        public new bool Disabled => Pagination?.Disabled ?? false;

        /// <summary>
        /// 选中
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        /// <summary>
        /// 表示 页码项号
        /// </summary>
        [Parameter]
        public int? Index { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击项事件
        /// </summary>
        [Parameter]
        public EventCallback<int> OnClickItem { get; set; }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task OnClickAsync(MouseEventArgs args)
        {
            if (Disabled)
                return;

            if (OnClickItem.HasDelegate)
            {
                await OnClickItem.InvokeAsync(Index ?? 0);
            }
        }

        #endregion
    }
}
