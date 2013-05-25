// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get or modify the map data.
    /// </summary>
    public class MapData : IList<GwMap>
    {
        private List<GwMap> gwMapCache = null;

        private Language language;

        internal MapData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets the maps from the api.
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

        public int IndexOf(GwMap item)
        {
            return this.Maps.IndexOf(item);
        }

        public void Insert(int index, GwMap item)
        {
            this.Maps.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.Maps.RemoveAt(index);
        }

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

        public void Add(GwMap item)
        {
            this.Maps.Add(item);
        }

        public void Clear()
        {
            this.Maps.Clear();
        }

        public bool Contains(GwMap item)
        {
            return this.Maps.Contains(item);
        }

        public void CopyTo(GwMap[] array, int arrayIndex)
        {
            this.Maps.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.Maps.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.Maps.IsReadOnly; }
        }

        public bool Remove(GwMap item)
        {
            return this.Maps.Remove(item);
        }

        public IEnumerator<GwMap> GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }
    }
}
