// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollectionDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentCollectionDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Continents.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/continents")]
    internal sealed class ContinentCollectionDataContract
    {
        [DataMember(Name = "continents", Order = 0)]
        internal IDictionary<string, ContinentDataContract> Continents { get; set; }
    }
}