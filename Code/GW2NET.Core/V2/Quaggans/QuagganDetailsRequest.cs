// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a details request that targets the /v2/quaggans interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans
{
    using GW2NET.V2.Common;

    /// <summary>Represents a details request that targets the /v2/quaggans interface.</summary>
    internal sealed class QuagganDetailsRequest : DetailsRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        public override string Identifier { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/quaggans/" + this.Identifier;
            }
        }
    }
}