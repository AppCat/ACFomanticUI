using ACUI.FomanticUI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 枚举下拉框
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public partial class FEnumDropdown<TEnum> : DropdownBase<TEnum>
    {
        /// <summary>
        /// 获取枚举对
        /// </summary>
        /// <returns></returns>
        protected KeyValuePair<TEnum, string>[] GetEnumPairs()
        {
            var type = typeof(TEnum);
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;
            return underlyingType.GetEnumDisplayNames().Select(kv => KeyValuePair.Create((TEnum)Enum.Parse(underlyingType, kv.Key), kv.Value)).ToArray();
        }
    }
}
