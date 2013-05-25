// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get or modify the map data.
    /// </summary>
    public class MapData : IList<GwMap>
    {
        /// <summary>
        /// Cache the map_names data here
        /// </summary>
        private List<GwMap> gwMapCache = null;

        /// <summary>
        /// Retrieve the maps in this language
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="language">The language in which to return names</param>
        internal MapData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets the number of items in the collection
        /// </summary>
        public int Count
        {
            get { return this.Maps.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the map collection is read only
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.Maps.IsReadOnly; }
        }

        /// <summary>
        /// Gets the maps from the API.
        /// This field is private and is not directly exposed.
        /// Instead, we implement IList on the parent class and
        /// pass the calls through to this object.
        /// </summary>
        /// <returns>The <see cref="IList"/> of maps.</returns>
        private IList<GwMap> Maps
        {
            get
            {
                if (this.gwMapCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language.ToString())
                    };

                    this.gwMapCache = ApiCall.GetContent<List<GwMap>>("map_names.json", arguments, ApiCall.Categories.World);
                }

                return this.gwMapCache;
            }
        }

        /// <summary>
        /// Gets or sets a map by index.
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>A map</returns>
        public GwMap this[int index]
        {
            get
            {
                return this.Maps[index];
            }

            set
            {
                this.Maps[index] = value;
            }
        }

        public GwMap this[string name]
        {
            get
            {
                return (from n in this.Maps where n.Name == name select n).Single();
            }
        }

        /// <summary>
        /// Gets the index of  map.
        /// </summary>
        /// <param name="item">The map</param>
        /// <returns>The index of the map</returns>
        public int IndexOf(GwMap item)
        {
            return this.Maps.IndexOf(item);
        }

        /// <summary>
        /// Insert a map into the list.
        /// </summary>
        /// <param name="index">The specified index</param>
        /// <param name="item">The map to insert</param>
        public void Insert(int index, GwMap item)
        {
            this.Maps.Insert(index, item);
        }

        /// <summary>
        /// Removes a map at the specified index.
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            this.Maps.RemoveAt(index);
        }

        /// <summary>
        /// Adds a map to the collection
        /// </summary>
        /// <param name="item">The map to add</param>
        public void Add(GwMap item)
        {
            this.Maps.Add(item);
        }

        /// <summary>
        /// Clears the collection of maps
        /// </summary>
        public void Clear()
        {
            this.Maps.Clear();
        }

        /// <summary>
        /// Determines if the collection contains a particular map
        /// </summary>
        /// <param name="item">The map to look for</param>
        /// <returns>True if the collection contains the map</returns>
        public bool Contains(GwMap item)
        {
            return this.Maps.Contains(item);
        }

        /// <summary>
        /// Copies the collection to an array
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The index to start the copy</param>
        public void CopyTo(GwMap[] array, int arrayIndex)
        {
            this.Maps.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes a map from the collection
        /// </summary>
        /// <param name="item">The map to remove</param>
        /// <returns>A value indicating whether the item was removed</returns>
        public bool Remove(GwMap item)
        {
            return this.Maps.Remove(item);
        }

        /// <summary>
        /// Gets an enumerator for the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<GwMap> GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }
    }
}
