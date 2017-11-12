// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the AssetConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System;

    using GW2NET.Common;
    using GW2NET.Files;

    /// <summary>Converts a <see cref="FileDataContract"/> to an <see cref="Asset"/>.</summary>
    internal sealed class AssetConverter : IConverter<FileDataContract, Asset>
    {
        /// <inheritdoc />
        public Asset Convert(FileDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var asset = new Asset
            {
                Identifier = value.Id,
            };

            Uri icon;
            if (Uri.TryCreate(value.Icon, UriKind.Absolute, out icon))
            {
                asset.IconFileUrl = icon;

                // Split the path into segments
                // Format: /file/{signature}/{identifier}.{extension}
                var segments = icon.LocalPath.Split('.')[0].Split('/');
                if (segments.Length >= 3 && segments[2] != null)
                {
                    asset.FileSignature = segments[2];
                }

                int iconFileId;
                if (segments.Length >= 4 && int.TryParse(segments[3], out iconFileId))
                {
                    asset.FileId = iconFileId;
                }
            }

            return asset;
        }
    }
}