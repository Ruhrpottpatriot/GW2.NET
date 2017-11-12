// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the BuildDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Builds.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/build")]
    internal sealed class BuildDataContract
    {
        [DataMember(Name = "id", Order = 0)]
        internal int BuildId { get; set; }
    }
}