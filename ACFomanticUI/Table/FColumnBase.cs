using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 列 组件基础
    /// </summary>
    public abstract class FColumnBase : ACContentComponentBase, IFTColumn
    {
        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Padded).ToLowerInvariant(), () => Padded)
                .GetIf(() => TextAlignment.ToClass(), () => TextAlignment != null)
                .GetIf(() => $"{Width.ToClass()} wide", () => Width != null)
                ;

            TitleStyleMapper.Clear()
            .Get(() => TitleConfig?.Style)
            ;

            TitleClassMapper.Clear()
            .Get(() => TitleConfig?.Class)
            ;
        }

        /// <summary>
        /// 隐藏部分样式 映射
        /// </summary>
        protected Mapper TitleStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 隐藏部分类 映射
        /// </summary>
        protected Mapper TitleClassMapper { get; set; } = new Mapper();

        #region CascadingParameter

        /// <summary>
        /// 列上下文
        /// </summary>
        [CascadingParameter]
        protected FColumnContext ColumnContext { get; set; }

        /// <summary>
        /// 是否初始化
        /// </summary>
        [CascadingParameter(Name = "IsInitialize")]
        protected bool IsInitialize { get; set; }

        /// <summary>
        /// 使用类型
        /// </summary>
        [CascadingParameter]
        public FColumUseType UseType { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 列序号
        /// </summary>
        [Parameter]
        public int ColumnIndex { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        [Parameter]
        public RenderFragment TitleTemplate { get; set; }

        /// <summary>
        /// 标题配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 填充
        /// 为了便于阅读，表格有时可能需要加厚一些
        /// A table may sometimes need to be more padded for legibility
        /// </summary>
        [Parameter]
        public bool Padded { get; set; }

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        /// <summary>
        /// 宽度
        /// 表可以单独指定各个列的宽度。
        /// A table can specify the width of individual columns independently.
        /// </summary>
        public EnumMix<FNumber> Width { get; set; }

        #endregion

        #region Event



        #endregion
    }
}
