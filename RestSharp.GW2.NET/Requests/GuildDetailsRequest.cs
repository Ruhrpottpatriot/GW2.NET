// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific guild.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.GuildInformation.Details;

    /// <summary>
    ///     Represents a request for information regarding a specific guild.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details" /> for more information.
    /// </remarks>
    public class GuildDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter guildIdParameter;

        /// <summary>Infrastructure. Stores a parameter.</summary>
        private readonly Parameter guildNameParameter;

        /// <summary>The guild ID.</summary>
        private Guid? guildId;

        /// <summary>The guild name.</summary>
        private string guildName;

        /// <summary>Initializes a new instance of the <see cref="GuildDetailsRequest"/> class.</summary>
        public GuildDetailsRequest()
            : base(Services.GuildDetails)
        {
            this.AddParameter(this.guildIdParameter = new Parameter { Name = "guild_id", Value = string.Empty, Type = ParameterType.GetOrPost });
            this.AddParameter(this.guildNameParameter = new Parameter { Name = "guild_name", Value = string.Empty, Type = ParameterType.GetOrPost });
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
                this.guildIdParameter.Value = (this.guildId = value).ToString();
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
                this.guildNameParameter.Value = this.guildName = value;
            }
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Guild> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<Guild>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Guild>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<Guild>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Guild>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<Guild>(serviceClient, cancellationToken);
        }
    }
}