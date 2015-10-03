// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the character data served by the Guild Wars 2 api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts.Characters.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents the character data served by the Guild Wars 2 api.</summary>
    [DataContract]
    public sealed class CharacterDTO
    {
        /// <summary>Gets or sets the level.</summary>
        public int Level { get; set; }

        /// <summary>Gets or sets the guild.</summary>
        public string Guild { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        public string Gender { get; set; }

        /// <summary>Gets or sets the profession.</summary>
        public string Profession { get; set; }

        /// <summary>Gets or sets the race.</summary>
        public string Race { get; set; }
    }
}
