// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.UpgradeComponents
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;
    using GW2DotNET.V1.Items.Details.Types.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an upgrade component.</summary>
    [JsonConverter(typeof(UpgradeComponentDetailsConverter))]
    public abstract class UpgradeComponentDetails : JsonObject, IEquatable<UpgradeComponentDetails>
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly UpgradeComponentType type;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentDetails"/> class.</summary>
        /// <param name="upgradeComponentType">The upgrade component's type.</param>
        protected UpgradeComponentDetails(UpgradeComponentType upgradeComponentType)
        {
            this.type = upgradeComponentType;
        }

        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        public UpgradeBonusCollection Bonuses { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "flags", Order = 1)]
        public UpgradeComponentFlags Flags { get; set; }

        /// <summary>Gets or sets the upgrade component's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        public InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 5)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }

        /// <summary>Gets the upgrade component's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public UpgradeComponentType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>Gets or sets the upgrade component.</summary>
        public UpgradeComponent UpgradeComponent { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(UpgradeComponentDetails left, UpgradeComponentDetails right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(UpgradeComponentDetails left, UpgradeComponentDetails right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(UpgradeComponentDetails other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.UpgradeComponent, other.UpgradeComponent);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((UpgradeComponentDetails)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.UpgradeComponent != null ? this.UpgradeComponent.GetHashCode() : 0;
        }
    }
}