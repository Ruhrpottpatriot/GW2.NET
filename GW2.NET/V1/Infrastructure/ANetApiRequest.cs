// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ANetApiRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the JsonRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>The a net api request.</summary>
    public class ANetApiRequest
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>True when the instance is disposed.</summary>
        private bool disposed = false;

        /// <summary>The arguments dictionary.</summary>
        private Dictionary<string, object> arguments;

        /// <summary>The api category.</summary>
        private Categories apiCategory;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors
        //// --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="ANetApiRequest"/> class.</summary>
        public ANetApiRequest()
            : this(new Dictionary<string, object>())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ANetApiRequest"/> class.</summary>
        /// <param name="args">The arguments for the api request.</param>
        public ANetApiRequest(Dictionary<string, object> args)
        {
            this.arguments = args;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Enumerations
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Enumerates the possible categories a request can be.
        /// </summary>
        public enum Categories
        {
            /// <summary>
            /// The world part of the API.
            /// Includes world names, map names and events
            /// </summary>
            World,

            /// <summary>
            /// The world versus world part of the API.
            /// </summary>
            WvW,

            /// <summary>
            /// The items part of the API
            /// </summary>
            Items,

            /// <summary>
            /// The guild part of the api.
            /// </summary>
            Guild,

            /// <summary>
            /// The miscellaneous part of the api.
            /// </summary>
            Miscellaneous
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the category.</summary>
        public Categories Category
        {
            get
            {
                return this.apiCategory;
            }
        }

        /// <summary>Gets the arguments.</summary>
        public Dictionary<string, object> Arguments
        {
            get
            {
                return this.arguments;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Adds an argument to the arguments collection.</summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <returns>The <see cref="ANetApiRequest"/>.</returns>
        public ANetApiRequest AddParameter(string name, object value)
        {
            this.arguments.Add(name, value);

            return this;
        }

        /// <summary>Adds a number of arguments to the arguments collection.</summary>
        /// <param name="args">The arguments to add to the collection.</param>
        /// <returns>The <see cref="ANetApiRequest"/>.</returns>
        public ANetApiRequest AddParameters(Dictionary<string, object> args)
        {
            this.arguments = this.arguments.Concat(args).ToDictionary(pair => pair.Key, pair => pair.Value);

            return this;
        }

        /// <summary>Clears the parameter collection.</summary>
        /// <returns>The <see cref="ANetApiRequest"/>.</returns>
        public ANetApiRequest ClearParameters()
        {
            this.arguments = null;
            return this;
        }

        /// <summary>Gets the content from the server asynchronously and converts it into a POCO.</summary>
        /// <param name="apiMethod">The api method to query.</param>
        /// <param name="category">The category the method is in.</param>
        /// <typeparam name="T">The type to convert the json string into.</typeparam>
        /// <returns>A <see cref="Task{T}"/> containing the POCO.</returns>
        public async Task<T> GetContentAsync<T>(string apiMethod, Categories category)
        {
            var jsonResponse = await this.GetApiResponseAsync(apiMethod, category);

            return await JsonConvert.DeserializeObjectAsync<T>(jsonResponse);
        }

        /// <summary>Gets the content from the server.</summary>
        /// <param name="apiMethod">The api method to query.</param>
        /// <param name="category">The category the method is in.</param>
        /// <typeparam name="T">The type to convert the json string into.</typeparam>
        /// <returns>The <see cref="{T}"/>.</returns>
        /// <remarks>This method is a wrapper around the asynchronous method. It runs the method synchronously,
        /// instead of asynchronously.</remarks>
        public T GetContent<T>(string apiMethod, Categories category)
        {
            var returnObject = this.GetContentAsync<T>(apiMethod, category).Result;

            return returnObject;
        }

        /// <summary>Gets the json string from the arenaNet servers asynchronously.</summary>
        /// <param name="apiMethod">The method to query.</param>
        /// <param name="category">The category of the api.</param>
        /// <returns>The <see cref="Task"/> containing the response string.</returns>
        internal async Task<string> GetApiResponseAsync(string apiMethod, Categories category)
        {
            // Set the api category field.
            this.apiCategory = category;

            // Generate the request url.
            string requestUrl = this.GenerateApiUrl(apiMethod);

            // Generate the request.
            var request = this.GenerateRequest(requestUrl);

            // Get the response and cast it to HttpWebResponse.
            var response = (HttpWebResponse)await request.GetResponseAsync();

            // ToDo: Implement proper status code checking here.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var writer = new StreamReader(response.GetResponseStream()))
                {
                    return await writer.ReadToEndAsync();
                }
            }

            return string.Empty;
        }

        /// <summary>Generates the api url from the arguments and the query location.</summary>
        /// <param name="apiMethod">The method of the api to call.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GenerateApiUrl(string apiMethod)
        {
            var baseUrl = this.SwitchApiLocation();

            var list = this.arguments.Select(arg => string.Format("{0}={1}", arg.Key, arg.Value)).ToList();

            return list.Any() ? baseUrl + apiMethod + "?" + string.Join("&", list) : baseUrl + apiMethod;
        }

        /// <summary>Generates a basic web request.</summary>
        /// <param name="apiUrl">The api url.</param>
        /// <returns>The <see cref="WebRequest"/>.</returns>
        private WebRequest GenerateRequest(string apiUrl)
        {
            WebRequest request = WebRequest.Create(apiUrl);

            request.Method = "GET";
            return request;
        }

        /// <summary>Do a switch based on the place where the caller wants to go. 
        /// Simple solution to keep the call in one method and not two.</summary>
        /// <returns>A <see cref="string"/> containing the base api url.</returns>
        private string SwitchApiLocation()
        {
            string urlString = string.Empty;

            switch (this.apiCategory)
            {
                case Categories.WvW:
                    urlString = "https://api.guildwars2.com/v1/wvw/";
                    break;
                case Categories.Items:
                case Categories.World:
                case Categories.Guild:
                case Categories.Miscellaneous:
                    urlString = "https://api.guildwars2.com/v1/";
                    break;
            }

            return urlString;
        }
    }
}
