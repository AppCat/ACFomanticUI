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
    /// 表情
    /// 表情符号是用来代表一种情感状态的符号
    /// An emoji is a glyph used to represent an emotional state
    /// </summary>
    public partial class FEmoji : ACComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "";

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
                .If("link", () => Link)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .GetIf(() => Floated.ToClass(), () => Floated != null)
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
        /// 一个表情符号可以用作一个简单的加载器
        /// An emoji can be used as a simple loader
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 连接（可点击）
        /// 一个表情符号可以被格式化成一个链接
        /// An emoji can be formatted as a link
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 停止点击穿透
        /// </summary>
        [Parameter]
        public bool ClickStopPropagation { get; set; }

        /// <summary>
        /// 尺寸
        /// 一个表情符号的大小可以不同,
        /// 如果没有给出特定的大小类别，所有的表情符号将根据当前元素的字体大小自动调整大小
        /// An emoji can vary in size
        /// If no specific size class is given, all emojis are automatically sized according to the current element font-size
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

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
