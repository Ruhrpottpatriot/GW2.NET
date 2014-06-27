// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EternalBattlegrounds.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the Eternal Battlegrounds.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Maps
{
    using GW2DotNET.Common;

    /// <summary>Represents the Eternal Battlegrounds.</summary>
    [TypeDiscriminator(Value = "Center", BaseType = typeof(CompetitiveMap))]
    public class EternalBattlegrounds : CompetitiveMap
    {
    }
}