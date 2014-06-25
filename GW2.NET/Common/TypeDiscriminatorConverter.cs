// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDiscriminatorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for converters that can read specific types based on a discriminator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>Provides the base class for converters that can read specific types based on a discriminator.</summary>
    /// <typeparam name="T">The base type.</typeparam>
    public abstract class TypeDiscriminatorConverter<T> : JsonConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        protected readonly IDictionary<string, Type> KnownTypes = new Dictionary<string, Type>();

        /// <summary>Initializes a new instance of the <see cref="TypeDiscriminatorConverter{T}"/> class.</summary>
        protected TypeDiscriminatorConverter()
        {
            var baseType = typeof(T);
            var types = baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType)).AsEnumerable();
            foreach (var type in types)
            {
                var discriminator = type.GetCustomAttributes(typeof(TypeDiscriminatorAttribute), false).SingleOrDefault() as TypeDiscriminatorAttribute;
                if (discriminator == null)
                {
                    continue;
                }

                if (discriminator.BaseType == baseType || type.BaseType == baseType)
                {
                    this.KnownTypes.Add(discriminator.Value, type);
                }
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter"/> can read JSON.</summary>
        /// <value><c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter"/> can read JSON; otherwise, <c>false</c>.</value>
        public override sealed bool CanRead
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON.</summary>
        /// <value><c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter"/> can write JSON; otherwise, <c>false</c>.</value>
        public override sealed bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override sealed bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override sealed void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException();
        }
    }
}