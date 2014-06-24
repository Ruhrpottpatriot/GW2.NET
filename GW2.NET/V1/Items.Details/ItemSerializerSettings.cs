// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The item details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details
{
    using GW2DotNET.V1.Items.Details.Converters;

    using Newtonsoft.Json;

    /// <summary>The item details serializer settings.</summary>
    public class ItemSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="ItemSerializerSettings"/> class.</summary>
        public ItemSerializerSettings()
        {
            this.Converters.Add(new ItemConverter());
            this.Converters.Add(new UpgradeComponentConverter());
            this.Converters.Add(new ArmorConverter());
            this.Converters.Add(new BackpackConverter());
            this.Converters.Add(new BagConverter());
            this.Converters.Add(new ConsumableConverter());
            this.Converters.Add(new UnlockerConverter());
            this.Converters.Add(new ContainerConverter());
            this.Converters.Add(new GatheringToolConverter());
            this.Converters.Add(new GizmoConverter());
            this.Converters.Add(new ToolConverter());
            this.Converters.Add(new TrinketConverter());
            this.Converters.Add(new WeaponConverter());
        }
    }
}