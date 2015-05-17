// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing JSON objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    /// <summary>Provides methods for serializing JSON objects.</summary>
    /// <typeparam name="T">The type that is being serialized.</typeparam>
    public class JsonSerializer<T> : ISerializer<T>
    {
        /// <summary>Infrastructure. Holds a reference to the Json.NET serializer.</summary>
        private readonly JsonSerializer jsonSerializer;

        /// <summary>Initializes a new instance of the <see cref="JsonSerializer{T}"/> class.</summary>
        /// <param name="jsonSerializer">The Json.NET serializer.</param>
        /// <exception cref="ArgumentNullException">The value of <see cref="jsonSerializer"/> is a null reference.</exception>
        public JsonSerializer(JsonSerializer jsonSerializer)
        {
            if (jsonSerializer == null)
            {
                throw new ArgumentNullException("jsonSerializer", "Precondition: jsonSerializer != null");
            }

            this.jsonSerializer = jsonSerializer;
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(stream)))
            {
                try
                {
                    return this.jsonSerializer.Deserialize<T>(jsonReader);
                }
                catch (JsonReaderException jsonReaderException)
                {
                    throw new SerializationException("An error occurred while reading JSON data. See the inner exception for details.", jsonReaderException);
                }
                catch (JsonSerializationException jsonSerializationException)
                {
                    throw new SerializationException("An error occurred while deserializing JSON data. See the inner exception for details.", jsonSerializationException);
                }
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        public void Serialize(T value, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            {
                try
                {
                    this.jsonSerializer.Serialize(streamWriter, value, typeof(T));
                }
                catch (JsonWriterException jsonWriterException)
                {
                    throw new SerializationException("An error occurred while writing JSON data. See the inner exception for details.", jsonWriterException);
                }
                catch (JsonSerializationException jsonSerializationException)
                {
                    throw new SerializationException("An error occurred while serializing JSON data. See the inner exception for details.", jsonSerializationException);
                }
            }
        }
    }
}