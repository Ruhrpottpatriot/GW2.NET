// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a renown heart location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a renown heart location.</summary>
    [DataContract]
    public sealed class RenownTaskContract
    {
        /// <summary>Gets or sets the task's coordinates.</summary>
        [DataMember(Name = "coord", Order = 3)]
        public double[] Coordinates { get; set; }

        /// <summary>Gets or sets the level.</summary>
        [DataMember(Name = "level", Order = 2)]
        public int Level { get; set; }

        /// <summary>Gets or sets the name or objective.</summary>
        [DataMember(Name = "objective", Order = 1)]
        public string Objective { get; set; }

        /// <summary>Gets or sets the renown task identifier.</summary>
        [DataMember(Name = "task_id", Order = 0)]
        public int TaskId { get; set; }
    }
}