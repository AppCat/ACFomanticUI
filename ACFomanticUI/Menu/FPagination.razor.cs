using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 页码
    /// </summary>
    public partial class FPagination : ACComponentBase
    {
        /// <summary>
        /// 固定
        /// </summary>
        private const string _fixed = "ui pagination menu";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Size.ToClass(), () => Size != null)
                ;
        }

        #region Parameter        

        /// <summary>
        /// 项目样式
        /// </summary>
        [Parameter]
        public string ItemStyle { get; set; }

        /// <summary>
        /// 菜单样式
        /// </summary>
        [Parameter]
        public string MenuStyle { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Parameter]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 页总数
        /// </summary>
        [Parameter]
        public int PageTotal { get; set; } = 0;

        /// <summary>
        /// 两边显示数量
        /// </summary>
        [Parameter]
        public int BothShow { get; set; } = 2;

        /// <summary>
        /// 能跳
        /// </summary>
        [Parameter]
        public bool CanJump { get; set; }

        /// <summary>
        /// 能下一页
        /// </summary>
        [Parameter]
        public bool CanNext { get; set; } = true;

        /// <summary>
        /// 次要的 
        /// A menu can adjust its appearance to de-emphasize its contents
        /// </summary>
        [Parameter]
        public bool Secondary { get; set; }

        /// <summary>
        /// 直指
        /// A menu can point to show its relationship to nearby content
        /// </summary>
        [Parameter]
        public bool Pointing { get; set; }

        /// <summary>
        /// 文本
        /// A menu can be formatted for text content
        /// </summary>
        [Parameter]
        public bool Text { get; set; }

        /// <summary>
        /// 无边界
        /// 菜单项或菜单可以没有边框
        /// A menu item or menu can have no borders
        /// </summary>
        [Parameter]
        public bool Borderless { get; set; }

        /// <summary>
        /// 可以取其容器的宽度
        /// A button can take the width of its container
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }

        /// <summary>
        /// 紧凑
        /// 一个菜单可以只占用必要的空间来适应它的内容
        /// A menu can take up only the space necessary to fit its content
        /// </summary>
        [Parameter]
        public bool Compact { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Parameter]
        public EnumMix<FSize> Size { get; set; }

        #endregion
    }

}
