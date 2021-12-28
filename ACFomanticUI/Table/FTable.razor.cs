using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表格
    /// 表格显示分组成行的数据集合
    /// A table displays a collections of data grouped into rows
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class FTable<TModel> : ACContentComponentBase<TModel>
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "table";

        /// <summary>
        /// 模型
        /// </summary>
        private static readonly TModel _model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Padded).ToLowerInvariant(), () => Padded)
                .If(nameof(Compact).ToLowerInvariant(), () => Compact)
                .If(nameof(Definition).ToLowerInvariant(), () => Definition)
                .If(nameof(SingleLine).ToLowerInvariant(), () => SingleLine)
                .If(nameof(Fixed).ToLowerInvariant(), () => Fixed)
                .If(nameof(Stacking).ToLowerInvariant(), () => Stacking)
                .If(nameof(Striped).ToLowerInvariant(), () => Striped)
                .If(nameof(Celled).ToLowerInvariant(), () => Celled)
                .If(nameof(Collapsing).ToLowerInvariant(), () => Collapsing)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .GetIf(() => Basic.ToClass(), () => Basic != null)
                .GetIf(() => $"{ColumnCount.ToClass()} column", () => ColumnCount != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;

            TBodyStyleMapper.Clear()
            .Get(() => TBodyConfig?.AsStyle)
            ;

            TBodyClassMapper.Clear()
            .Get(() => TBodyConfig?.AsClass)
            ;

            TFootStyleMapper.Clear()
            .Get(() => TFootConfig?.AsStyle)
            ;

            TFootClassMapper.Clear()
            .Get(() => TFootConfig?.AsClass)
            ;

            THeadStyleMapper.Clear()
            .Get(() => THeadConfig?.AsStyle)
            ;

            THeadClassMapper.Clear()
            .Get(() => THeadConfig?.AsClass)
            ;

        }

        /// <summary>
        /// 列上下文
        /// </summary>
        protected FColumnContext ColumnContext { get; set; }

        /// <summary>
        /// tbody 样式 映射
        /// </summary>
        protected Mapper TBodyStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// tbody 类 映射
        /// </summary>
        protected Mapper TBodyClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// thead 样式 映射
        /// </summary>
        protected Mapper THeadStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// thead 类 映射
        /// </summary>
        protected Mapper THeadClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// tfoot 样式 映射
        /// </summary>
        protected Mapper TFootStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// tfoot 类 映射
        /// </summary>
        protected Mapper TFootClassMapper { get; set; } = new Mapper();

        #region Parameter

        /// <summary>
        /// 单元格过滤器
        /// </summary>
        [Parameter]
        public Func<IFTCell<TModel>, FTCellConfig> CellFilter { get; set; }

        /// <summary>
        /// tbody 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TBodyConfig { get; set; }

        /// <summary>
        /// thead 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig THeadConfig { get; set; }

        /// <summary>
        /// tfoot 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TFootConfig { get; set; }

        /// <summary>
        /// tfoot 内容
        /// </summary>
        [Parameter]
        public RenderFragment TFootContent { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        [Parameter]
        public IEnumerable<TModel> DataSource { get; set; }

        /// <summary>
        /// 隐藏表头
        /// </summary>
        [Parameter]
        public bool HideHeader { get; set; }

        /// <summary>
        /// 填充
        /// A table may sometimes need to be more padded for legibility
        /// </summary>
        [Parameter]
        public bool Padded { get; set; }

        /// <summary>
        /// 紧凑
        /// 一个表有时可能需要更紧凑，以便一次显示更多的行
        /// A table may sometimes need to be more compact to make more rows visible at a time
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 定义
        /// 可以格式化表以强调定义行内容的第一列
        /// A table may be formatted to emphasize a first column that defines a rows content
        /// </summary>
        [Parameter]
        public bool Definition { get; set; }

        /// <summary>
        /// 单行
        /// 表格可以指定其单元格内容应保持在单行上，不换行。
        /// A table can specify that its cell contents should remain on a single line, and not wrap.
        /// </summary>
        [Parameter]
        public bool SingleLine { get; set; }

        /// <summary>
        /// 固定
        /// 表格可以使用表格布局:固定了一种特殊的更快的表格呈现形式，它不根据内容调整表格单元格的大小。
        /// A table can use table-layout: fixed a special faster form of table rendering that does not resize table cells based on content.
        /// </summary>
        [Parameter]
        public bool Fixed { get; set; }

        /// <summary>
        /// 堆叠
        /// 表可以指定它如何响应地堆叠表内容
        /// A table can specify how it stacks table content responsively
        /// </summary>
        [Parameter]
        public bool Stacking { get; set; }

        /// <summary>
        /// 条纹
        /// 表格可以用较深的颜色将交替的内容行条纹化，以增加对比度
        /// A table can stripe alternate rows of content with a darker color to increase contrast
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// 框框
        /// 一个表可以将每一行划分为单独的单元格
        /// A table may be divided each row into separate cells
        /// </summary>
        [Parameter]
        public bool Celled { get; set; }

        /// <summary>
        /// 折叠
        /// 一个表可以折叠，只占用与其行相同的空间。
        /// A table can be collapsing, taking up only as much space as its rows.
        /// </summary>
        [Parameter]
        public bool Collapsing { get; set; }

        /// <summary>
        /// 颠倒
        /// 颜色可以颠倒
        /// A table's colors can be inverted
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 基本
        /// 表可以降低其复杂性以增加可读性。
        /// A table can reduce its complexity to increase readability.
        /// </summary>
        [Parameter]
        public EnumMix<FBasic> Basic { get; set; }

        /// <summary>
        /// 列数量
        /// 一个表可以指定它的列数来均匀地划分它的内容
        /// A table can specify its column count to divide its content evenly
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> ColumnCount { get; set; }

        /// <summary>
        /// 颜色
        /// 可以给一张表以颜色以区别于其他表。
        /// A table can be given a color to distinguish it from other tables.
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 尺寸
        /// 表格可以是小的或大的
        /// A table can also be small or large
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ColumnContext = new FColumnContext();
        }

        #endregion

    }
}
