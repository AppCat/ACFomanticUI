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
    public partial class FCardGroup : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "cards";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
                .Add(_prefix)
                .GetIf(() => CardCount.ToClass(), () => CardCount != null)
                .If(nameof(Stackable).ToLowerInvariant(), () => Stackable)
                .If(nameof(Doubling).ToLowerInvariant(), () => Doubling)
                .If(nameof(Link).ToLowerInvariant(), () => Link)
                .Add(_suffix)
                ;
        }

        #region Parameter  

        /// <summary>
        /// 堆叠
        /// 一组卡片可以在移动设备上自动将行堆叠成单个列
        /// A group of cards can automatically stack rows to a single columns on mobile devices
        /// </summary>
        [Parameter]
        public bool Stackable { get; set; }

        /// <summary>
        /// 加倍列宽
        /// 一组卡片可以使其列宽增加一倍，便于移动
        /// A group of cards can double its column width for mobile
        /// </summary>
        [Parameter]
        public bool Doubling { get; set; }

        /// <summary>
        /// 连接
        /// 卡片可以包含图像、标题或内部内容等链接
        /// A card can contain contain links as images, headers, or inside content
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 卡片数量
        /// A group of cards can set how many cards should exist in a row
        /// 一组牌可以设置一行中应该有多少张牌
        /// </summary>
        [Parameter]
        public EnumMix<FNumber> CardCount { get; set; }

        #endregion
    }
}
