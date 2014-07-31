// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the current build of the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Builds.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents the current build of the game.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build" /> for more information.</remarks>
    public sealed class BuildContract : ServiceContract
    {
        /// <summary>Gets or sets the current build identifier of the game.</summary>
        [DataMember(Name = "build_id", Order = 0)]
        public int BuildId { get; set; }
    }
}