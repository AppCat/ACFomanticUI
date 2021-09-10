using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 线
    /// </summary>
    public partial class FPLine : ACComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "line";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .GetIf(() => Length.ToClass(), () => Length != null)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 长度
        /// 一行可以指定它的内容应该出现多长
        /// A line can specify how long its contents should appear
        /// </summary>
        [Parameter]
        public FPLineLength? Length { get; set; }

        #endregion
    }
}
