// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The map serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>The map serializer settings.</summary>
    public class MapSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="MapSerializerSettings"/> class.</summary>
        public MapSerializerSettings()
        {
            this.Converters.Add(new JsonRectangleConverter());
        }
    }
}