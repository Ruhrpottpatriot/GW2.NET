// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkColorRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding colors in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Colors
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V2.Common;

    /// <summary>Represents a request for information regarding colors in the game.</summary>
    public class BulkColorRequest : BulkRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the identifiers.</summary>
        public override ICollection<int> Identifiers { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "v2/colors";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public override IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get base parameters
            foreach (var parameter in base.GetParameters())
            {
                yield return parameter;
            }

            // Get the 'lang' parameter
            if (this.Culture != null)
            {
                yield return new KeyValuePair<string, string>("lang", this.Culture.TwoLetterISOLanguageName);
            }
        }
    }
}