// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The skin details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details
{
    using GW2DotNET.V1.Skins.Details.Converters;

    using Newtonsoft.Json;

    /// <summary>The skin details serializer settings.</summary>
    public class SkinSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="SkinSerializerSettings"/> class.</summary>
        public SkinSerializerSettings()
        {
            this.Converters.Add(new SkinConverter());
        }
    }
}