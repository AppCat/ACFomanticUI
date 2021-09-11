using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 操作列
    /// </summary>
    public partial class FTActionColumn : FColumnBase
    {


        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (IsInitialize)
            {
                ColumnContext?.AddColumn(this);
            }
        }

        #endregion
    }
}
