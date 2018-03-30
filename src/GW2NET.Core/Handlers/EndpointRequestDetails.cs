// <copyright file="EndpointRequestDetails.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Collections.Generic;
    using System.Globalization;

    internal class EndpointRequestDetails
    {
        public EndpointRequestDetails()
        {
            this.RequestParameters = new List<(string key, string value, bool isBody)>();
            this.ItemIds = new List<string>();
        }

        public string Endpoint { get; set; }

        public string Version { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public CultureInfo Culture { get; set; }

        public IList<(string key, string value, bool isBody)> RequestParameters { get; set; }

        public string ApiKey { get; set; }

        public IList<string> ItemIds { get; set; }
        public string Signature { get; set; }
        public int FileId { get; set; }
        public string Format { get; set; }
    }
}