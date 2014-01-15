// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDeserializer.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace GW2DotNET.V1.Core.Converters
{
    /// <summary>
    /// Represents a JSON de-serializer for use with RestSharp clients.
    /// </summary>
    public class JsonDeserializer : IDeserializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDeserializer"/> class.
        /// </summary>
        public JsonDeserializer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDeserializer"/> class using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public JsonDeserializer(JsonSerializerSettings settings)
        {
            this.Settings = settings;
        }

        /// <summary>
        /// Gets or sets the date format. Unused for JSON content.
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the namespace. Unused for JSON content.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the root element. Unused for JSON content.
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="JsonSerializerSettings"/> that will be used to de-serialize objects.
        /// </summary>
        public JsonSerializerSettings Settings { get; set; }

        /// <summary>
        /// Deserializes the response to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="response">The response to parse.</param>
        /// <returns>Returns an instance of the specified type.</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, this.Settings);
        }
    }
}
