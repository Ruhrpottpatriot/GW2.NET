// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a gathering tool.</summary>
    [DataContract]
    public sealed class GatheringToolContract
    {
        /// <summary>Gets or sets the gathering tool type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}