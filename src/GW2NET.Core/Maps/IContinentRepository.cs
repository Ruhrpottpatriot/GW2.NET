// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContinentRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide localized continent details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Maps
{
    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide localized continent details.</summary>
    public interface IContinentRepository : IRepository<int, Continent>, ILocalizable
    {
    }
}
