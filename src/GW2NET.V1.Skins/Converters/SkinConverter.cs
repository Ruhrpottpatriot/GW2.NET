// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDTO" /> to objects of type <see cref="Skin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Json;

    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="Skin"/>.</summary>
    public partial class SkinConverter
    {
        private readonly IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter;

        private readonly IConverter<ICollection<string>, SkinFlags> skinFlagsConverter;

        /// <summary>Initializes a new instance of the <see cref="SkinConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="itemRestrictionsConverter">The converter for <see cref="ItemRestrictions"/>.</param>
        /// <param name="skinFlagsConverter">The converter for <see cref="SkinFlags"/>.</param>
        public SkinConverter(
            ITypeConverterFactory<SkinDTO, Skin> converterFactory,
            IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter,
            IConverter<ICollection<string>, SkinFlags> skinFlagsConverter)
            : this(converterFactory)
        {
            if (itemRestrictionsConverter == null)
            {
                throw new ArgumentNullException("itemRestrictionsConverter");
            }

            if (skinFlagsConverter == null)
            {
                throw new ArgumentNullException("skinFlagsConverter");
            }

            this.itemRestrictionsConverter = itemRestrictionsConverter;
            this.skinFlagsConverter = skinFlagsConverter;
        }

        partial void Merge(Skin entity, SkinDTO dto, object state)
        {
            int skinId;
            if (int.TryParse(dto.SkinId, out skinId))
            {
                entity.SkinId = skinId;
            }

            entity.Name = dto.Name;

            var flags = dto.Flags;
            if (flags != null)
            {
                entity.Flags = this.skinFlagsConverter.Convert(flags, dto);
            }

            var restrictions = dto.Restrictions;
            if (restrictions != null)
            {
                entity.Restrictions = this.itemRestrictionsConverter.Convert(restrictions, dto);
            }

            int iconFileId;
            if (int.TryParse(dto.IconFileId, out iconFileId))
            {
                entity.IconFileId = iconFileId;
            }

            // Set the icon file signature
            entity.IconFileSignature = dto.IconFileSignature;

            // Set the icon file URL
            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var iconUrl = string.Format(IconUrlTemplate, dto.IconFileSignature, dto.IconFileId, "png");
            entity.IconFileUrl = new Uri(iconUrl, UriKind.Absolute);
        }
    }
}