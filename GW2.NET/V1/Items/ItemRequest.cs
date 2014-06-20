// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of all discovered items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items
{
    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of all discovered items.</summary>
    public class ItemRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.Items;
            }
        }
    }
}