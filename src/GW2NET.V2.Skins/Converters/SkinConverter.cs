// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Json;

    public partial class SkinConverter
    {
        private readonly IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter;

        private readonly IConverter<ICollection<string>, SkinFlags> skinFlagsConverter;

        /// <summary>Initializes a new instance of the <see cref="SkinConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="itemRestrictionsConverter">The item restrictions converter.</param>
        /// <param name="skinFlagsConverter">The skin flags converter.</param>
        /// <exception cref="ArgumentNullException"></exception>
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
            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            entity.Culture = response.Culture;
            entity.SkinId = dto.Id;
            entity.Name = dto.Name;

            if (dto.Flags != null)
            {
                entity.Flags = this.skinFlagsConverter.Convert(dto.Flags, state);
            }

            if (dto.Restrictions != null)
            {
                entity.Restrictions = this.itemRestrictionsConverter.Convert(dto.Restrictions, state);
            }

            // Process the URI. Note since the V2 api the URI doesn't have to be built by hand anymore.
            // It is stored as a a string in the response.
            // Question: Shouled we split the URI for user convenience or not??
            // TODO: yes we should split the URI. Not for convencience, but because 'Skin' implements 'IRenderable'
            entity.IconFileUrl = new Uri(dto.IconUrl, UriKind.Absolute);
        }
    }
}