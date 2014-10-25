using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.V2.Worlds
{
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.V2.Common;

    internal sealed class WorldDetailsRequest : DetailsRequest, ILocalizable
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/worlds/" + this.Identifier;
            }
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            foreach (var parameter in base.GetParameters())
            {
                yield return parameter;
            }

            var culture = this.Culture;
            if (culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", culture.TwoLetterISOLanguageName);
            }
        }
    }
}
