// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganPageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a collection of Quaggans.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Quaggans
{
    using GW2DotNET.V2.Common;

    /// <summary>Represents a request for a collection of Quaggans.</summary>
    public class QuagganPageRequest : PageRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/quaggans";
            }
        }
    }
}