using ACUI.Shared.Core.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 
    /// </summary>
    public class ACListComponentBase<TItem, TKey> : ACContentComponentBase, IFItemList<TItem, TKey>
        where TItem : class, IFItem<TKey>
    {
        /// <summary>
        /// 项目
        /// </summary>
        protected virtual Dictionary<TKey, TItem> Items { get; set; } = new();

        /// <summary>
        /// 当前聚焦项目
        /// </summary>
        protected virtual TItem FocusItem { get; set; }

        /// <summary>
        /// 当前聚焦项目下标
        /// </summary>
        protected int FocusItemIndex { get; set; }

        #region Parameter

        /// <summary>
        /// 默认选择key
        /// </summary>
        [Parameter]
        public TKey DefaultSelectedKey { get; set; }

        /// <summary>
        /// 选中的项目键
        /// </summary>
        [Parameter]
        public TKey[] SelectedKeys
        {
            get => _selectedKeys; set
            {
                if (value == _selectedKeys)
                    return;
                var old = _selectedKeys;
                _selectedKeys = value;
                NotifyItemStateHasChanged(value, old);
            }
        }
        private TKey[] _selectedKeys;

        /// <summary>
        /// 过滤的项目键
        /// </summary>
        [Parameter]
        public TKey[] FilteredKeys
        {
            get => _filteredKeys; set
            {
                if (value == _filteredKeys)
                    return;
                var old = _selectedKeys;
                _filteredKeys = value;
                NotifyItemStateHasChanged(value, old);
            }
        }
        private TKey[] _filteredKeys;

        /// <summary>
        /// 筛选
        /// </summary>
        [Parameter]
        public string Filtrate { get; set; }

        /// <summary>
        /// 最大多选
        /// </summary>
        [Parameter]
        public int? MaxMultiple { get; set; }

        ///// <summary>
        ///// 按钮可以取其容器的宽度
        ///// A button can take the width of its container
        ///// </summary>
        //[Parameter]
        //public bool Fluid { get; set; }

        /// <summary>
        /// 多选
        /// 一个选择下拉菜单可以允许多个选择。
        /// A selection dropdown can allow multiple selections
        /// </summary>
        [Parameter]
        public bool Multiple { get; set; }

        ///// <summary>
        ///// 可见度
        ///// </summary>
        //[Parameter]
        //public virtual SVisibility? Visibility { get; set; } = SVisibility.Hidden;

        #endregion

        #region Event

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> SelectedKeysChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<TKey[]>> SelectedKeysExpression { get; set; }

        /// <summary>
        /// 选中的标签页键变化
        /// </summary>
        [Parameter]
        public EventCallback<TKey[]> OnSelectedKeysChange { get; set; }

        ///// <summary>
        ///// 能见度变化
        ///// </summary>
        //[Parameter]
        //public EventCallback<SVisibility> VisibilityChanged { get; set; }

        /// <summary>
        /// 聚焦的项目
        /// </summary>
        [Parameter]
        public EventCallback<TItem> OnFocusItem { get; set; }

        /// <summary>
        /// 选中的项目
        /// </summary>
        [Parameter]
        public EventCallback<TItem> OnSelectedItem { get; set; }

        /// <summary>
        /// 点击的项目
        /// </summary>
        [Parameter]
        public EventCallback<TItem> OnClickItem { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            //if(!(SelectedKeys?.Any() ?? true) && DefaultSelectedKey != null)
            //{
            //    SelectedKeys = new TKey[] { DefaultSelectedKey };
            //}
            base.OnParametersSet();
            SelectedKeys ??= (DefaultSelectedKey != null) ? new TKey[] { DefaultSelectedKey } : Array.Empty<TKey>();
            FilteredKeys ??= Array.Empty<TKey>();
        }

        #endregion

        /// <summary>
        /// 选择清空
        /// </summary>
        protected virtual void SelectClear()
        {
            FocusItem = default;
        }

        /// <summary>
        /// 通知项目状态变化
        /// </summary>
        /// <param name="newKeys"></param>
        /// <param name="oldKeys"></param>
        protected virtual void NotifyItemStateHasChanged(TKey[] newKeys = null,
            TKey[] oldKeys = null)
        {
            if (Items == null && Items.Count <= 0)
                return;
            var notifyKeys = (newKeys == null && oldKeys == null) ? Items.Select(kv => kv.Key).ToArray() : Array.Empty<TKey>();
            newKeys ??= Array.Empty<TKey>();
            oldKeys ??= Array.Empty<TKey>();
            notifyKeys = newKeys.Except(oldKeys).Concat(oldKeys.Except(newKeys)).ToArray();
            notifyKeys.Where(nk => nk != null)
                .Where(nk => Items.ContainsKey(nk))
                .Select(nk => Items[nk])
                .ForEach(item => item.NotifyStateHasChanged());
        }

        /// <summary>
        /// 当前项目
        /// </summary>
        /// <returns>TItem / Null</returns>
        internal virtual TItem CurrentItem()
        {
            if (SelectedKeys != null && SelectedKeys.Length > 0)
            {
                var key = SelectedKeys[SelectedKeys.Length - 1];
                if (Items.TryGetValue(key, out TItem item))
                {
                    return item;
                }
            }
            return default;
        }

        /// <summary>
        /// 是否有选中项
        /// </summary>
        /// <returns></returns>
        internal virtual bool IsSelected()
        {
            return (SelectedKeys?.Length ?? 0) > 0 && Items.Count > 0;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool AddItem(TItem item)
        {
            if (item == null || item.Key == null)
                return false;

            var key = item.Key;
            if (Items.ContainsKey(key))
            {
                var olditem = Items[key];
                if (olditem.ItemId != item.ItemId)
                {
                    item.ItemId = olditem.ItemId;
                    Items[key] = item;
                }
            }

            var firstAdd = Items.Count <= 0;
            var addResult = Items.TryAdd(key, item);
            if (firstAdd && addResult)
            {
                StateHasChanged();
            }

            return addResult || Items[key] == item;
        }

        /// <summary>
        /// 聚焦的项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task FocusItemAsync(TItem item)
        {
            if (item == null || item.Key == null || item.Disabled)
                return;

            var oldKey = FocusItem  == null ? default : FocusItem.Key;
            FocusItem = item;
            NotifyItemStateHasChanged(new[] { oldKey, item.Key });
            await OnFocusItem.InvokeAsync(item);
        }

        /// <summary>
        /// 选中的项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isClick"></param>
        public virtual async Task SelectedItemAsync(TItem item, bool isClick = false)
        {
            if (item == null || item.Key == null || item.Disabled)
                return;

            var selectedKeys = SelectedKeys ?? Array.Empty<TKey>();
            var key = item.Key;
            if (selectedKeys?.Contains(key) ?? false)
            {
                var _aks = selectedKeys.ToList();
                _aks.Remove(key);
                selectedKeys = _aks.ToArray();
            }
            else
            {
                if (Multiple)
                {
                    if ((MaxMultiple ?? int.MaxValue) <= selectedKeys.Length)
                    {
                        var _aks = new TKey[selectedKeys.Length];
                        for (int i = 0; i < _aks.Length - 1; i++)
                        {
                            _aks[i] = selectedKeys[i + 1];
                        }
                        _aks[^1] = key;
                        selectedKeys = _aks;
                    }
                    else
                    {
                        var _aks = new TKey[selectedKeys.Length + 1];
                        for (int i = 0; i < selectedKeys.Length; i++)
                        {
                            _aks[i] = selectedKeys[i];
                        }
                        _aks[^1] = key;
                        selectedKeys = _aks;
                    }
                }
                else
                {
                    selectedKeys = new TKey[] { key };
                }
            }

            await SetSelectedKeys(selectedKeys);
            await OnSelectedItem.InvokeAsync(item);
            if (isClick)
                await OnClickItem.InvokeAsync(item);
            SelectClear();
        }

        /// <summary>
        /// 项目是否选中
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool ItemIsSelected(TItem item)
        {
            if (item == null || item.Key == null)
                return false;

            var key = item.Key;
            return SelectedKeys?.Contains(key) ?? false;
        }

        /// <summary>
        /// 项目是否聚焦
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool ItemIsFocus(TItem item)
        {
            if (item == null || item.Key == null)
                return false;

            var itemId = item.ItemId;
            //return FocusItem.Key == key;
            return FocusItem?.ItemId == itemId;
        }

        /// <summary>
        /// 项目是否过滤
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool ItemIsFiltered(TItem item)
        {
            if (item == null || item.Key == null)
                return false;

            var key = item.Key;
            return FilteredKeys?.Contains(key) ?? false;
        }

        /// <summary>
        /// 清除
        /// </summary>
        public virtual async Task Clear()
        {
            if (SelectedKeys == null || SelectedKeys.Length <= 0)
                return;
            var notifyItemKeys = SelectedKeys;
            await SetSelectedKeys(Array.Empty<TKey>());
        }

        /// <summary>
        /// 设置 SelectedKeys
        /// </summary>
        /// <param name="selectedKeys"></param>
        /// <returns></returns>
        protected virtual async Task SetSelectedKeys(TKey[] selectedKeys)
        {
            SelectedKeys = selectedKeys ?? Array.Empty<TKey>();
            StateHasChanged();
            await SelectedKeysChanged.InvokeAsync(SelectedKeys);
            await OnSelectedKeysChange.InvokeAsync(SelectedKeys);
        }
    }
}
