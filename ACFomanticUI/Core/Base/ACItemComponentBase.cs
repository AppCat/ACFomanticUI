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
    /// 项目基础
    /// </summary>
    public abstract class ACItemComponentBase : ACContentComponentBase, IFItem
    {
        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Active).ToLowerInvariant(), () => Active)
                .If(nameof(Selected).ToLowerInvariant(), () => Selected)
                .If(nameof(Filtered).ToLowerInvariant(), () => Filtered)
                ;
        }

        /// <summary>
        /// 活跃
        /// </summary>
        protected bool Active => ItemList?.ItemIsSelected(this) ?? false;

        /// <summary>
        /// 过滤
        /// </summary>
        protected bool Filtered => ItemList?.ItemIsFiltered(this) ?? false;

        /// <summary>
        /// 选择
        /// </summary>
        protected bool Selected => ItemList?.ItemIsFocus(this) ?? false;

        #region CascadingParameter

        /// <summary>
        /// 母体
        /// </summary>
        [CascadingParameter]
        protected IFItemList ItemList { get; set; }

        ///// <summary>
        ///// 选中的键 (根据 CascadingParameter 特性通知更新)
        ///// </summary>
        //[CascadingParameter(Name = "SelectedKeys")]
        //protected string[] SelectedKeys { get; set; }

        #endregion

        /// <summary>
        /// 项Id
        /// </summary>
        public virtual string ItemId { get; set; }

        #region Parameter        

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public virtual string Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        [Parameter]
        public virtual object Tag { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ItemId ??= Guid.NewGuid().ToString("N");
            //Key ??= Guid.NewGuid().ToString("N");
            //Value ??= Key;
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ItemList.AddItem(this);
        }

        #endregion

        /// <summary>
        /// 通知状态变化
        /// </summary>
        public void NotifyStateHasChanged() => InvokeStateHasChanged();
    }
}
