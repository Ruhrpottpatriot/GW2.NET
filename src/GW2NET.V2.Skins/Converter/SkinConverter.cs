// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the SkinConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        private SkinConverter(IDictionary<string, IConverter<DetailsDataContract, Skin>> knownTypeConverters, IConverter<ICollection<string>, ItemRestrictions> itemRestrictionsConverter, IConverter<ICollection<string>, SkinFlags> skinFlagsConverter)
        {
            Contract.Requires(knownTypeConverters != null);
            Contract.Requires(itemRestrictionsConverter != null);
            Contract.Requires(skinFlagsConverter != null);
            this.itemRestrictionsConverter = itemRestrictionsConverter;
            this.skinFlagsConverter = skinFlagsConverter;
            this.typeConverters = knownTypeConverters;
        }

        /// <inheritdoc />
        public Skin Convert(SkinDataContract value)
        {
            Contract.Assume(value != null);

            IConverter<DetailsDataContract, Skin> converter;

            // ReSharper disable once PossibleNullReferenceException
            Skin skin = this.typeConverters.TryGetValue(value.Type, out converter)
                            ? converter.Convert(value.Details)
                            : new UnknownSkin();

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
                { "Weapon", new WeaponConverter() }
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.itemRestrictionsConverter != null);
            Contract.Invariant(this.skinFlagsConverter != null);
            Contract.Invariant(this.typeConverters != null);
        }
    }
}