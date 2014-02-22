// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypes.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Common
{
    /// <summary>
    /// Enumerates the possible game types.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum GameTypes
    {
        /// <summary>
        /// The activity game type.
        /// </summary>
        [EnumMember(Value = "Activity")]
        Activity = 1 << 0,

        /// <summary>
        /// The dungeon game type.
        /// </summary>
        [EnumMember(Value = "Dungeon")]
        Dungeon = 1 << 1,

        /// <summary>
        /// The Player versus Environment game type.
        /// </summary>
        [EnumMember(Value = "Pve")]
        PvE = 1 << 2,

        /// <summary>
        /// The Player versus Player game type.
        /// </summary>
        [EnumMember(Value = "Pvp")]
        PvP = 1 << 3,

        /// <summary>
        /// The Player versus Player Lobby game type.
        /// </summary>
        [EnumMember(Value = "PvpLobby")]
        PvPLobby = 1 << 4,

        /// <summary>
        /// The World versus World game type.
        /// </summary>
        [EnumMember(Value = "Wvw")]
        WvW = 1 << 5
    }
}