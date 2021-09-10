using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 步骤项
    /// </summary>
    public class FStepItem : IFStepItem
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 细节
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 完成 
        /// 一个步骤可以显示用户已经完成了它
        /// A step can show that a user has completed it
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        public RenderFragment TitleContent { get; set; }
        /// <summary>
        /// 标题配置
        /// </summary>
        public ACComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 细节模板
        /// </summary>
        public RenderFragment DescriptionContent { get; set; }

        /// <summary>
        /// 细节配置
        /// </summary>
        public ACComponentConfig DescriptionConfig { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 附加表
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public bool Link { get; set; }

        /// <summary>
        /// 通知状态变化
        /// </summary>
        public void NotifyStateHasChanged()
        {

        }
    }
}
