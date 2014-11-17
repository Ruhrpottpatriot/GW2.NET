// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GuildDataContract" /> to objects of type <see cref="Guild" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Guilds;

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
            Contract.Assume(value != null);
            var guild = new Guild
            {
                Name = value.Name, 
                Tag = value.Tag, 
            };

            Guid id;
            if (Guid.TryParse(value.GuildId, out id))
            {
                guild.GuildId = id;
            }

            var emblem = value.Emblem;
            if (emblem != null)
            {
                guild.Emblem = this.converterForEmblem.Convert(emblem);
            }

            return guild;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForEmblem != null);
        }
    }
}