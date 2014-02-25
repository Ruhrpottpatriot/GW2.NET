// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonObject.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Provides the base class for strongly typed JSON objects.
    /// </summary>
    [Serializable]
    public abstract class JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonObject"/> class.
        /// </summary>
        protected JsonObject()
        {
            this.ExtensionData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets a dictionary of additional JSON properties that have no corresponding .NET property.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtensionData { get; set; }

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
        public virtual string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}
