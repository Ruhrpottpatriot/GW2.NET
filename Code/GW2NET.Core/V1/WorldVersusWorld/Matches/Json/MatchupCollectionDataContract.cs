﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchupCollectionDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchupCollectionDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/matches")]
    internal sealed class MatchupCollectionDataContract
    {
        [DataMember(Name = "wvw_matches", Order = 0)]
        internal ICollection<MatchupDataContract> Matchups { get; set; }
    }
}