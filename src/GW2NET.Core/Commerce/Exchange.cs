// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Exchange.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the gems from/to gold exchange rate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Commerce
{
    using System;

    using GW2NET.ChatLinks;
    using GW2NET.Common;

    /// <summary>Represents the gems from/to gold exchange rate.</summary>
    public class Exchange : ITimeSensitive
    {
        /// <summary>Gets or sets the coins per gem.</summary>
        public int CoinsPerGem { get; set; }

        /// <summary>Gets or sets the number of gems/coins to receive.</summary>
        public long Receive { get; set; }

        /// <summary>Gets or sets the number of gems/coins to send.</summary>
        public long Send { get; set; }

        /// <summary>Gets or sets the timestamp.</summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>Gets a chat link for the value of <see cref="CoinsPerGem"/>.</summary>
        /// <returns>Returns a chat link for the given coins per gem.</returns>
        public CoinChatLink GetCoinChatLink()
        {
            return new CoinChatLink
            {
                Quantity = this.CoinsPerGem
            };
        }
    }
}