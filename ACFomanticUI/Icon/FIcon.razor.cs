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
    /// 图标
    /// 图标是用来表示其他东西的符号
    /// An icon is a glyph used to represent something else
    /// </summary>
    public partial class FIcon : ACComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "icon";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("disabled", () => Disabled)
                .If("loading", () => Loading)
                .If("fitted", () => Fitted)
                .If("link", () => Link)
                .If("circular", () => Circular)
                .If("bordered", () => Bordered)
                .If("inverted", () => Inverted)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .GetIf(() => FlippedAndRotated.ToClass(), () => FlippedAndRotated != null)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
                .GetIf(() => Set, () => Set != null)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 图标
        /// </summary>
        [Parameter]
        public string Set { get; set; }

        /// <summary>
        /// 加载
        /// An icon can be used as a simple loader
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 适应
        /// An icon can be fitted, without any space to the left or right of it.
        /// </summary>
        [Parameter]
        public bool Fitted { get; set; }

        /// <summary>
        /// 连接（可点击）
        /// An icon can be formatted as a link
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 圆形
        /// An icon can be formatted to appear circular
        /// </summary>
        [Parameter]
        public bool Circular { get; set; }

        /// <summary>
        /// 有边框
        /// An icon can be formatted to appear bordered
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <summary>
        /// 停止点击穿透
        /// </summary>
        [Parameter]
        public bool ClickStopPropagation { get; set; }

        /// <summary>
        /// 翻转
        /// 一个图标可以有它的颜色反向对比
        /// An icon can have its colors inverted for contrast
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 尺寸
        /// 图标的大小可以不同
        /// An icon can vary in size
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        /// <summary>
        /// 翻转与旋转
        /// 一个图标可以翻转和一个图标可以旋转
        /// An icon can be flipped And An icon can be rotated
        /// </summary>
        [Parameter]
        public EnumMix<FIconFlippedAndRotated> FlippedAndRotated { get; set; }

        /// <summary>
        /// 颜色
        /// 图标可以用不同的颜色进行格式化
        /// An icon can be formatted with different colors
        /// </summary>
        [Parameter]
        public EnumMix<FColored>  Colored { get; set; }

        /// <summary>
        /// 浮动
        /// </summary>
        [Parameter]
        public EnumMix<FFloated>  Floated { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task HandleOnClick(MouseEventArgs args)
        {

            if (OnClick.HasDelegate)
            {
                await OnClick.InvokeAsync(args);
            }
        }

        #endregion
    }
}
