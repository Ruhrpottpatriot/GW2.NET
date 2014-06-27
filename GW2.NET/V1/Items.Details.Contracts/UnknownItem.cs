// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownItem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown item..
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts
{
    using System.Globalization;

    using GW2DotNET.Common;

    /// <summary>Represents an unknown item..</summary>
    [TypeDiscriminator(Value = "Unknown", BaseType = typeof(Item))]
    public class UnknownItem : Item
    {
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            return this.ItemId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}