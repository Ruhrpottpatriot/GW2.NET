// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objectives.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    /// <summary>
    /// Represents a collection of a World versus World map objectives.
    /// </summary>
    public class Objectives : JsonList<Objective>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Objectives"/> class.
        /// </summary>
        public Objectives()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Objectives"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public Objectives(IEnumerable<Objective> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Objectives"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Objectives(int capacity)
            : base(capacity)
        {
        }
    }
}