// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackSkin.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a back skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Backs
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a back skin.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class BackSkin : Skin
    {
        /// <summary>Initializes a new instance of the <see cref="BackSkin" /> class.</summary>
        public BackSkin()
            : base(SkinType.Back)
        {
        }
    }
}