// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Shoulders.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents shoulder protection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.Armors
{
    using GW2DotNET.Common;

    /// <summary>Represents shoulder protection.</summary>
    [TypeDiscriminator(Value = "Shoulders", BaseType = typeof(Armor))]
    public class Shoulders : Armor
    {
    }
}