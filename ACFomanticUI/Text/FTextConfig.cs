using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 文本配置
    /// </summary>
    public class FTextConfig : ACComponentConfig, IFTextConfig
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 重点
        /// 可以被格式化以显示不同程度的强调
        /// </summary>
        public EnumMix<FEmphasisRank> Emphasis { get; set; }

        /// <summary>
        /// 尺寸
        /// 可以有不同的大小
        /// </summary>
        public EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 颜色
        /// 可以有不同的颜色
        /// </summary>
        public EnumMix<FColored> Colored { get; set; }
    }
}
