using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 评论集
    /// 注释的基本列表
    /// A basic list of comments
    /// </summary>
    public partial class FComments : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "comments";


        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
                .If(_prefix, () => !IsSonComments)
                .Add(_suffix)
                ;
        }

        #region CascadingParameter

        /// <summary>
        /// 是否为子列表
        /// </summary>
        [CascadingParameter(Name = "IsSonComments")]
        protected bool IsSonComments { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 收缩
        /// 注释可以折叠，或者从视图中隐藏
        /// Comments can be collapsed, or hidden from view
        /// </summary>
        [Parameter]
        public bool Collapsed { get; set; }

        #endregion

        #region SDLC



        #endregion
    }
}
