// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICharacterRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide character data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Characters
{
    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide character data.</summary>
    public interface ICharacterRepository : IRepository<string, Character>, ILocalizable
    {
    }
}
