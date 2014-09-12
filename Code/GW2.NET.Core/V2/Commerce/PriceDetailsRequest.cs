using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V2.Commerce
{
    using GW2DotNET.V2.Common;

    /// <summary>The price details request.</summary>
    public class PriceDetailsRequest : DetailsRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/commerce/prices/" + this.Identifier;
            }
        }
    }
}
