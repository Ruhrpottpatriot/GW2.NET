// <copyright file="Request.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Contains default implementation for the <see cref="IRequest"/> interface.</summary>
    public abstract class Request : IRequest
    {
        /// <summary>Initializes a new instance of the <see cref="Request"/> class.</summary>
        protected Request()
        {
            this.Parameters = new List<RequestParameter>();
        }

        /// <summary>Gets or sets the request parameters.</summary>
        public List<RequestParameter> Parameters { get; set; }

        /// <inheritdoc />
        public CultureInfo Culture { get; }
    }
}
