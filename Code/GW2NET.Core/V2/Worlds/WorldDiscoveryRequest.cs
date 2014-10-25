using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.V2.Worlds
{
    using GW2NET.Common;

    internal sealed class WorldDiscoveryRequest : DiscoveryRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/worlds";
            }
        }
    }
}
