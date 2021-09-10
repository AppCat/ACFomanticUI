using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 项目列表
    /// </summary>
    public interface IFItemList
    {
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddItem(IFItem item);

        /// <summary>
        /// 聚焦的项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task FocusItemAsync(IFItem item);

        /// <summary>
        /// 选中的项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isClick"></param>
        Task SelectedItemAsync(IFItem item, bool isClick = false);

        /// <summary>
        /// 项目是否选中
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ItemIsSelected(IFItem item);

        /// <summary>
        /// 项目是否聚焦
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ItemIsFocus(IFItem item);

        /// <summary>
        /// 项目是否过滤
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ItemIsFiltered(IFItem item);
    }
}
