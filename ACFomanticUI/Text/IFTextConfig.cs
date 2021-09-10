using ACUI.FomanticUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// Text 配置
    /// </summary>
    public interface IFTextConfig 
    {
        /// <summary>
        /// 类
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        string Style { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// 重点
        /// 可以被格式化以显示不同程度的强调
        /// </summary>
        EnumMix<FEmphasisRank> Emphasis { get; set; }

        /// <summary>
        /// 尺寸
        /// 可以有不同的大小
        /// </summary>
        EnumMix<FSize> Size { get; set; }

        /// <summary>
        /// 颜色
        /// 可以有不同的颜色
        /// </summary>
        EnumMix<FColored> Colored { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }
    }
}
