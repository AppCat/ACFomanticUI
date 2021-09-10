using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 内容 可 用于多个组件
    /// </summary>
    public partial class FDescription : ACSonContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "description";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .If("disabled", () => Disabled)
                ;
        }

        #region Parameter

        /// <summary>
        /// 对齐
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment>  TextAlignment { get; set; }

        /// <summary>
        /// 浮动
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floated { get; set; }

        #endregion

    }
}
