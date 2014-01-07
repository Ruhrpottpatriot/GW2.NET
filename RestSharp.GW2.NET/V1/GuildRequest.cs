using GW2DotNET.V1.Core;
using GW2DotNET.V1.Guilds.Models;
using System;
using System.Threading.Tasks;

namespace RestSharp.GW2DotNET.V1
{
    public class GuildRequest : ApiRequest
    {
        public GuildRequest(Guid guildId)
            : base(new Uri("guild_details.json?guild_id={guild_id}", UriKind.Relative))
        {
            if (guildId == Guid.Empty)
            {
                throw new ArgumentNullException("guildId");
            }
            InnerRequest.AddUrlSegment("guild_id", guildId.ToString());
        }

        public GuildRequest(string guildName)
            : base(new Uri("guild_details.json?guild_name={guild_name}", UriKind.Relative))
        {
            if (string.IsNullOrWhiteSpace(guildName))
            {
                throw new ArgumentNullException("guildName");
            }
            InnerRequest.AddUrlSegment("guild_name", guildName);
        }

        public IApiResponse<Guild> GetResponse(IApiClient handler)
        {
            return base.GetResponse<Guild>(handler);
        }

        public Task<IApiResponse<Guild>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<Guild>(handler);
        }

    }
}
