// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Specifies that a class, method or delegate is a converter for a type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;

    /// <summary>Specifies that a class, method or delegate is a converter for a type.</summary>
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Delegate, AllowMultiple = true, Inherited = true)]
    public sealed class ConverterForAttribute : Attribute
    {
        /// <summary>Backing field.</summary>
        private readonly Type type;

        /// <summary>Initializes a new instance of the <see cref="ConverterForAttribute"/> class.</summary>
        /// <param name="type">The conversion type.</param>
        public ConverterForAttribute(Type type)
        {
            this.type = type;
        }

        /// <summary>Gets the conversion type.</summary>
        public Type Type
        {
            get
            {
                return this.type;
            }
        }
    }
}