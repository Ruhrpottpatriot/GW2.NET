// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing JSON objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Serializers
{
    using System.Diagnostics.Contracts;
    using System.IO;

    using Newtonsoft.Json;

    /// <summary>Provides methods for serializing JSON objects.</summary>
    /// <typeparam name="T">The type that is being serialized.</typeparam>
    public class JsonSerializer<T> : ISerializer<T>
    {
        /// <summary>Infrastructure. Holds a reference to the JSON.NET serializer.</summary>
        private readonly JsonSerializer jsonSerializer;

        /// <summary>Initializes a new instance of the <see cref="JsonSerializer{T}"/> class.</summary>
        public JsonSerializer(JsonSerializer jsonSerializer)
        {
            Contract.Requires(jsonSerializer != null);
            this.jsonSerializer = jsonSerializer;
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(stream)))
            {
                return this.jsonSerializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(T value, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            {
                this.jsonSerializer.Serialize(streamWriter, value, typeof(T));
            }
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.jsonSerializer != null);
        }
    }
}