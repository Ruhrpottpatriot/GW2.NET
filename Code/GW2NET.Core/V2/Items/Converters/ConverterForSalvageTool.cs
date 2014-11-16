// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSalvageTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Tool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Tools;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Tool"/>.</summary>
    internal sealed class ConverterForSalvageTool : IConverter<DetailsDataContract, Tool>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Tool"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Tool Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            return new SalvageTool
            {
                Charges = value.Charges.GetValueOrDefault()
            };
        }
    }
}