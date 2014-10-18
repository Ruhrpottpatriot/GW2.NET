// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ObjectiveContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ObjectiveContract
    {
        [DataMember(Name = "id", Order = 0)]
        internal int Id { get; set; }

        [DataMember(Name = "owner", Order = 1)]
        internal string Owner { get; set; }

        [DataMember(Name = "owner_guild", Order = 2)]
        internal string OwnerGuild { get; set; }
    }
}