using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 面包屑 分隔符
    /// </summary>
    public partial class FBDividerConfig : FBChipBase, IFBDivider
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 屑类型
        /// </summary>
        public override FBChipType Type => FBChipType.Divider;
    }
}
