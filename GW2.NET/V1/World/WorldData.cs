// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get and modify the world data.
    /// </summary>
    public class WorldData : IList<GwWorld>
    {
        private List<GwWorld> gwWorldCache = null;

        private Language language;

        internal WorldData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets all <see cref="GwWorld"/> from the api.
        /// </summary>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>A <see cref="IList"/> containing all world objects.
        /// ReSharper restore CSharpWarnings::CS1584
        /// </returns>
        private IList<GwWorld> Worlds
        {
            get
            {
                if (this.gwWorldCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language.ToString())
                    };

                    this.gwWorldCache = ApiCall.GetContent<List<GwWorld>>("world_names.json", arguments, ApiCall.Categories.World);
                }

                return this.gwWorldCache;
            }
        }

        public int IndexOf(GwWorld item)
        {
            return this.Worlds.IndexOf(item);
        }

        public void Insert(int index, GwWorld item)
        {
            this.Worlds.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.Worlds.RemoveAt(index);
        }

        public GwWorld this[int index]
        {
            get
            {
                return this.Worlds[index];
            }
            set
            {
                this.Worlds[index] = value;
            }
        }

        public void Add(GwWorld item)
        {
            this.Worlds.Add(item);
        }

        public void Clear()
        {
            this.Worlds.Clear();
        }

        public bool Contains(GwWorld item)
        {
            return this.Worlds.Contains(item);
        }

        public void CopyTo(GwWorld[] array, int arrayIndex)
        {
            this.Worlds.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.Worlds.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.Worlds.IsReadOnly; }
        }

        public bool Remove(GwWorld item)
        {
            return this.Worlds.Remove(item);
        }

        public IEnumerator<GwWorld> GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }
    }
}
