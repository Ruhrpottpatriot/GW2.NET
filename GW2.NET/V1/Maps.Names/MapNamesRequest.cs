// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNamesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of localized map names.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Names
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of localized map names.</summary>
    public class MapNamesRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="MapNamesRequest" /> class.</summary>
        public MapNamesRequest()
            : base(Services.MapNames)
        {
        }
    }
}