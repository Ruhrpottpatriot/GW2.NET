// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DetailsDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System.Runtime.Serialization;

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content> Contains data contract properties for all skins.</content>
    [DataContract]
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content> Contains data contract properties for all armors.</content>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the weight class.</summary>
        [DataMember(Name = "weight_class", Order = 1)]
        public string WeightClass { get; set; }
    }

    /// <summary>Defines the <see cref="DetailsDataContract"/> type.</summary>
    /// <content> Contains data contract properties for all weapons.</content>
    internal sealed partial class DetailsDataContract
    {
        /// <summary>Gets or sets the damage class.</summary>
        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageClass { get; set; }
    }
}