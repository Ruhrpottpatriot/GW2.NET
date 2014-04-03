// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific guild.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Details
{
    using System;

    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for information regarding a specific guild.</summary>
    public class GuildDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private Guid? guildId;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private string guildName;

        /// <summary>Initializes a new instance of the <see cref="GuildDetailsRequest" /> class.</summary>
        public GuildDetailsRequest()
            : base(Services.GuildDetails)
        {
        }

        /// <summary>Gets or sets the guild ID.</summary>
        public Guid? GuildId
        {
            get
            {
                return this.guildId;
            }

            set
            {
                this.Query["guild_id"] = (this.guildId = value).ToString();
            }
        }

        /// <summary>Gets or sets the guild name.</summary>
        public string GuildName
        {
            get
            {
                return this.guildName;
            }

            set
            {
                this.Query["guild_name"] = this.guildName = value;
            }
        }
    }
}