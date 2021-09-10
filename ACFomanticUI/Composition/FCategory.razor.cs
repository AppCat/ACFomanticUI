using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 种类 可 用于多个组件
    /// </summary>
    public partial class FCategory : ACSonContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "category";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("disabled", () => Disabled)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 显示结果
        /// </summary>
        [CascadingParameter]
        protected bool VisibleResults { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 名称
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        #endregion
    }
}
