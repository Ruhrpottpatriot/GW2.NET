// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceException.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an API error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core
{
    using System;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core.ErrorInformation;

    /// <summary>
    ///     Represents an API error.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1" /> for more information regarding API errors.
    /// </remarks>
    public class ServiceException : Exception
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ServiceException"/> class.</summary>
        /// <param name="details">The error details.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ServiceException(ErrorResult details, Exception innerException = null)
            : base(Preconditions.EnsureNotNull(paramName: "details", value: details).Text, innerException)
        {
            this.Details = details;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the error details.
        /// </summary>
        public ErrorResult Details { get; private set; }

        #endregion
    }
}