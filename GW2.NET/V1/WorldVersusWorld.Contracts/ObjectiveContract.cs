// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a World versus World map's objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents one of a World versus World map's objectives.</summary>
    public sealed class ObjectiveContract : ServiceContract
    {
        /// <summary>Gets or sets the objective identifier.</summary>
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; set; }

        /// <summary>Gets or sets the current owner.</summary>
        [DataMember(Name = "owner", Order = 1)]
        public string Owner { get; set; }

        /// <summary>Gets or sets the guild currently claiming the objective.</summary>
        [DataMember(Name = "owner_guild", Order = 2)]
        public string OwnerGuild { get; set; }
    }
}