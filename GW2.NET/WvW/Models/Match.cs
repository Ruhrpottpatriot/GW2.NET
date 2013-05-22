// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Match.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World-vs-World-vs-World match.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.Events.Models;

namespace GW2DotNET.WvW.Models
{
    /// <summary>
    /// Represents a World-vs-World-vs-World match.
    /// </summary>
    public struct Match
    {
        /// <summary>
        /// The id of the match. THis field is readonly.
        /// </summary>
        private readonly string id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Match"/> struct.
        /// </summary>
        /// <param name="id">The id of the match.</param>
        /// <param name="redWorld">The red world.</param>
        /// <param name="blueWorld">The blue world.</param>
        /// <param name="greenWorld"> The green world.</param>
        public Match(string id, World redWorld, World blueWorld, World greenWorld)
            : this()
        {
            this.id = id;
            this.RedWorld = redWorld;
            this.BlueWorld = blueWorld;
            this.GreenWorld = greenWorld;
        }

        /// <summary>
        /// Gets the id of the match.
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the red world.
        /// </summary>
        public World RedWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the blue world.
        /// </summary>
        public World BlueWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the green world.
        /// </summary>
        public World GreenWorld
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Match"/> are equal.
        /// </summary>
        /// <param name="matchA">The first object to compare.</param>param>
        /// <param name="matchB">The second object to compare. </param>
        /// <returns>true if mapA and mapB represent the same map; otherwise, false.</returns>
        public static bool operator ==(Match matchA, Match matchB)
        {
            return matchA.id == matchB.id;
        }

        /// <summary>
        /// Determines whether two specified instances of <see crdef="Match"/> are not equal.
        /// </summary>
        /// <param name="matchA">The first object to compare.</param>param>
        /// <param name="matchB">The second object to compare. </param>
        /// <returns>true if mapA and mapB do not represent the same map; otherwise, false.</returns>
        public static bool operator !=(Match matchA, Match matchB)
        {
            return matchA.id != matchB.id;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            return obj is Match && this == (Match)obj;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="Match"/> are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to.</param>
        public bool Equals(Match obj)
        {
            return this.id == obj.id;
        }
    }
}
