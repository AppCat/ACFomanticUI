using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 面包屑分隔符
    /// 一个面包屑可以包含一个分隔符来显示部分之间的关系，它可以被格式化为一个图标或文本。
    /// A breadcrumb can contain a divider to show the relationship between sections, this can be formatted as an icon or text.
    /// </summary>
    public partial class FBDivider : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _fixed = "divider";
        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper
                .Add(_fixed)
                .GetIf(() => $"{Icon} icon", () => Icon != null)
                ;
        }

        #region Parameter

        /// <summary>
        /// 图标
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        #endregion
    }
}
