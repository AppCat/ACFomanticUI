using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 列上下文
    /// </summary>
    public class FColumnContext
    {
        /// <summary>
        /// 列
        /// </summary>
        public IList<IFTColumn> Columns { get; set; } = new List<IFTColumn>();

        /// <summary>
        /// 当前列号
        /// </summary>
        public int CurrentColumnIndex { get; set; }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="column"></param>
        public void AddColumn(IFTColumn column)
        {
            if (column == null)
            {
                return;
            }
            column.ColumnIndex = CurrentColumnIndex++;
            Columns.Add(column);
        }
    }
}
