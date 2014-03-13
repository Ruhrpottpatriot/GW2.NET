// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameRestrictions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known game type restrictions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Enumerates the known game type restrictions.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum GameRestrictions
    {
        /// <summary>Indicates no game type restrictions.</summary>
        None = 0, 

        /// <summary>The 'Activity' game type restriction.</summary>
        [EnumMember(Value = "Activity")]
        Activity = 1 << 0, 

        /// <summary>The 'Dungeon' game type restriction.</summary>
        [EnumMember(Value = "Dungeon")]
        Dungeon = 1 << 1, 

        /// <summary>The 'Player versus Environment' game type restriction.</summary>
        [EnumMember(Value = "Pve")]
        PvE = 1 << 2, 

        /// <summary>The 'Player versus Player' game type restriction.</summary>
        [EnumMember(Value = "Pvp")]
        PvP = 1 << 3, 

        /// <summary>The 'Player versus Player Lobby' game type restriction.</summary>
        /// <remarks>Indicates an item that can be used in 'Heart of the Mists'.</remarks>
        [EnumMember(Value = "PvpLobby")]
        PvPLobby = 1 << 4, 

        /// <summary>The 'World versus World' game type restriction.</summary>
        [EnumMember(Value = "Wvw")]
        WvW = 1 << 5
    }
}