// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible consumable types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible consumable types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConsumableType
    {
        /// <summary>The 'Unknown' consumable type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Appearance Change' consumable type.</summary>
        [EnumMember(Value = "AppearanceChange")]
        AppearanceChange = 1 << 0, 

        /// <summary>The 'Booze' consumable type.</summary>
        [EnumMember(Value = "Booze")]
        Booze = 1 << 1, 

        /// <summary>The 'Contract NPC' consumable type.</summary>
        [EnumMember(Value = "ContractNpc")]
        ContractNpc = 1 << 2, 

        /// <summary>The 'Food' consumable type.</summary>
        [EnumMember(Value = "Food")]
        Food = 1 << 3, 

        /// <summary>The 'Generic' consumable type.</summary>
        [EnumMember(Value = "Generic")]
        Generic = 1 << 4, 

        /// <summary>The 'Halloween' consumable type.</summary>
        [EnumMember(Value = "Halloween")]
        Halloween = 1 << 5, 

        /// <summary>The 'Immediate' consumable type.</summary>
        [EnumMember(Value = "Immediate")]
        Immediate = 1 << 6, 

        /// <summary>The 'Transmutation' consumable type.</summary>
        [EnumMember(Value = "Transmutation")]
        Transmutation = 1 << 7, 

        /// <summary>The 'Unlock' consumable type.</summary>
        [EnumMember(Value = "Unlock")]
        Unlock = 1 << 8, 

        /// <summary>The 'Utility' consumable type.</summary>
        [EnumMember(Value = "Utility")]
        Utility = 1 << 9, 

        /// <summary>The 'Un-Transmutation' consumable type.</summary>
        [EnumMember(Value = "UnTransmutation")]
        UnTransmutation = 1 << 10, 

        /// <summary>The 'Upgrade Removal' consumable type.</summary>
        [EnumMember(Value = "UpgradeRemoval")]
        UpgradeRemoval = 1 << 11
    }
}