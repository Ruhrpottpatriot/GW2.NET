// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldNameContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Worlds.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class WorldNameContract
    {
        [DataMember(Name = "id", Order = 0)]
        internal string Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }
    }
}