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
    /// 下拉框选项
    /// </summary>
    public partial class FDropdownOption : ACOverlayItemComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "item";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            base.OnSetClass(classMapper);
            ClassMapper.Add(_prefix)
            ;
        }

        #region Parameter        



        #endregion

        #region Event

        /// <summary>
        /// 点击异步
        /// </summary>
        /// <returns></returns>
        private async Task OnClickAsync(MouseEventArgs args)
        {
            await OnClick.InvokeAsync(args);
            await ItemList?.SelectedItemAsync(this, true);
        }

        /// <summary>
        /// 鼠标移到项目之上
        /// </summary>
        /// <returns></returns>
        private async Task OnMouseoverAsync()
        {
            await ItemList?.FocusItemAsync(this);
        }

        #endregion

        #region SDLC

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        #endregion
    }
}
