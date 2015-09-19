// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GuildDTO" /> to objects of type <see cref="Guild" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.Guilds;
using GW2NET.V1.Guilds.Json;

namespace GW2NET.V1.Guilds.Converters
{
    /// <summary>Converts objects of type <see cref="GuildDTO"/> to objects of type <see cref="Guild"/>.</summary>
    public sealed class GuildConverter : IConverter<GuildDTO, Guild>
    {
        private readonly IConverter<EmblemDTO, Emblem> emblemConverter;

        /// <summary>Initializes a new instance of the <see cref="GuildConverter"/> class.</summary>
        /// <param name="emblemConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GuildConverter(IConverter<EmblemDTO, Emblem> emblemConverter)
        {
            if (emblemConverter == null)
            {
                throw new ArgumentNullException("emblemConverter");
            }

            this.emblemConverter = emblemConverter;
        }

        /// <inheritdoc />
        public Guild Convert(GuildDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                guild.Emblem = this.emblemConverter.Convert(emblem, state);
            }

            return guild;
        }
    }
}