using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
    public partial class FStep : ACItemComponentBase, IFStepItem
    {
        /// <summary>
        /// 固定类
        /// </summary>
        private const string _fixed = "step";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            base.OnSetClass(classMapper);
            classMapper
                .Add(_fixed)
                .If(nameof(Completed).ToLowerInvariant(), () => Completed)
                //.If(nameof(Active).ToLowerInvariant(), () => Active)
                ;

            TitleStyleMapper.Clear()
            .Get(() => TitleConfig?.AsStyle)
            ;

            TitleClassMapper.Clear()
            .Add("title")
            .Get(() => TitleConfig?.AsClass)
            ;

            DescriptionStyleMapper.Clear()
            .Get(() => DescriptionConfig?.AsStyle)
            ;

            DescriptionClassMapper.Clear()
            .Get(() => DescriptionConfig?.AsClass)
            ;
        }

        /// <summary>
        /// 自动步骤
        /// </summary>
        [CascadingParameter(Name = "AutoStep")]
        protected bool AutoStep { get; set; }

        /// <summary>
        /// 标题样式 映射
        /// </summary>
        protected Mapper TitleStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 标题类 映射
        /// </summary>
        protected Mapper TitleClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 细节样式 映射
        /// </summary>
        protected Mapper DescriptionStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 细节类 映射
        /// </summary>
        protected Mapper DescriptionClassMapper { get; set; } = new Mapper();

        #region Parameter 

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 细节
        /// </summary>
        [Parameter]
        public string Description { get; set; }

        /// <summary>
        /// 完成 
        /// 一个步骤可以显示用户已经完成了它
        /// A step can show that a user has completed it
        /// </summary>
        [Parameter]
        public bool Completed { get; set; }

        ///// <summary>
        ///// 活跃
        ///// 一个活动的显示显示它隐藏的内容
        ///// An active reveal displays its hidden content
        ///// </summary>
        //[Parameter]
        //public bool Active { get; set; }

        /// <summary>
        /// 连接
        /// 一个步骤可以连接
        /// A step can link
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        [Parameter]
        public RenderFragment TitleContent { get; set; }

        /// <summary>
        /// 标题配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 细节内容
        /// </summary>
        [Parameter]
        public RenderFragment DescriptionContent { get; set; }

        /// <summary>
        /// 细节配置
        /// </summary>
        [Parameter]
        public ACComponentConfig DescriptionConfig { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击异步
        /// </summary>
        /// <returns></returns>
        private async Task OnClickAsync(MouseEventArgs args)
        {
            if (Disabled)
                return;

            await OnClick.InvokeAsync(args);
            await ItemList?.SelectedItemAsync(this);
        }

        /// <summary>
        /// 鼠标移到项目之上
        /// </summary>
        /// <returns></returns>
        private async Task OnMouseoverAsync()
        {
            if (Disabled)
                return;

            await ItemList?.FocusItemAsync(this);
        }

        #endregion
    }
}
