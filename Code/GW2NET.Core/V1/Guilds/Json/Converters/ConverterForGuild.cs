// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GuildDataContract" /> to objects of type <see cref="Guild" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds.Json.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Guilds;

    /// <summary>Converts objects of type <see cref="GuildDataContract"/> to objects of type <see cref="Guild"/>.</summary>
    internal sealed class ConverterForGuild : IConverter<GuildDataContract, Guild>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<EmblemDataContract, Emblem> converterForEmblem;

        /// <summary>Initializes a new instance of the <see cref="ConverterForGuild"/> class.</summary>
        internal ConverterForGuild()
            : this(new ConverterForEmblem())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForGuild"/> class.</summary>
        /// <param name="converterForEmblem">The converter for <see cref="Emblem"/>.</param>
        internal ConverterForGuild(IConverter<EmblemDataContract, Emblem> converterForEmblem)
        {
            Contract.Requires(converterForEmblem != null);
            Contract.Ensures(this.converterForEmblem != null);
            this.converterForEmblem = converterForEmblem;
        }

        /// <summary>Converts the given object of type <see cref="GuildDataContract"/> to an object of type <see cref="Guild"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Guild Convert(GuildDataContract value)
        {
            return new Guild { GuildId = Guid.Parse(value.GuildId), Name = value.Name, Tag = value.Tag, Emblem = this.converterForEmblem.Convert(value.Emblem) };
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForEmblem != null);
        }
    }
}