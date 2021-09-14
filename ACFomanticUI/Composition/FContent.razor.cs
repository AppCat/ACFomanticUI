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
    public partial class FContent : ACSonContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "content";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Extra).ToLowerInvariant(), () => Extra)
                .If(nameof(Image).ToLowerInvariant(), () => Image)
                .If(nameof(Scrolling).ToLowerInvariant(), () => Scrolling)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                ;
        }

        #region Parameter

        /// <summary>
        /// 额外的
        /// 卡片可以包含与主内容分开格式化的额外内容
        /// A card can contain extra content meant to be formatted separately from the main content
        /// </summary>
        [Parameter]
        public bool Extra { get; set; }

        /// <summary>
        /// 图像
        /// 模态可以包含图像内容
        /// A modal can contain image content
        /// </summary>
        [Parameter]
        public bool Image { get; set; }

        /// <summary>
        /// 滚动
        /// 一个模态可以使用整个屏幕的大小
        /// A modal can use the entire size of the screen
        /// </summary>
        [Parameter]
        public bool Scrolling { get; set; }

        /// <summary>
        /// 对齐
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment>  TextAlignment { get; set; }

        #endregion
    }
}
