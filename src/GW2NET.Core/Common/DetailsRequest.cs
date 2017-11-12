﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the base class for resource details requests.</summary>
    public abstract class DetailsRequest : IDetailsRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        public virtual string Identifier { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public virtual IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield break;
        }

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        public virtual IEnumerable<string> GetPathSegments()
        {
            yield return this.Identifier;
        }
    }
}