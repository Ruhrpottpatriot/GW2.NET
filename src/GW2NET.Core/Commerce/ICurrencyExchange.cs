// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrencyExchange.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for services that trade gems for coins.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Commerce
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for services that trade gems for coins.</summary>
    public interface ICurrencyExchange
    {
        Exchange GetCoins(int gems);

        Task<Exchange> GetCoinsAsync(int gems);

        Task<Exchange> GetCoinsAsync(int gems, CancellationToken cancellationToken);

        Exchange GetGems(int coins);

        Task<Exchange> GetGemsAsync(int coins);

        Task<Exchange> GetGemsAsync(int coins, CancellationToken cancellationToken);
    }
}