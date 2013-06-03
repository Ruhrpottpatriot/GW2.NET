// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Container type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The container.
    /// </summary>
    public struct Container
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> struct.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        [JsonConstructor]
        public Container(ContainerType type) : this()
        {
            this.Type = type;
        }

        /// <summary>
        /// Enumerates the container type.
        /// </summary>
        public enum ContainerType
        {
            /// <summary>
            /// A default container.
            /// </summary>
            Default,

            /// <summary>
            /// A gift box.
            /// </summary>
            GiftBox
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public ContainerType Type
        {
            get;
            private set;
        }
    }
}
