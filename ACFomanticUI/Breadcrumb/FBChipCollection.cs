using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 集合
    /// </summary>
    public sealed class FBChipCollection : IReadOnlyCollection<IFBChip>
    {
        private readonly List<IFBChip> _chips;

        /// <summary>
        /// 集合
        /// </summary>
        /// <param name="chips"></param>
        public FBChipCollection(IFBChip[] chips)
        {
            this._chips = chips.ToList();
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count => _chips.Count;

        /// <summary>
        /// Returns an enumerator that iterates through the System.Collections.Generic.List`1.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IFBChip> GetEnumerator() => _chips.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the System.Collections.Generic.List
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => _chips.GetEnumerator();

        /// <summary>
        /// sections
        /// </summary>
        /// <param name="chips"></param>
        public static implicit operator FBChipCollection(IFBChip[] chips)
        {
            return new FBChipCollection(chips);
        }

        /// <summary>
        /// sections
        /// </summary>
        /// <param name="sections"></param>
        public static implicit operator FBChipCollection(string[] sections)
        {
            return (sections, " / ");
        }

        /// <summary>
        /// sections
        /// </summary>
        /// <param name="sectionsAndDivider"></param>
        public static implicit operator FBChipCollection((string[] sections, string divider) sectionsAndDivider)
        {
            var sections = sectionsAndDivider.sections;

            if (!sections?.Any() ?? true)
                return null;

            var chips = string.Join(",/,", sections).Split(',')
            .Select(chip =>
            {
                if (chip == "/")
                {
                    return (IFBChip)new FBDividerConfig { Content = sectionsAndDivider.divider ?? " / " };
                }
                else
                {
                    return (IFBChip)new FBSectionConfig { Content = chip, Link = !(sections.Last() == chip) };
                }
            })
            .ToArray()
            ;

            return new FBChipCollection(chips);
        }
    }
}
