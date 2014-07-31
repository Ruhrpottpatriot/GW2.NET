// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypes.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known game type restrictions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Items
{
    using System;

    /// <summary>Enumerates known game type restrictions.</summary>
    [Flags]
    public enum GameTypes
    {
        /// <summary>Indicates no game type restrictions.</summary>
        None = 0, 

        /// <summary>The 'Activity' game type restriction.</summary>
        Activity = 1 << 0, 

        /// <summary>The 'Dungeon' game type restriction.</summary>
        Dungeon = 1 << 1, 

        /// <summary>The 'Player versus Environment' game type restriction.</summary>
        PvE = 1 << 2, 

        /// <summary>The 'Player versus Player' game type restriction.</summary>
        PvP = 1 << 3, 

        /// <summary>The 'Player versus Player Lobby' game type restriction.</summary>
        /// <remarks>Indicates an item that can be used in 'Heart of the Mists'.</remarks>
        PvPLobby = 1 << 4, 

        /// <summary>The 'World versus World' game type restriction.</summary>
        WvW = 1 << 5
    }
}