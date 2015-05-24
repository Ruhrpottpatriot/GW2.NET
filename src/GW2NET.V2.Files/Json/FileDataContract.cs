// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System.Runtime.Serialization;

    /// <summary>Represents the file data from the GW2 api.</summary>
    [DataContract]
    internal sealed class FileDataContract
    {
        /// <summary>Gets or sets the id.</summary>
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        /// <summary>Gets or sets the icon url.</summary>
        [DataMember(Name = "icon", Order = 1)]
        public string Icon { get; set; }
    }
}