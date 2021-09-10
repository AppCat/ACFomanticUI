using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 步骤
    /// 步骤显示一系列活动中的一个活动的完成状态
    /// A step shows the completion status of an activity in a series of activities
    /// </summary>
    public interface IFStepItem : IFItem
    {
        /// <summary>
        /// 图标
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        bool Link { get; set; }

        /// <summary>
        /// 完成
        /// </summary>
        bool Completed { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        bool Disabled { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        RenderFragment TitleContent { get; set; }

        /// <summary>
        /// 标题配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 细节
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 细节模板
        /// </summary>
        RenderFragment DescriptionContent { get; set; }

        /// <summary>
        /// 细节配置
        /// </summary>
        [Parameter]
        public ACComponentConfig DescriptionConfig { get; set; }
    }
}
