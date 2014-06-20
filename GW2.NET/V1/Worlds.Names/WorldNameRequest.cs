// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of worlds and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds.Names
{
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of worlds and their localized name.</summary>
    public class WorldNameRequest : IRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.WorldNames;
            }
        }
    }
}