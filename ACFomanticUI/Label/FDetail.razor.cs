using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 细节
    /// </summary>
    public partial class FDetail : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _suffix = "detail";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_suffix)
                ;
        }

        #region Parameter

        /// <summary>
        /// 连接
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        #endregion
    }
}
