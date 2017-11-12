// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringSerializerFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides factory methods for the string serialization engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System;
    using System.Text;

    /// <summary>Provides factory methods for the string serialization engine.</summary>
    public class StringSerializerFactory : ISerializerFactory
    {
        /// <summary>Infrastructure. Holds a reference to the character encoding.</summary>
        private readonly Encoding encoding;

        /// <summary>Initializes a new instance of the <see cref="StringSerializerFactory"/> class.</summary>
        public StringSerializerFactory()
        {
            this.encoding = Encoding.UTF8;
        }

        /// <summary>Initializes a new instance of the <see cref="StringSerializerFactory"/> class.</summary>
        /// <param name="encoding">The character encoding.</param>
        /// <exception cref="ArgumentNullException"><paramref name="encoding"/> is null.</exception>
        public StringSerializerFactory(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "Precondition: encoding != null");
            }

            this.encoding = encoding;
        }

        /// <summary>Gets a serializer for the specified type.</summary>
        /// <typeparam name="T">The serialization type.</typeparam>
        /// <returns>The <see cref="ISerializer{T}"/>.</returns>
        public ISerializer<T> GetSerializer<T>()
        {
            if (typeof(T) != typeof(string))
            {
                throw new NotSupportedException("The specified type is not supported by the string serializer.");
            }

            return (ISerializer<T>)new StringSerializer(this.encoding);
        }
    }
}