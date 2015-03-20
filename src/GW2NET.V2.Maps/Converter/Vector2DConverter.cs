// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector2DConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector2D"/>.</summary>
    internal sealed class Vector2DConverter : IConverter<double[], Vector2D>
    {
        /// <inheritdoc />
        public Vector2D Convert(double[] value)
        {
            Contract.Assume(value != null);
            // ReSharper disable once PossibleNullReferenceException
            Contract.Assume(value.Length == 2);
            return new Vector2D(value[0], value[1]);
        }
    }
}