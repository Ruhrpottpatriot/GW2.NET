// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlEncodedForm.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of form data that can be URL-encoded.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>Represents a collection of form data that can be URL-encoded.</summary>
    public sealed class UrlEncodedForm : Dictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlEncodedForm"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        public UrlEncodedForm()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UrlEncodedForm"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="UrlEncodedForm"/> can contain.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public UrlEncodedForm(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UrlEncodedForm"/> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer{String}"/>.</summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{String}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{String}"/> for the type of the key.</param>
        public UrlEncodedForm(IEqualityComparer<string> comparer)
            : base(comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UrlEncodedForm"/> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer{String}"/>.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="UrlEncodedForm"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{String}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{String}"/> for the type of the key.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public UrlEncodedForm(int capacity, IEqualityComparer<string> comparer)
            : base(capacity, comparer)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UrlEncodedForm"/> class that contains elements copied from the specified <see cref="IDictionary{String, String}"/> and uses the default equality comparer for the key type.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{String, String}"/> whose elements are copied to the new <see cref="UrlEncodedForm"/>.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public UrlEncodedForm(IDictionary<string, string> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="UrlEncodedForm"/> class that contains elements copied from the specified <see cref="IDictionary{String, String}"/> and uses the specified <see cref="IEqualityComparer{String}"/>.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{String, String}"/> whose elements are copied to the new <see cref="UrlEncodedForm"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{String}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{String}"/> for the type of the key.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public UrlEncodedForm(IDictionary<string, string> dictionary, IEqualityComparer<string> comparer)
            : base(dictionary, comparer)
        {
        }

        /// <summary>Gets the query string.</summary>
        /// <returns>The query <see cref="string" />.</returns>
        /// <exception cref="FormatException">One or more query parameters violate the format for a valid URI as defined by RFC 2396.</exception>
        public string GetQueryString()
        {
            return string.Join("&", this.Where(pair => !string.IsNullOrEmpty(pair.Value)).Select(EncodeNameValuePair));
        }

        /// <summary>Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.</summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.</returns>
        /// <exception cref="FormatException">One or more query parameters violate the format for a valid URI as defined by RFC 2396.</exception>
        public override string ToString()
        {
            return this.GetQueryString();
        }

        /// <summary>Encodes a key value pair for safe transportation over HTTP.</summary>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <returns>The encoded key value pair.</returns>
        /// <exception cref="FormatException">One or more query parameters violate the format for a valid URI as defined by RFC 2396.</exception>
        private static string EncodeNameValuePair(KeyValuePair<string, string> keyValuePair)
        {
            Debug.Assert(keyValuePair.Key != null, "keyValuePair.Key != null");
            Debug.Assert(keyValuePair.Value != null, "keyValuePair.Value != null");
            var name = Uri.EscapeUriString(keyValuePair.Key);
            var value = Uri.EscapeUriString(keyValuePair.Value);

            return string.Concat(name, "=", value);
        }
    }
}