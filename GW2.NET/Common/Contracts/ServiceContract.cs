// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for service contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>Provides the base class for service contracts.</summary>
    [DataContract]
    public abstract class ServiceContract
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceContract" /> class.</summary>
        protected ServiceContract()
        {
            this.ExtensionData = new Dictionary<string, object>();
        }

        /// <summary>Gets or sets a dictionary of additional JSON properties that have no corresponding .NET property.</summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtensionData { get; set; }
    }
}