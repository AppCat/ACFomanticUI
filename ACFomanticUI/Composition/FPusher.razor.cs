using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 推进器 
    /// 用于和 Sidebar 进行组合
    /// </summary>
    public partial class FPusher : ACSonContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "pusher";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("dimmed", () => Dimmed)
                ;
        }

        #region Parameter

        /// <summary>
        /// 灰暗
        /// </summary>
        [Parameter]
        public bool Dimmed { get; set; }

        #endregion

        #region Abandon

        new bool Disabled { get; set; }

        #endregion
    }
}
