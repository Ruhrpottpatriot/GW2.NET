﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Wraps a collection of continents.</summary>
    public sealed class ContinentCollectionContract : ServiceContract
    {
        /// <summary>Gets or sets a collection of continents.</summary>
        [DataMember(Name = "continents", Order = 0)]
        public IDictionary<string, ContinentContract> Continents { get; set; }
    }
}