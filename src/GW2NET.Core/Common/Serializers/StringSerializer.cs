// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing strings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>Provides methods for serializing strings.</summary>
    public class StringSerializer : ISerializer<string>
    {
        /// <summary>Infrastructure. Holds a reference to the character encoding.</summary>
        private readonly Encoding encoding;

        /// <summary>Initializes a new instance of the <see cref="StringSerializer"/> class.</summary>
        public StringSerializer()
            : this(Encoding.UTF8)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="StringSerializer"/> class.</summary>
        /// <param name="encoding">The character encoding.</param>
        /// <exception cref="ArgumentNullException"><paramref name="encoding"/> is null.</exception>
        public StringSerializer(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "Precondition: encoding != null");
            }

            this.encoding = encoding;
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        /// <returns>An instance of the specified type.</returns>
        public string Deserialize(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, this.encoding))
            {
                try
                {
                    return streamReader.ReadToEnd();
                }
                catch (IOException exception)
                {
                    throw new SerializationException("An error occurred while deserializing character data. See the inner exception for details.", exception);
                }
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        public void Serialize(string value, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream, this.encoding))
            {
                try
                {
                    streamWriter.Write(value);
                }
                catch (IOException exception)
                {
                    throw new SerializationException("An error occurred while serializing character data. See the inner exception for details.", exception);
                }
            }
        }
    }
}