// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContractJsonSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing JSON data contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.IO;
    using System.Runtime.Serialization.Json;

    /// <summary>Provides methods for serializing JSON data contracts.</summary>
    /// <typeparam name="T">The type of the data contract.</typeparam>
    public class DataContractJsonSerializer<T> : ISerializer<T>
    {
        
        private readonly DataContractJsonSerializer serializer;

        /// <summary>Initializes a new instance of the <see cref="DataContractJsonSerializer{T}"/> class.</summary>
        public DataContractJsonSerializer()
        {
            this.serializer = new DataContractJsonSerializer(typeof(T));
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            using (stream)
            {
                try
                {
                    var value = this.serializer.ReadObject(stream);
                    if (value == null)
                    {
                        return default(T);
                    }

                    return (T)value;
                }
                catch (System.Runtime.Serialization.SerializationException serializationException)
                {
                    throw new SerializationException("An error occurred while deserializing JSON data. See the inner exception for details.", serializationException);
                }
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        public void Serialize(T value, Stream stream)
        {
            using (stream)
            {
                try
                {
                    this.serializer.WriteObject(stream, value);
                }
                catch (System.Runtime.Serialization.SerializationException serializationException)
                {
                    throw new SerializationException("An error occurred while serializing JSON data. See the inner exception for details.", serializationException);
                }
            }
        }
    }
}