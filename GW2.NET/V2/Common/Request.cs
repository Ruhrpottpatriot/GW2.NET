// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Request.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a simple resource request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    /// <summary>Represents a simple resource request.</summary>
    public class Request : IRequest
    {
        /// <summary>Gets or sets the resource path.</summary>
        public string Resource { get; set; }
    }
}