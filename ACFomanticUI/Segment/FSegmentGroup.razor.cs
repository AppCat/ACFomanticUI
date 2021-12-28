using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 多分段
    /// </summary>
    public partial class FSegmentGroup : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "segments";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Horizontal).ToLowerInvariant(), () => Horizontal)
                .If(nameof(Raised).ToLowerInvariant(), () => Raised)
                .If(nameof(Stacked).ToLowerInvariant(), () => Stacked)
                .If(nameof(Piled).ToLowerInvariant(), () => Piled)
                .Add(_suffix)
                ;
        }

        #region Parameter 

        /// <summary>
        /// 水平 
        /// 段组可以水平显示
        /// A segment group can appear horizontally
        /// </summary>
        [Parameter]
        public bool Horizontal { get; set; }

        /// <summary>
        /// 分段 
        /// 可以提出一组分段
        /// A group of segments can be raised
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }

        /// <summary>
        /// 堆叠 
        /// 一组段可以堆叠
        /// A group of segments can be stacked
        /// </summary>
        [Parameter]
        public bool Stacked { get; set; }

        /// <summary>
        /// 堆放 
        /// 一组片段可以堆放
        /// A group of segments can be piled
        /// </summary>
        [Parameter]
        public bool Piled { get; set; }

        #endregion
    }
}
