// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonObject.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for strongly typed JSON objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>Provides the base class for strongly typed JSON objects.</summary>
    [Serializable]
    [DataContract]
    public abstract class JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="JsonObject" /> class.</summary>
        protected JsonObject()
        {
            this.ExtensionData = new Dictionary<string, object>();
        }

        /// <summary>Gets or sets a dictionary of additional JSON properties that have no corresponding .NET property.</summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtensionData { get; set; }

        /// <summary>Gets the JSON representation of this instance.</summary>
        /// <returns>Returns a JSON <see cref="System.String" />.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>Gets the JSON representation of this instance.</summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public virtual string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}