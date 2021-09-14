using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 操作
    /// 模态可以包含一行操作
    /// A modal can contain a row of actions
    /// </summary>
    public partial class FMActions : ACContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "actions";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                ;
        }

        #region Parameter

        /// <summary>
        /// 行为
        /// </summary>
        [Parameter]
        public FMATemplateSettings[] Actions { get; set; }

        /// <summary>
        /// 对齐
        /// 您可以将标题、内容甚至操作单独居中对齐
        /// You can center align the header, the content or even actions individually
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        #endregion
    }
}
