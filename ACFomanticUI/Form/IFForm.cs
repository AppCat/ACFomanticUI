using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表单
    /// </summary>
    public interface IFForm : IFFieldGroup
    {
        /// <summary>
        /// 编辑上下文 
        /// </summary>
        internal EditContext EditContext { get; }

        /// <summary>
        /// 模型
        /// </summary>
        internal object Model { get; }

        /// <summary>
        /// 重置
        /// </summary>
        void Reset();

        /// <summary>
        /// 提交
        /// </summary>
        void Submit();

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        bool Validate();
    }
}
