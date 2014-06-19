// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a resource details request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    /// <summary>Represents a resource details request.</summary>
    public class DetailsRequest : IDetailsRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        public int Identifier { get; set; }

        /// <summary>Gets or sets the resource path.</summary>
        public string Resource { get; set; }
    }
}