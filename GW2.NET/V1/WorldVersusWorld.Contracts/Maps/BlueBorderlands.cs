// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlueBorderlands.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the blue team's borderlands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts.Maps
{
    using GW2DotNET.Common;

    /// <summary>Represents the blue team's borderlands.</summary>
    [TypeDiscriminator(Value = "BlueHome", BaseType = typeof(CompetitiveMap))]
    public class BlueBorderlands : CompetitiveMap
    {
    }
}