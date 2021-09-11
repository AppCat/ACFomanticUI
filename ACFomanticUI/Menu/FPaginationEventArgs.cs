using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 用于传递页码变化事件的参数
    /// </summary>
    public class FPaginationEventArgs : EventArgs
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// 总数
        /// </summary>
        public int PageTotal { get; }

        /// <summary>
        /// 用于传递页码变化事件的参数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageTotal"></param>
        public FPaginationEventArgs(int pageIndex, int pageTotal)
        {
            PageIndex = pageIndex;
            PageTotal = pageTotal;
        }
    }
}
