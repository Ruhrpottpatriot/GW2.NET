// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForForagingTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GatheringToolDataContract" /> to objects of type <see cref="ForagingTool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="GatheringToolDataContract"/> to objects of type <see cref="ForagingTool"/>.</summary>
    internal sealed class ConverterForForagingTool : IConverter<GatheringToolDataContract, ForagingTool>
    {
        /// <summary>Converts the given object of type <see cref="GatheringToolDataContract"/> to an object of type <see cref="ForagingTool"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ForagingTool Convert(GatheringToolDataContract value)
        {
            Contract.Assume(value != null);
            return new ForagingTool();
        }
    }
}