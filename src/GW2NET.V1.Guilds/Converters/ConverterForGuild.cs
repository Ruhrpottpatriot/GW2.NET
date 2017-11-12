// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GuildDataContract" /> to objects of type <see cref="Guild" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.Guilds;
using GW2NET.V1.Guilds.Json;

namespace GW2NET.V1.Guilds.Converters
{
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
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForEmblem"/> is a null reference.</exception>
        internal ConverterForGuild(IConverter<EmblemDataContract, Emblem> converterForEmblem)
        {
            if (converterForEmblem == null)
            {
                throw new ArgumentNullException("converterForEmblem", "Precondition: converterForEmblem != null");
            }

            this.converterForEmblem = converterForEmblem;
        }

        /// <inheritdoc />
        public Guild Convert(GuildDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

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
    }
}