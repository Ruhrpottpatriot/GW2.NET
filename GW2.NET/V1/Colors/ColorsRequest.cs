// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding colors in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for information regarding colors in the game.</summary>
    public class ColorsRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="ColorsRequest" /> class.</summary>
        public ColorsRequest()
            : base(Services.Colors)
        {
        }
    }
}