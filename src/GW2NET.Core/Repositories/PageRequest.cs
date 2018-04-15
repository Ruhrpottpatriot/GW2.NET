// <copyright file="PageRequest.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System.Linq;

    /// <summary>Represents a paginated request against the API.</summary>
    public class PageRequest : Request
    {
        /// <summary>Initializes a new instance of the <see cref="PageRequest"/> class.</summary>
        public PageRequest()
        {
            this.PageSize = 50;
        }

        /// <summary>Gets or sets the start page.</summary>
        public int StartPage
        {
            get => int.Parse(this.Parameters.SingleOrDefault(p => p.Key.Equals("page")).Value);

            set
            {
                for (int i = 0; i < this.Parameters.Count; i++)
                {
                    if (this.Parameters[i].Key.Equals("page"))
                    {
                        this.Parameters[i] = new RequestParameter("page", value.ToString(), ParameterLocation.Header);
                    }
                }
            }
        }

        /// <summary>Gets or sets the end page.</summary>
        public int EndPage
        {
            get => int.Parse(this.Parameters.SingleOrDefault(p => p.Key.Equals("end_page")).Value);
            set
            {
                for (int i = 0; i < this.Parameters.Count; i++)
                {
                    if (this.Parameters[i].Key.Equals("end_page"))
                    {
                        this.Parameters[i] = new RequestParameter("end_page", value.ToString(), ParameterLocation.Header);
                    }
                }
            }
        }

        /// <summary>Gets or sets the page size. Defaults to 50.</summary>
        public int PageSize
        {
            get => int.Parse(this.Parameters.SingleOrDefault(p => p.Key.Equals("page_size")).Value);
            set
            {
                for (int i = 0; i < this.Parameters.Count; i++)
                {
                    if (this.Parameters[i].Key.Equals("page_size"))
                    {
                        this.Parameters[i] = new RequestParameter("page_size", value.ToString(), ParameterLocation.Header);
                    }
                }
            }
        }
    }
}