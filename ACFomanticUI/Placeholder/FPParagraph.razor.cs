using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 段落
    /// 一个占位符可以包含一个段落
    /// A placeholder can contain a paragraph
    /// </summary>
    public partial class FPParagraph : ACContentComponentBase
    {
        /// <summary>
        /// 固定类名
        /// </summary>
        private const string _fixed = "placeholder";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_fixed)
                ;
        }
    }
}
