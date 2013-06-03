// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armour.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Armour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Armour
    {
        public Armour(ArmourClass armourClass, ArmourType type, int suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int defense)
            : this()
        {
            this.Defense = defense;
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
            this.Type = type;
            this.Class = armourClass;
        }

        public ArmourClass Class
        {
            get;
            private set;
        }
        
        public ArmourType Type
        {
            get;
            private set;
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

        public int Defense
        {
            get;
            private set;
        }

        public enum ArmourClass
        {
            Clothing,
            Light,
            Medium,
            Heavy
        }
        
        public enum ArmourType
        {
            Boots,
            Helm,
            Leggings,
            Gloves,
            Shoulders,
            Coat,
            HelmAquatic,
        }
    }
}
