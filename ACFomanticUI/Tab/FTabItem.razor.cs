using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 标签页项
    /// </summary>
    public partial class FTabItem : ComponentBase
    {
        /// <summary>
        /// 设置类
        /// </summary>
        protected void OnSetClass()
        {
            TitleStyleMapper.Clear()
            .Get(() => TitleConfig?.AsStyle)
            ;

            TitleClassMapper.Clear()
            .If("active", () => ActiveKey == Key)
            .If("loading", () => Loading && ActiveKey == Key)
            .Get(() => TitleConfig?.AsClass)
            ;

            ContentStyleMapper.Clear()
            .Get(() => ContentConfig?.AsStyle)
            ;

            ContentClassMapper.Clear()
            //.Add("tab")
            .If("active", () => ActiveKey == Key)
            .If(FAttached.Bottom.ToClass(), () => TabAttached == FAttached.Top && !SecondaryOrPointing)
            .If(FAttached.Top.ToClass(), () => TabAttached == FAttached.Bottom && !SecondaryOrPointing)
            //.If(FAttached.Right.ToClass(), () => TabAttached == FAttached.Left)
            //.If(FAttached.Left.ToClass(), () => TabAttached == FAttached.Right)
            .Get(() => ContentConfig?.AsClass)
            ;
        }

        #region CascadingParameter

        /// <summary>
        /// TabItem 使用方式
        /// </summary>
        [CascadingParameter(Name = "UseWay")]
        protected FTabItemUseWay UseWay { get; set; }

        /// <summary>
        /// 标签页
        /// </summary>
        [CascadingParameter]
        protected FTab Tab { get; set; }

        /// <summary>
        /// 选中的key
        /// </summary>
        [CascadingParameter(Name = "Tab_ActiveKey")]
        protected string ActiveKey { get; set; }

        /// <summary>
        /// 加载
        /// </summary>
        [CascadingParameter(Name = "Tab_Loading")]
        protected bool Loading { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [CascadingParameter(Name = "Tab_Attached")]
        protected FAttached TabAttached { get; set; }

        /// <summary>
        /// 指向
        /// </summary>
        [CascadingParameter(Name = "Tab_SecondaryOrPointing")]
        protected bool SecondaryOrPointing { get; set; }

        #endregion

        /// <summary>
        /// 标题样式 映射
        /// </summary>
        protected Mapper TitleStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 标题类 映射
        /// </summary>
        protected Mapper TitleClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 内容样式 映射
        /// </summary>
        protected Mapper ContentStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 内容类 映射
        /// </summary>
        protected Mapper ContentClassMapper { get; set; } = new Mapper();

        #region Parameter        

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public string Key { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 标题配置
        /// </summary>
        [Parameter]
        public ACTemplateComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig ContentConfig { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 处理选中的Tap
        /// </summary>
        public async Task HandleActive()
        {
            await Tab.ActiveTap(this);
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (UseWay == FTabItemUseWay.Empty)
            {
                Tab?.TabItems.Add(this);
            }
            else
            {
                OnSetClass();
            }
        }


        #endregion
    }
}
