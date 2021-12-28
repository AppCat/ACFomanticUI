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
    public interface IFOverlayItem<TKey> : IFItem<TKey>
    {
        /// <summary>
        /// 值
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// 值模板
        /// </summary>
        RenderFragment<IFOverlayItem<TKey>> ValueTemplate { get; set; }
    }
}
