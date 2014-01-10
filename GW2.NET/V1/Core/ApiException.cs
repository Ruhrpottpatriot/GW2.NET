// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiException.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Represents errors resulting from incorrect input parameters.
    /// </summary>
    /// <remarks>
    /// See http://wiki.guildwars2.com/wiki/API:1.
    /// </remarks>
    public class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error details.
        /// </summary>
        /// <param name="error">A number that indicates the error kind.</param>
        /// <param name="product">A number that represents the product in which the error occurred.</param>
        /// <param name="module">A number that represents the module in which the error occurred.</param>
        /// <param name="line">The line number on which the error occurred.</param>
        /// <param name="text">The error message that explains the reason for the exception.</param>
        public ApiException(int error, int product, int module, int line, string text)
            : this(error, product, module, line, text, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error details and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="error">A number that indicates the error kind.</param>
        /// <param name="product">A number that represents the product in which the error occurred.</param>
        /// <param name="module">A number that represents the module in which the error occurred.</param>
        /// <param name="line">The line number on which the error occurred.</param>
        /// <param name="text">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ApiException(int error, int product, int module, int line, string text, Exception innerException)
            : base(text, innerException)
        {
            this.Error = error;
            this.Product = product;
            this.Module = module;
            this.Line = line;
        }

        /// <summary>
        /// Gets a number that indicates the error kind.
        /// </summary>
        public int Error { get; private set; }

        /// <summary>
        /// Gets a number that represents the product in which the error occurred.
        /// </summary>
        public int Product { get; private set; }

        /// <summary>
        /// Gets a number that represents the module in which the error occurred.
        /// </summary>
        public int Module { get; private set; }

        /// <summary>
        /// Gets the line number on which the error occurred.
        /// </summary>
        public int Line { get; private set; }
    }
}
