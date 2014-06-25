// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The dynamic event details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>The dynamic event details serializer settings.</summary>
    public class ContinentSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="ContinentSerializerSettings"/> class.</summary>
        public ContinentSerializerSettings()
        {
            this.Converters.Add(new JsonSizeConverter());
        }
    }
}