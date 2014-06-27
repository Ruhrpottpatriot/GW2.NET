// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownMapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   an unknown bonus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Maps.Bonuses
{
    using GW2DotNET.Common;

    /// <summary>an unknown bonus.</summary>
    [TypeDiscriminator(Value = "unknown", BaseType = typeof(MapBonus))]
    public class UnknownMapBonus : MapBonus
    {
    }
}