// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a container.</summary>
    [DataContract]
    public sealed class ContainerContract
    {
        /// <summary>Gets or sets the container type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}