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
    public class ACComponentConfig
    {
        /// <summary>
        /// 显示部分样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 显示部分类
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 显示部分特性
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    }
}
