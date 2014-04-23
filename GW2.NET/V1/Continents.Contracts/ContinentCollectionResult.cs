// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollectionResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Wraps a collection of continents.</summary>
    public class ContinentCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of continents.</summary>
        [DataMember(Name = "continents", Order = 0)]
        public ContinentCollection Continents { get; set; }
    }
}