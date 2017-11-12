// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAsset.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FileDataContract" /> to objects of type <see cref="Asset" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Files;
using GW2NET.V1.Files.Json;

namespace GW2NET.V1.Files.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="FileDataContract"/> to objects of type <see cref="Asset"/>.</summary>
    internal sealed class ConverterForAsset : IConverter<FileDataContract, Asset>
    {
        /// <inheritdoc />
        public Asset Convert(FileDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
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
