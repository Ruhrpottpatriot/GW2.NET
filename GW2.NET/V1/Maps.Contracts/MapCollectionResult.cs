// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapCollectionResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of maps and their details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Wraps a collection of maps and their details.</summary>
    public class MapCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of maps and their details.</summary>
        [DataMember(Name = "maps", Order = 0)]
        public MapCollection Maps { get; set; }
    }
}