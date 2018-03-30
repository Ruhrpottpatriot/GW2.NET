// <copyright file="IResponse.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;

    public interface IResponse : ILocalizable
    {
        /// <summary>Gets or sets the <see cref="DateTimeOffset"/> at which the message originated.</summary>
        DateTimeOffset Date { get; set; }

        /// <summary>Gets or sets a collection of custom response headers.</summary>
        /// <exception cref="ArgumentNullException">The value is a null reference.</exception>
        IDictionary<string, string> ExtensionData { get; }
    }
}
