// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContainer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Container" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Container"/>.</summary>
    internal sealed class ConverterForContainer : IConverter<DetailsDataContract, Container>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Container"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Container Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            switch (value.Type)
            {
                case "Default":
                    return new DefaultContainer();
                case "GiftBox":
                    return new GiftBox();
                case "OpenUI":
                    return new OpenUiContainer();
                default:
                    return new UnknownContainer();
            }
        }
    }
}