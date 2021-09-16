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
    public abstract class ACOverlayItemComponentBase : ACItemComponentBase<IFOverlayItemList, IFOverlayItem>, IFOverlayItem
    {
        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        [Parameter]
        public RenderFragment<IFOverlayItem> ValueTemplate { get; set; }
    }
}
