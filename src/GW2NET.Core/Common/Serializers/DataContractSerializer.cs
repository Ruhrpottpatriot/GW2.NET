// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContractSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing data contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>Provides methods for serializing data contracts.</summary>
    /// <typeparam name="T">The type of the data contract.</typeparam>
    public class DataContractSerializer<T> : ISerializer<T>
    {
        private readonly XmlObjectSerializer serializer;

        /// <summary>Initializes a new instance of the <see cref="DataContractSerializer{T}"/> class.</summary>
        /// <param name="serializer">The serializer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serializer"/> is null.</exception>
        public DataContractSerializer(XmlObjectSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            this.serializer = serializer;
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            using (stream)
            {
                var value = this.serializer.ReadObject(stream);
                if (value == null)
                {
                    return default(T);
                }

                return (T)value;
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(T value, Stream stream)
        {
            using (stream)
            {
                this.serializer.WriteObject(stream, value);
            }
        }
    }
}