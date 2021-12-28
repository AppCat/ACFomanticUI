using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 组件配置
    /// </summary>
    public interface IACComponentConfig
    {
        /// <summary>
        /// 样式
        /// </summary>
        string Style { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// 显示部分特性
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }
    }
}
