// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FileDTO" /> to objects of type <see cref="Asset" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Files.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.V1.Files.Json;

    /// <summary>Converts objects of type <see cref="FileDTO"/> to objects of type <see cref="Asset"/>.</summary>
    public sealed class AssetConverter : IConverter<FileDTO, Asset>
    {
        /// <inheritdoc />
        public Asset Convert(FileDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var iconUrl = string.Format(IconUrlTemplate, value.Signature, value.FileId, "png");
            return new Asset
            {
                FileId = value.FileId,
                FileSignature = value.Signature,
                IconFileUrl = new Uri(iconUrl, UriKind.Absolute)
            };
        }
    }
}