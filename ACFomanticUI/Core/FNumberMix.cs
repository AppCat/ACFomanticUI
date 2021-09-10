using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 用于 FNumber implicit operator 的 过度类
    /// An overclass for FNumber Implicit Operator
    /// </summary>
    public class FNumberMix
    {
        /// <summary>
        /// 数字
        /// </summary>
        public EnumMix<FNumber>  Number { get; }

        /// <summary>
        /// 用于 FNumber implicit operator 的 过度类
        /// An overclass for FNumber Implicit Operator
        /// </summary>
        /// <param name="number"></param>
        public FNumberMix(EnumMix<FNumber>  number = null)
        {
            Number = number;
        }

        /// <summary>
        /// int TO FNumber
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator FNumberMix(int number)
        {
            if (number < 1 || number > 16)
                throw new ArgumentException($"{nameof(number)}:{number}, only be: 1 - 16");

            return new FNumberMix((FNumber)number);
        }
    }
}
