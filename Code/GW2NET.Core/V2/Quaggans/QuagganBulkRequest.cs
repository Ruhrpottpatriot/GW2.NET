// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganBulkRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a collection of Quaggans.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans
{
    using GW2NET.V2.Common;

    /// <summary>Represents a request for a collection of Quaggans.</summary>
    internal sealed class QuagganBulkRequest : BulkRequest
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