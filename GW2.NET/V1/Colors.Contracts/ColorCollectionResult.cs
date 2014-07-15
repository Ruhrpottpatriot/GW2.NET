// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorCollectionResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of colors in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Wraps a collection of colors in the game.</summary>
    public class ColorCollectionResult : ServiceContract
    {
        /// <summary>Gets or sets a collection of colors in the game.</summary>
        [DataMember(Name = "colors")]
        public ColorCollection Colors { get; set; }
    }
}