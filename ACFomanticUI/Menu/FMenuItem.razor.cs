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
    /// 菜单项
    /// </summary>
    public partial class FMenuItem : ACItemComponentBase
    {
        /// <summary>
        /// 固定
        /// </summary>
        private const string _fixed = "item";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Active).ToLowerInvariant(), () => Active)
                .GetIf(() => Colored.ToClass(), () => Colored != null)
                ;
        }

        #region Parameter

        /// <summary>
        /// 连接
        /// </summary>
        [Parameter]
        public bool Link { get; set; }

        /// <summary>
        /// 当 Link 时可使用
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击
        /// </summary>
        /// <returns></returns>
        protected async Task OnClickAsync(MouseEventArgs args)
        {
            await OnClick.InvokeAsync(args);
            await ItemList?.SelectedItemAsync(this, true);
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        #endregion
    }
}
