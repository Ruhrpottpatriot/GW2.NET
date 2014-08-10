// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Wraps a collection of continents.</summary>
    [DataContract]
    public sealed class ContinentCollectionContract
    {
        /// <summary>Gets or sets a collection of continents.</summary>
        [DataMember(Name = "continents", Order = 0)]
        public IDictionary<string, ContinentContract> Continents { get; set; }
    }
}