// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;
    using System.Globalization;
    using System.Linq;

    using GW2DotNET.Utilities;

    /// <summary>Provides the base class for service requests.</summary>
    public abstract class ServiceRequest : IServiceRequest
    {
        /// <summary>Infrastructure. Stores the supported languages.</summary>
        private static readonly string[] SupportedLanguages = { "de", "en", "es", "fr" };

        /// <summary>Infrastructure. Holds a reference to the language info.</summary>
        private CultureInfo language;

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint as a relative path.</param>
        protected ServiceRequest(string resource)
            : this(new Uri(resource, UriKind.Relative))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceRequest"/> class.</summary>
        /// <param name="resource">The service endpoint as a relative path.</param>
        protected ServiceRequest(Uri resource)
        {
            Preconditions.EnsureNotNull(paramName: "resource", value: resource);
            Preconditions.Ensure(!resource.IsAbsoluteUri, paramName: "resource", message: "'resource' should be a relative path.");

            this.ResourceUri = resource;
            this.FormData = new UrlEncodedForm();
        }

        /// <summary>Gets the form data.</summary>
        public UrlEncodedForm FormData { get; private set; }

        /// <summary>Gets or sets the preferred language info.</summary>
        public CultureInfo Language
        {
            get
            {
                return this.language;
            }

            set
            {
                Preconditions.EnsureNotNull(paramName: "value", value: value);

                if (!SupportedLanguages.Contains(value.TwoLetterISOLanguageName))
                {
                    throw new NotSupportedException("The specified language is not supported.");
                }

                this.FormData["lang"] = (this.language = value).TwoLetterISOLanguageName;
            }
        }

        /// <summary>Gets the resource URI.</summary>
        public Uri ResourceUri { get; private set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.ResourceUri.ToString();
        }
    }
}