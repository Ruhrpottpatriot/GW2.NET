// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileDiscoveryRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using GW2NET.Common;

    /// <summary>Represents a discovery request that targets the /v2/files interface.</summary>
    internal sealed class FileDiscoveryRequest : DiscoveryRequest
    {
        /// <inheritdoc />
        public override string Resource
        {
            get
            {
                return "/v2/files";
            }
        }
    }
}