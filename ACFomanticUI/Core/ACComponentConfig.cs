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
    public class ACComponentConfig : IACComponentConfig
    {
        /// <summary>
        /// 空
        /// </summary>
        public static ACComponentConfig Empty => new ACComponentConfig();

        /// <summary>
        /// 样式
        /// </summary>
        public string AsStyle { get => $"{StyleMapper.Result} {Style}"; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 样式映射器
        /// </summary>
        protected Mapper StyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 类
        /// </summary>
        public string AsClass { get => $"{ClassMapper.Result} {Class}"; }

        /// <summary>
        /// 类
        /// </summary>
        public string Class { get; set; } 

        /// <summary>
        /// 类映射器
        /// </summary>
        protected Mapper ClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 显示部分特性
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public ACComponentConfig AddStyle(string style)
        {
            StyleMapper.Add(style);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public ACComponentConfig AddStyle(Func<string> style)
        {
            StyleMapper.Get(style);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public ACComponentConfig AddIfStyle(string style, Func<bool> ifFunc)
        {
            StyleMapper.If(style, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public ACComponentConfig AddIfStyle(Func<string> style, Func<bool> ifFunc)
        {
            StyleMapper.GetIf(style, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public ACComponentConfig AddClass(string @class)
        {
            ClassMapper.Add(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public ACComponentConfig AddClass(Func<string> @class)
        {
            ClassMapper.Get(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public ACComponentConfig AddIfClass(string @class, Func<bool> ifFunc)
        {
            ClassMapper.If(@class, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public ACComponentConfig AddIfClass(Func<string> @class, Func<bool> ifFunc)
        {
            ClassMapper.GetIf(@class, ifFunc);
            return this;
        }
    }
}
