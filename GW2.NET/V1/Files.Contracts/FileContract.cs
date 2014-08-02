// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents information about a file that can be retrieved from the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Files.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents information about a file that can be retrieved from the render service.</summary>
    [DataContract]
    public sealed class FileContract
    {
        /// <summary>Gets or sets the file identifier to be used with the render service.</summary>
        [DataMember(Name = "file_id")]
        public int FileId { get; set; }

        /// <summary>Gets or sets file signature to be used with the render service.</summary>
        [DataMember(Name = "signature")]
        public string Signature { get; set; }
    }
}