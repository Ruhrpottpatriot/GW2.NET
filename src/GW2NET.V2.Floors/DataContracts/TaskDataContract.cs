// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the task object from the api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Runtime.Serialization;

    /// <summary>Represents the task object from the api.</summary>
    [DataContract]
    internal sealed class TaskDataContract
    {
        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        [DataMember(Name = "task_id", Order = 0)]
        internal int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the objective.
        /// </summary>
        [DataMember(Name = "objective", Order = 1)]
        internal string Objective { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        [DataMember(Name = "level", Order = 2)]
        internal int Level { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        [DataMember(Name = "coord", Order = 3)]
        internal double[] Coordinates { get; set; }
    }
}