using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 卡片
    /// A single card.
    /// </summary>
    public partial class FCard : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "card";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Centered).ToLowerInvariant(), () => Centered)
                .If(nameof(Raised).ToLowerInvariant(), () => Raised)
                .If(nameof(Fluid).ToLowerInvariant(), () => Fluid)
                .If(nameof(Link).ToLowerInvariant(), () => Link)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 凸起
        /// 卡片的格式可以设置在页面上方。
        /// A card may be formatted to raise above the page.
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }

        /// <summary>
        /// 流体
        /// 流体卡片占用其容器的宽度
        /// A fluid card takes up the width of its container
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }

        /// <summary>
        /// 流体
        /// 卡片可以放在容器的中央
        /// A card can center itself inside its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 连接
        /// 卡片可以包含图像、标题或内部内容等链接
        /// A card can contain contain links as images, headers, or inside content
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 加载
        /// 一张卡片可以显示它的内容正在被加载
        /// A card may show its content is being loaded
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 颜色
        /// 卡片可以指定颜色
        /// A card can specify a color
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 对齐方式
        /// 卡片中的任何元素都可以指定其文本对齐方式
        /// Any element inside a card can have its text alignment specified
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        #endregion
    }
}
