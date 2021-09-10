using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 用于 FSize implicit operator 的 过度类
    /// An overclass for FSize Implicit Operator
    /// </summary>
    public class FSizeMix
    {
        /// <summary>
        /// 数字
        /// </summary>
        public EnumMix<FSize>  Value { get; }

        /// <summary>
        /// 用于 FSize implicit operator 的 过度类
        /// An overclass for FSize Implicit Operator
        /// </summary>
        /// <param name="size"></param>
        public FSizeMix(EnumMix<FSize>  size = null)
        {
            Value = size;
        }

        /// <summary>
        /// int TO FSize
        /// </summary>
        /// <param name="size"></param>
        public static implicit operator FSizeMix(int size)
        {
            if (size < 0 || size > 7)
                throw new ArgumentException($"{nameof(size)}:{size}, only be: 0 - 7");

            return new FSizeMix((FSize)size);
        }
    }
}
