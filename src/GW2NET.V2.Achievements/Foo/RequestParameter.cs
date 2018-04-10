// <copyright file="RequestParameter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Achievements.Foo
{
    /// <summary>Enumerates the request parameter location.</summary>
    public enum ParameterLocation
    {
        Url,
        Header
    }

    /// <summary>Describes a request parameter.</summary>
    public class RequestParameter
    {
        /// <summary>Initializes a new instance of the <see cref="RequestParameter"/> class.</summary>
        public RequestParameter(string key, string value, ParameterLocation location)
        {
            this.Key = key;
            this.Value = value;
            this.Location = location;
        }

        /// <summary>Gets the parameter key, i.e. the url parameter or header name.</summary>
        public string Key { get; }

        /// <summary>Gets the value assiciated with the <see cref="Key"/>.</summary>
        public string Value { get; }

        /// <summary>Gets the parameters location.</summary>
        public ParameterLocation Location { get; }
    }
}