// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known chat link types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    /// <summary>Enumerates the known chat link types.</summary>
    public enum ChatLinkType
    {
        /// <summary>The 'Unknown' chat link type.</summary>
        Unknown = 0x00, 

        /// <summary>The 'Coin' chat link type.</summary>
        Coin = 0x01, 

        /// <summary>The 'Item' chat link type.</summary>
        Item = 0x02, 

        /// <summary>The 'Text' chat link type.</summary>
        Text = 0x03, 

        /// <summary>The 'Point of Interest' chat link type.</summary>
        PointOfInterest = 0x04, 

        /// <summary>The 'player versus player' chat link type.</summary>
        PvpGame = 0x05, 

        /// <summary>The 'Skill' chat link type.</summary>
        Skill = 0x07, 

        /// <summary>The 'Trait' chat link type.</summary>
        Trait = 0x08, 

        /// <summary>The 'Player' chat link type.</summary>
        Player = 0x09, 

        /// <summary>The 'Recipe' chat link type.</summary>
        Recipe = 0x0A, 

        /// <summary>The 'Wardrobe' chat link type.</summary>
        Wardrobe = 0x0B, 

        /// <summary>The 'Outfit' chat link type.</summary>
        Outfit = 0x0C
    }
}