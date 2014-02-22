// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.WvW.ObjectiveNames.Converters;
using GW2DotNET.V1.Core.WvW.ObjectiveNames.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.ObjectiveNames
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="ObjectiveNamesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(ObjectiveNamesResponseConverter))]
    public class ObjectiveNamesResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the list of objectives.
        /// </summary>
        public IEnumerable<Objective> Objectives { get; set; }
    }
}