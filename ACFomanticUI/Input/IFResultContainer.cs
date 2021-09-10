using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 结果容器
    /// </summary>
    public interface IFResultContainer
    {
        /// <summary>
        /// 添加结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        bool AddResult(IFResult result);

        /// <summary>
        /// 选中的结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="isClick"></param>
        Task SelectedResultAsync(IFResult result, bool isClick = false);

        /// <summary>
        /// 结果是否选中
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        bool ResultIsSelected(IFResult result);
    }
}
