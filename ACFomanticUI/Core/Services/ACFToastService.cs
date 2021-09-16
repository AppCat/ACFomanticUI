using ACUI.FomanticUI.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 土司 服务
    /// </summary>
    public class ACFToastService
    {
        private readonly ToastJS _toastJS;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toastJS"></param>
        public ACFToastService(ToastJS toastJS)
        {
            this._toastJS = toastJS;
        }

        /// <summary>
        /// 弹
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShotAsync(FToastSettings settings)
        {
            await _toastJS.ShotAsync(settings);
        }

        /// <summary>
        /// 弹
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ShotAsync(object settings)
        {
            await _toastJS.ShotAsync(settings);
        }
    }
}
