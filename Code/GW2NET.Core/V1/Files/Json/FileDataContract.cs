// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/files")]
    internal sealed class FileDataContract
    {
        [DataMember(Name = "file_id", Order = 0)]
        internal int FileId { get; set; }

        [DataMember(Name = "signature", Order = 1)]
        internal string Signature { get; set; }
    }
}