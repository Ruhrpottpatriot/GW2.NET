// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding a specific skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details
{
    using GW2DotNET.Extensions;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding a specific skin.</summary>
    public class SkinDetailsRequest : ServiceRequest
    {
        /// <summary>Infrastructure. Stores a parameter.</summary>
        private int? skinId;

        /// <summary>Initializes a new instance of the <see cref="SkinDetailsRequest" /> class.</summary>
        public SkinDetailsRequest()
            : base(Services.SkinDetails)
        {
        }

        /// <summary>Gets or sets the skin identifier.</summary>
        public int? SkinId
        {
            get
            {
                return this.skinId;
            }

            set
            {
                this.Query["skin_id"] = (this.skinId = value).ToStringInvariant();
            }
        }
    }
}