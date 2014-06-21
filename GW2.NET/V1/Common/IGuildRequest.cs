// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGuildRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for guild requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;

    using GW2DotNET.Common;

    /// <summary>Provides the interface for guild requests.</summary>
    public interface IGuildRequest : IRequest
    {
        /// <summary>Gets or sets the guild identifier.</summary>
        Guid? GuildId { get; set; }

        /// <summary>Gets or sets the guild name.</summary>
        string GuildName { get; set; }
    }
}