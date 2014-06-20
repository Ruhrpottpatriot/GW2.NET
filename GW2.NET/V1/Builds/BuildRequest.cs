// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for the current build ID of the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Builds
{
    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for the current build ID of the game.</summary>
    public class BuildRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.Build;
            }
        }
    }
}