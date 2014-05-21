// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gem upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents.UpgradeComponentTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a gem upgrade component.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Gem : UpgradeComponent
    {
        /// <summary>Initializes a new instance of the <see cref="Gem" /> class.</summary>
        public Gem()
            : base(UpgradeComponentType.Gem)
        {
        }
    }
}