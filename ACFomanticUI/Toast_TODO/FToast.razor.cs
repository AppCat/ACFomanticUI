using ACUI.FomanticUI.JS;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 土司
    /// 土司可以让用户收到活动通知
    /// A toast allows users to be notified of an event
    /// </summary>
    public partial class FToast : ACContentComponentBase
    {
        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "toast";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .GetIf(() => Colored.Value.ToClass(), () => Colored != null)
                .GetIf(() => Emphasis.Value.ToClass(), () => Emphasis != null)
                .GetIf(() => Attached.Value.ToClass(), () => Attached != null)
                .GetIf(() => TextAlignment.Value.ToClass(), () => TextAlignment != null)
                .Add(_suffix)
                ;
        }

        /// <summary>
        /// toast JS 模块
        /// </summary>
        [Inject]
        protected ToastJS ToastJS { get; set; }

        #region Parameter

        /// <summary>
        /// 颜色
        /// </summary>
        [Parameter]
        public EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 强调
        /// </summary>
        [Parameter]
        public EnumMix<FEmphasisRank> Emphasis { get; set; }

        /// <summary>
        /// 依附
        /// </summary>
        [Parameter]
        public EnumMix<FAttached> Attached { get; set; }

        /// <summary>
        /// 文本对齐
        /// </summary>
        [Parameter]
        public EnumMix<FTextAlignment> TextAlignment { get; set; }

        #endregion

        /// <summary>
        /// 射出
        /// </summary>
        /// <returns></returns>
        public async Task ShotAsync(FToastSettings settings)
        {
            await ToastJS.ShotAsync(settings);
        }
    }
}
