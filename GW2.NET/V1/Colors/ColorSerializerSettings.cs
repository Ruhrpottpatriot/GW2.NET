// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The color serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using GW2DotNET.V1.Colors.Converters;

    using Newtonsoft.Json;

    /// <summary>The color serializer settings.</summary>
    public class ColorSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="ColorSerializerSettings"/> class.</summary>
        public ColorSerializerSettings()
        {
            this.Converters.Add(new JsonColorConverter());
        }
    }
}