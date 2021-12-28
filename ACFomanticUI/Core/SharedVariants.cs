using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 共享变量
    /// </summary>
    public static class SharedVariants
    {
        /// <summary>
        /// 值
        /// </summary>
        private static ConcurrentDictionary<string, object> _valuePairs = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValue<TValue>(string key)
        {
            if (!_valuePairs.ContainsKey(key))
            {
                SetValue<TValue>(key, default);
            }

            return (TValue)_valuePairs[key];
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue<TValue>(string key, TValue value)
        {
            if (!_valuePairs.ContainsKey(key))
            {
                _valuePairs.TryAdd(key, value);
            }

            _valuePairs[key] = value;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <param name="key"></param>
        public static void ValueSet<TValue>(this TValue value, string key)
        {
            SetValue(key, value);
        }
    }
}
