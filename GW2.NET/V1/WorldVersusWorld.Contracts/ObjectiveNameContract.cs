// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an objective and its localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents an objective and its localized name.</summary>
    public sealed class ObjectiveNameContract
    {
        /// <summary>Gets or sets the objective identifier.</summary>
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        /// <summary>Gets or sets the name of the objective.</summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }
    }
}