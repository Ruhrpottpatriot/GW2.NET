// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AggregateOffer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents aggregated buy or sell offer information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Commerce
{
    using System.Globalization;

    /// <summary>Represents aggregated buy or sell offer information.</summary>
    public sealed class AggregateOffer
    {
        /// <summary>Gets or sets the total number of items listed.</summary>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the highest buy order or lowest sell order.</summary>
        public int UnitPrice { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.UnitPrice.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}