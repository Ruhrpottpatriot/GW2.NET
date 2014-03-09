// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of objectives and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a collection of objectives and their localized name.
    /// </summary>
    public class ObjectiveNameCollection : JsonList<ObjectiveName>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectiveNameCollection" /> class.
        /// </summary>
        public ObjectiveNameCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public ObjectiveNameCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public ObjectiveNameCollection(IEnumerable<ObjectiveName> collection)
            : base(collection)
        {
        }

        #endregion
    }
}