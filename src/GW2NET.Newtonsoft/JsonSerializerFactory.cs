﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializerFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides factory methods for the Json.NET serialization engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using Newtonsoft.Json;

    /// <summary>Provides factory methods for the JSON.NET serialization engine.</summary>
    public class JsonSerializerFactory : ISerializerFactory
    {
        /// <summary>Backing field.</summary>
        private readonly JsonSerializerSettings jsonSerializerSettings;

        /// <summary>Initializes a new instance of the <see cref="JsonSerializerFactory"/> class.</summary>
        public JsonSerializerFactory()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonSerializerFactory"/> class.</summary>
        /// <param name="jsonSerializerSettings">The settings to be applied to the <see cref="JsonSerializer"/>.</param>
        public JsonSerializerFactory(JsonSerializerSettings jsonSerializerSettings)
        {
            this.jsonSerializerSettings = jsonSerializerSettings;
        }

        /// <summary>Gets a serializer for the specified type.</summary>
        /// <typeparam name="T">The serialization type.</typeparam>
        /// <returns>The <see cref="ISerializer{T}"/>.</returns>
        public ISerializer<T> GetSerializer<T>()
        {
            // Create a Json.NET serializer using a mix of default and explicit settings
            JsonSerializer serializer = JsonSerializer.CreateDefault(this.jsonSerializerSettings);

            // Return a serializer adapter for the newly created Json.NET serializer
            return new JsonSerializer<T>(serializer);
        }
    }
}