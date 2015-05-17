// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RotationCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of dynamic event rotations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Local.DynamicEvents.Xml
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Wraps a collection of dynamic event rotations.</summary>
    [CollectionDataContract(Name = "rotations", ItemName = "rotation", Namespace = "")]
    public sealed class RotationCollectionContract : List<RotationContract>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotationCollectionContract"/> class that is empty and has the default initial capacity.
        /// </summary>
        public RotationCollectionContract()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RotationCollectionContract"/> class that is empty and has the specified initial capacity.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0. </exception>
        public RotationCollectionContract(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RotationCollectionContract"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public RotationCollectionContract(IEnumerable<RotationContract> collection)
            : base(collection)
        {
        }
    }
}