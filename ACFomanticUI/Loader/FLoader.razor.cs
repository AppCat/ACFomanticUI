using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 加载器
    /// 加载器提醒用户等待某个活动完成
    /// A loader alerts a user to wait for an activity to complete
    /// </summary>
    public partial class FLoader : ACComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "loader";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("inline", () => Inline && !CenteredInline)
                .If("centered inline", () => CenteredInline)
                .If("text", () => !string.IsNullOrEmpty(Text))
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Active).ToLowerInvariant(), () => Active)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .If(nameof(Indeterminate).ToLowerInvariant(), () => Indeterminate)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        #region Parameter

        /// <summary>
        /// 文本
        /// 加载程序可以包含文本
        /// A loader can contain text
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// 活跃
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        /// <summary>
        /// 不确定
        /// 加载程序可以显示它不确定的任务将花费多长时间
        /// A loader can show it's unsure of how long a task will take
        /// </summary>
        [Parameter]
        public bool Indeterminate { get; set; }

        /// <summary>
        /// 颠倒
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 内联
        /// 加载器可以与内容内联出现
        /// Loaders can appear inline with content
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 内联并且剧中
        /// 加载器可以与内容以内联居中显示
        /// Loaders can appear inline centered with content
        /// </summary>
        [Parameter]
        public bool CenteredInline { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion
    }
}
