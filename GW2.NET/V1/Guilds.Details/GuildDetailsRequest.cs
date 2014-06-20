// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsRequest.cs" company="GW2.NET Coding Team">
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
    public class GuildDetailsRequest : IGuildRequest
    {
        /// <summary>Gets or sets the guild identifier.</summary>
        public Guid? GuildId { get; set; }

        /// <summary>Gets or sets the guild name.</summary>
        public string GuildName { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.GuildDetails;
            }
        }
    }
}