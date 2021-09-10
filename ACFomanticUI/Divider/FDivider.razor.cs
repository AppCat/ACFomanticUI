using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 分隔线
    /// </summary>
    public partial class FDivider : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefixName = "ui divider";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefixName)
                .GetIf(() => Direction.ToClass(), () => Direction != null)
                .If("inverted", () => Inverted)
                .If("fitted", () => Fitted)
                .If("hidden", () => Hidden)
                .If("section", () => Section)
                .If("clearing", () => Clearing)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 翻转
        /// 除法器的颜色可以颠倒
        /// A divider can have its colors inverted
        /// </summary>
        public bool Inverted { get; set; }

        /// <summary>
        /// 擦除
        /// 分割线可以清除它上方的内容
        /// A divider can clear the contents above it
        /// </summary>
        [Parameter]
        public bool Clearing { get; set; }

        /// <summary>
        /// 截面
        /// 分割线可以用来更好的分割段落间距
        /// A divider can provide greater margins to divide sections of content
        /// </summary>
        [Parameter]
        public bool Section { get; set; }

        /// <summary>
        /// 隐藏
        /// 可以通过隐藏的分隔线来分隔内容而不用创建一条分隔线
        /// A hidden divider divides content without creating a dividing line
        /// </summary>
        [Parameter]
        public bool Hidden { get; set; }

        /// <summary>
        /// 合适
        /// 可以安装一个分隔器，上面或下面没有任何空间。
        /// A divider can be fitted, without any space above or below it.
        /// </summary>
        [Parameter]
        public bool Fitted { get; set; }

        /// <summary>
        /// 方向
        /// 分割器可以垂直分割内容
        /// A divider can segment content vertically
        /// </summary>
        [Parameter]
        public EnumMix<FDirection>  Direction { get; set; }        

        #endregion
    }
}
