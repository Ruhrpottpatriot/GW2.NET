// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDiscriminatorAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The type discriminator attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Common
{
    using System;

    /// <summary>The type discriminator attribute.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TypeDiscriminatorAttribute : Attribute
    {
        /// <summary>Gets or sets the name.</summary>
        public string Value { get; set; }

        /// <summary>Gets or sets the base type.</summary>
        public Type BaseType { get; set; }
    }
}