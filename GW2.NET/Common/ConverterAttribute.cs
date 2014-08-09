// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Specifies a converter for a type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System;

    /// <summary>Specifies a converter for a type.</summary>
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = true, Inherited = true)]
    public sealed class ConverterAttribute : Attribute
    {
        /// <summary>Backing field.</summary>
        private readonly Type type;

        /// <summary>Initializes a new instance of the <see cref="ConverterAttribute"/> class.</summary>
        /// <param name="type">The converter type.</param>
        public ConverterAttribute(Type type)
        {
            this.type = type;
        }

        /// <summary>Gets the converter type.</summary>
        public Type Type
        {
            get
            {
                return this.type;
            }
        }
    }
}