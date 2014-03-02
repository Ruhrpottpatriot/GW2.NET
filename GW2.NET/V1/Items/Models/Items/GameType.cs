// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GameType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>Enumerates the possible game types an item can be dropped in.</summary>
    public enum GameType
    {
        /// <summary>The item will drop while doing activities.</summary>
        Activity, 

        /// <summary>The item will drop in dungeons.</summary>
        Dungeon, 

        /// <summary>The item will drop in player vs environment.</summary>
        Pve, 

        /// <summary>The item will be dropped in player vs player.</summary>
        Pvp, 

        /// <summary>Item will be dropped in the pvp lobby(possible hearts of the mists?).</summary>
        PvpLobby, 

        /// <summary>Item will be dropped in world vs world.</summary>
        Wvw
    }
}