// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Guilds.DataProvider;

namespace GW2DotNET.V1.Guilds
{
    /// <summary>
    /// Contains methods and properties to get and modify the guilds from the API.
    /// </summary>
    public class GuildManager
    {
        /// <summary>
        /// The guild data.
        /// </summary>
        private GuildData guildData;

        /// <summary>
        /// Gets the guild data.
        /// </summary>
        public GuildData GuildData
        {
            get
            {
                return this.guildData ?? (this.guildData = new GuildData());
            }
        }
    }
}
