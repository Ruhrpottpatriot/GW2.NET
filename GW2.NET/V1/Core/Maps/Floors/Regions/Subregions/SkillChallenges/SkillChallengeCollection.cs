// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of skill challenge locations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.SkillChallenges
{
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common;

    /// <summary>Represents a collection of skill challenge locations.</summary>
    public class SkillChallengeCollection : JsonList<SkillChallenge>
    {
        /// <summary>Initializes a new instance of the <see cref="SkillChallengeCollection" /> class.</summary>
        public SkillChallengeCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkillChallengeCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public SkillChallengeCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkillChallengeCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public SkillChallengeCollection(IEnumerable<SkillChallenge> collection)
            : base(collection)
        {
        }
    }
}