// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="ArmorSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="ArmorSkin"/>.</summary>
    internal sealed class ArmorConverter : IConverter<DetailsDataContract, ArmorSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, ArmorSkin>> typeConverters;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, WeightClass> weightClassConverter;

        /// <summary>Initializes a new instance of the <see cref="ArmorConverter"/> class.</summary>
        public ArmorConverter()
            : this(GetKnownTypeConverters(), new WeightClassConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ArmorConverter"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForWeightClass">The converter for <see cref="WeightClass"/>.</param>
        public ArmorConverter(IDictionary<string, IConverter<DetailsDataContract, ArmorSkin>> typeConverters, IConverter<string, WeightClass> converterForWeightClass)
        {
            Contract.Requires(typeConverters != null);
            Contract.Requires(converterForWeightClass != null);
            this.weightClassConverter = converterForWeightClass;
            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public ArmorSkin Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            IConverter<DetailsDataContract, ArmorSkin> converter;

            // ReSharper disable once PossibleNullReferenceException
            ArmorSkin skin = this.typeConverters.TryGetValue(value.Type, out converter)
                                 ? converter.Convert(value)
                                 : new UnknownArmorSkin();

            if (skin == null)
            {
                return null;
            }

            var weight = value.WeightClass;
            if (weight != null)
            {
                skin.WeightClass = this.weightClassConverter.Convert(weight);
            }

            return skin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, ArmorSkin>> GetKnownTypeConverters()
        {
            Contract.Ensures(Contract.Result<IDictionary<string, IConverter<DetailsDataContract, ArmorSkin>>>() != null);
            return new Dictionary<string, IConverter<DetailsDataContract, ArmorSkin>>
                       {
                           { "Boots", new ConverterForObject<BootsSkin>() }, 
                           { "Coat", new ConverterForObject<CoatSkin>() }, 
                           { "Helm", new ConverterForObject<HelmSkin>() }, 
                           { "Shoulders", new ConverterForObject<ShouldersSkin>() }, 
                           { "Gloves", new ConverterForObject<GlovesSkin>() }, 
                           { "Leggings", new ConverterForObject<LeggingsSkin>() }, 
                           { "HelmAquatic", new ConverterForObject<HelmAquaticSkin>() }, 
                       };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.weightClassConverter != null);
        }
    }
}