// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Tool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// A tool, includes salvage tools.
    /// </summary>
    [Serializable]
    public class Tool
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="charges">
        /// The charges.
        /// </param>
        [JsonConstructor]
        public Tool(ToolType type, int charges)
        {
            this.Charges = charges;
            this.Type = type;
        }

        /// <summary>
        /// Enumerates the tool types.
        /// </summary>
        public enum ToolType
        {
            /// <summary>
            /// A salvage tool.
            /// </summary>
            Salvage,

            /// <summary>
            /// A logging tool.
            /// </summary>
            Logging,

            /// <summary>
            /// A foraging tool.
            /// </summary>
            Foraging,

            /// <summary>
            /// A mining tool.
            /// </summary>
            Mining,
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public ToolType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the charges.
        /// </summary>
        public int Charges
        {
            get;
            private set;
        }
    }
}
