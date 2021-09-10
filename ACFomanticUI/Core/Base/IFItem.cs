using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 项目
    /// </summary>
    public interface IFItem : IExternalNotifyStateHasChanged
    {
        /// <summary>
        /// 项Id
        /// </summary>
        string ItemId { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        string Key { get; set; }

        ///// <summary>
        ///// 值
        ///// </summary>
        //string Value { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        bool Disabled { get; }
    }
}
