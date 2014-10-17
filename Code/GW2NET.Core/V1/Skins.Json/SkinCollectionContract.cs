// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of skin identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Wraps a collection of skin identifiers.</summary>
    [DataContract]
    public sealed class SkinCollectionContract
    {
        /// <summary>Gets or sets a collection of skin identifiers.</summary>
        [DataMember(Name = "skins", Order = 0)]
        public ICollection<int> Skins { get; set; }
    }
}