// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of the currently running World versus World matches, with the participating worlds included in the result.</summary>
    public class MatchServiceRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="MatchServiceRequest" /> class.</summary>
        public MatchServiceRequest()
            : base(Services.Matches)
        {
        }
    }
}