// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Back type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Back
    {
        public Back(int suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade)
            : this()
        {
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
        }

        public int SuffixId
        {
            get;
            private set;
        }

        public IEnumerable<InfusionSlot> InfusionSlots
        {
            get;
            private set;
        }

        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }
    }
}
