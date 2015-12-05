// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDataContract" /> to objects of type <see cref="Skin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.Skins;
using GW2NET.V1.Skins.Json;

namespace GW2NET.V1.Skins.Converters
{
    /// <summary>Converts objects of type <see cref="SkinDataContract"/> to objects of type <see cref="Skin"/>.</summary>
    internal sealed class ConverterForSkin : IConverter<SkinDataContract, Skin>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, ItemRestrictions> converterForItemRestrictions;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, SkinFlags> converterForSkinFlags;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<SkinDataContract, Skin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkin"/> class.</summary>
        public ConverterForSkin()
            : this(GetKnownTypeConverters(), new ConverterForItemRestrictionCollection(), new ConverterForSkinFlagCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkin"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForItemRestrictions">The converter for <see cref="ItemRestrictions"/>.</param>
        /// <param name="converterForSkinFlags">The converter for <see cref="SkinFlags"/>.</param>
        public ConverterForSkin(IDictionary<string, IConverter<SkinDataContract, Skin>> typeConverters, IConverter<ICollection<string>, ItemRestrictions> converterForItemRestrictions, IConverter<ICollection<string>, SkinFlags> converterForSkinFlags)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForItemRestrictions == null)
            {
                throw new ArgumentNullException("converterForItemRestrictions", "Precondition: converterForItemRestrictions != null");
            }

            if (converterForSkinFlags == null)
            {
                throw new ArgumentNullException("converterForSkinFlags", "Precondition: converterForSkinFlags != null");
            }

            this.converterForItemRestrictions = converterForItemRestrictions;
            this.converterForSkinFlags = converterForSkinFlags;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="SkinDataContract"/> to an object of type <see cref="Skin"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Skin Convert(SkinDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Skin skin;
            IConverter<SkinDataContract, Skin> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                skin = converter.Convert(value);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                skin = new UnknownSkin();
            }

            skin.Name = value.Name;

            var flags = value.Flags;
            if (flags != null)
            {
                skin.Flags = this.converterForSkinFlags.Convert(flags);
            }

            var restrictions = value.Restrictions;
            if (restrictions != null)
            {
                skin.Restrictions = this.converterForItemRestrictions.Convert(restrictions);
            }

            int iconFileId;
            if (int.TryParse(value.IconFileId, out iconFileId))
            {
                skin.IconFileId = iconFileId;
            }

            // Set the icon file signature
            skin.IconFileSignature = value.IconFileSignature;

            // Set the icon file URL
            const string IconUrlTemplate = @"https://render.guildwars2.com/file/{0}/{1}.{2}";
            var iconUrl = string.Format(IconUrlTemplate, value.IconFileSignature, value.IconFileId, "png");
            skin.IconFileUrl = new Uri(iconUrl, UriKind.Absolute);

            return skin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<SkinDataContract, Skin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<SkinDataContract, Skin>>
            {
                { "Armor", new ConverterForArmorSkin() }, 
                { "Back", new ConverterForBackpackSkin() }, 
                { "Weapon", new ConverterForWeaponSkin() }
            };
        }
    }
}