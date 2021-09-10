using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 单元格
    /// </summary>
    public interface IFTCell<TModel>
    {
        /// <summary>
        /// 模型
        /// </summary>
        TModel Model { get; }

        /// <summary>
        /// 行号
        /// </summary>
        int RowNumber { get; }

        /// <summary>
        /// 列号
        /// </summary>
        int ColumnNumber { get; }

        /// <summary>
        /// 字段名称
        /// </summary>
        int FieldName { get; }
    }
}
