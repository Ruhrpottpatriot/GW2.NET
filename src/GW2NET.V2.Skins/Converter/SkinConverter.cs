// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Skins
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="SkinDataContract"/> to objects of type <see cref="Skin"/>.</summary>
    internal sealed class SkinConverter : IConverter<SkinDataContract, Skin>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, SkinFlags> skinFlagsConverter;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Skin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="SkinConverter"/> class.</summary>
        public SkinConverter()
            : this(GetKnownTypeConverters(), new ItemRestrictionCollectionConverter(), new SkinFlagCollectionConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinConverter"/> class.</summary>
        /// <param name="knownTypeConverters">The known type converters.</param>
        /// <param name="itemRestrictionsConverter">The item restrictions converter.</param>
        /// <param name="skinFlagsConverter">The skin flags converter.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="knownTypeConverters"/> or <paramref name="itemRestrictionsConverter"/> or <paramref name="skinFlagsConverter"/> is a null reference.</exception>
        private SkinConverter(IDictionary<string, IConverter<DetailsDataContract, Skin>> knownTypeConverters, IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter, IConverter<ICollection<string>, SkinFlags> skinFlagsConverter)
        {
            if (knownTypeConverters == null)
            {
                throw new ArgumentNullException("knownTypeConverters", "Precondition: knownTypeConverters != null");
            }

            if (itemRestrictionsConverter == null)
            {
                throw new ArgumentNullException("itemRestrictionsConverter", "Precondition: itemRestrictionsConverter != null");
            }

            if (skinFlagsConverter == null)
            {
                throw new ArgumentNullException("skinFlagsConverter", "Precondition: skinFlagsConverter != null");
            }

            this.itemRestrictionsConverter = itemRestrictionsConverter;
            this.skinFlagsConverter = skinFlagsConverter;
            this.typeConverters = knownTypeConverters;
        }

        /// <inheritdoc />
        public Skin Convert(SkinDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<DetailsDataContract, Skin> converter;
            Skin skin;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                skin = converter.Convert(value.Details);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                skin = new UnknownSkin();
            }

            skin.SkinId = value.Id;
            skin.Name = value.Name;

            var flags = value.Flags;
            if (flags != null)
            {
                skin.Flags = this.skinFlagsConverter.Convert(flags);
            }

            var restrictions = value.Restrictions;
            if (restrictions != null)
            {
                skin.Restrictions = this.itemRestrictionsConverter.Convert(restrictions);
            }

            // Process the URI. Note since the V2 api the URI doesn't have to be built by hand anymore.
            // It is stored as a a string in the response.
            // Question: Shouled we split the URI for user convenience or not??
            skin.IconFileUrl = new Uri(value.IconUrl, UriKind.Absolute);

            return skin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Skin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Skin>>
            {
                { "Armor", new ArmorConverter() },
                { "Back", new BackpackConverter() },
                { "Gathering", new GatherinToolConverter() },
                { "Weapon", new WeaponConverter() }
            };
        }
    }
}