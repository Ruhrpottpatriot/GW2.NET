// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Amulet.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an amulet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.Trinkets
{
    using GW2DotNET.Common;

    /// <summary>Represents an amulet.</summary>
    [TypeDiscriminator(Value = "Amulet", BaseType = typeof(Trinket))]
    public class Amulet : Trinket
    {
    }
}