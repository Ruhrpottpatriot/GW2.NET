// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapFloor
{
    /// <summary>
    /// Represents a renown heart location.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Task()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class using the specified values.
        /// </summary>
        /// <param name="taskId">The renown heart ID.</param>
        /// <param name="objective">The name or objective.</param>
        /// <param name="level">The level.</param>
        /// <param name="coordinates">The skill challenge's coordinates.</param>
        public Task(int taskId, string objective, int level, PointF coordinates)
        {
            this.TaskId = taskId;
            this.Objective = objective;
            this.Level = level;
            this.Coordinates = coordinates;
        }

        /// <summary>
        /// Gets or sets the task's coordinates.
        /// </summary>
        [JsonProperty("coord", Order = 3)]
        [JsonConverter(typeof(PointFConverter))]
        public PointF Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        [JsonProperty("level", Order = 2)]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the name or objective.
        /// </summary>
        [JsonProperty("objective", Order = 1)]
        public string Objective { get; set; }

        /// <summary>
        /// Gets or sets the renown heart ID.
        /// </summary>
        [JsonProperty("task_id", Order = 0)]
        public int TaskId { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}