// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.RenownTask.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Map type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.MapInformation.Models
{
    /// <summary>Represents map.</summary>
    public partial class Map
    {
        /// <summary>The task.</summary>
        public class Task
        {
            /// <summary>Initializes a new instance of the <see cref="Task"/> class.</summary>
            /// <param name="taskId">The task id.</param>
            /// <param name="objective">The objective.</param>
            /// <param name="level">The level.</param>
            /// <param name="coordinates">The coordinates.</param>
            [JsonConstructor]
            public Task(int taskId, string objective, int level, float[] coordinates)
            {
                this.Id = taskId;
                this.Coordinates = coordinates;
                this.Level = level;
                this.Objective = objective;
            }

            /// <summary>Gets the id.</summary>
            [JsonProperty("task_id")]
            public int Id { get; private set; }

            /// <summary>Gets the objective.</summary>
            [JsonProperty("objective")]
            public string Objective { get; private set; }

            /// <summary>Gets the level.</summary>
            [JsonProperty("level")]
            public int Level { get; private set; }

            /// <summary>Gets the coordinates.</summary>
            [JsonProperty("coord")]
            public float[] Coordinates { get; private set; }
        }
    }
}