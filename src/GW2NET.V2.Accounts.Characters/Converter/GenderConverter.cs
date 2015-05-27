// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts the string representation of a gender into the appropriate <see cref="Gender" /> enumeration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters
{
    using System;
    using GW2NET.Characters;
    using GW2NET.Common;

    /// <summary>Converts the string representation of a gender into the appropriate <see cref="Gender"/> enumeration.</summary>
    internal sealed class GenderConverter : IConverter<string, Gender>
    {
        /// <inheritdoc />
        public Gender Convert(string value, object state)
        {
            Gender gender;

            if (!Enum.TryParse(value, out gender))
            {
                throw new ArgumentException("The passed value was not a valid gender.", "value");
            }

            return gender;
        }
    }
}