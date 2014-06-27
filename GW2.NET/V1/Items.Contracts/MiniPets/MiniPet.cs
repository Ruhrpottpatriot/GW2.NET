// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiniPet.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a mini pet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts.MiniPets
{
    using GW2DotNET.Common;

    /// <summary>Represents a mini pet.</summary>
    [TypeDiscriminator(Value = "MiniPet", BaseType = typeof(Item))]
    public class MiniPet : Item
    {
    }
}