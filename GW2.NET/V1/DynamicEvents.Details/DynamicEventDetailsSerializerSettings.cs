// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The dynamic event details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details
{
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.DynamicEvents.Details.Converters;

    using Newtonsoft.Json;

    /// <summary>The dynamic event details serializer settings.</summary>
    public class DynamicEventDetailsSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventDetailsSerializerSettings"/> class.</summary>
        public DynamicEventDetailsSerializerSettings()
        {
            this.Converters.Add(new LocationConverter());
            this.Converters.Add(new JsonPointConverter());
            this.Converters.Add(new JsonPointFConverter());
            this.Converters.Add(new JsonPoint3DConverter());
        }
    }
}