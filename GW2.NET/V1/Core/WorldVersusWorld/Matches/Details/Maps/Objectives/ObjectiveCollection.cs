// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of a World versus World map objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.WorldVersusWorld.Matches.Details.Maps.Objectives
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common;

    /// <summary>
    ///     Represents a collection of a World versus World map objectives.
    /// </summary>
    public class ObjectiveCollection : JsonList<Objective>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectiveCollection" /> class.
        /// </summary>
        public ObjectiveCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public ObjectiveCollection(IEnumerable<Objective> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public ObjectiveCollection(int capacity)
            : base(capacity)
        {
        }
    }
}