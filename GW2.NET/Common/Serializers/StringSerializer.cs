// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing strings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Serializers
{
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
        public StringSerializer(Encoding encoding)
        {
            this.encoding = encoding;
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public string Deserialize(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, this.encoding))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(string value, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream, this.encoding))
            {
                streamWriter.Write(value);
            }
        }
    }
}