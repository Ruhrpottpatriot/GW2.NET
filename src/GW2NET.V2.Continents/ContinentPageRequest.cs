// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentPageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a page request that targets the /v2/continents interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents
{
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a page request that targets the /v2/continents interface.</summary>
    public sealed class ContinentPageRequest : PageRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/continents";
            }
        }
    }
}