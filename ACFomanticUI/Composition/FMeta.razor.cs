using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 内容 可 用于多个组件
    /// </summary>
    public partial class FMeta : ACSonContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "meta";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                .If("disabled", () => Disabled)
                ;
        }

    }
}
