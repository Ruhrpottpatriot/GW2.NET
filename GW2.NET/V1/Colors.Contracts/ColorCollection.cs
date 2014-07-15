// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of color palettes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System.Collections.Generic;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a collection of color palettes.</summary>
    public class ColorCollection : ServiceContractDictionary<int, ColorPalette>
    {
        /// <summary>Initializes a new instance of the <see cref="ColorCollection" /> class.</summary>
        public ColorCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorCollection"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public ColorCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorCollection"/> class.</summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public ColorCollection(IDictionary<int, ColorPalette> dictionary)
            : base(dictionary)
        {
        }
    }
}