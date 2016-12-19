// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveV2DetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ObjectiveV2DetailsRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Globalization;
using GW2NET.Common;

namespace GW2NET.V2.WorldVersusWorld.Objectives
{
    public sealed class ObjectiveDetailsRequest : DetailsRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "v2/wvw/objectives";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        protected override IEnumerable<KeyValuePair<string, string>> GetParameters(string id)
        {
            // Get the 'lang' parameter
            if (this.Culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", this.Culture.TwoLetterISOLanguageName);
            }
        }
    }
}
