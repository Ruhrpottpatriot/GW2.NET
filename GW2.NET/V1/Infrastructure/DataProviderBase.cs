// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProviderBase.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Abstract bas class providing base methods for derived classes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>Abstract bas class providing base methods for derived classes.</summary>
    public abstract class DataProviderBase
    {
        /// <summary>Gets or sets a value indicating whether the user is bypassing the cache
        /// and querying the server directly.</summary>
        public bool BypassCache { get; set; }

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public abstract void WriteCacheToDisk();

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task WriteCacheToDiskAsync();

        /// <summary>Clears the cache.</summary>
        public abstract void ClearCache();

        /// <summary>
        /// Synchronously reads the contents of the stored cache from the hard drive.
        /// </summary>
        /// <typeparam name="T">The type to serialize the file contents into.</typeparam>
        /// <param name="path">The path of the cache file.</param>
        /// <returns>The contents of the file serialized into <see cref="T"/>.</returns>
        public T ReadCacheFromDisk<T>(string path, out int build) where T : class, new() 
        {
            if (File.Exists(path))
            {
                using (FileStream fileStream = File.OpenRead(path))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        JsonTextReader jsonTextReader = new JsonTextReader(streamReader);

                        JsonSerializer jsonSerializer = new JsonSerializer();

                        GameCache<T> cache = jsonSerializer.Deserialize<GameCache<T>>(jsonTextReader);

                        build = cache.Build;
                        return cache.CacheData;
                    }
                }
            }
            else
            {
                build = -1;
                return new T();
            }
        }


        /// <summary>
        /// Asynchronously reads the contents of the stored cache from the hard drive.
        /// </summary>
        /// <typeparam name="T">The type to serialize the file contents into.</typeparam>
        /// <param name="path">The path of the cache file.</param>
        /// <returns>The contents of the file serialized into <see cref="T"/>.</returns>
        public Task<T> ReadCacheFromDiskAsync<T>(string path, out int build)
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Saves the contents of the cache to the file system.</summary>
        /// <param name="cacheFileName">The complete file name of the file to save the data to.</param>
        /// <param name="dataToSave">The data to save.</param>
        protected void WriteDataToDisk(string cacheFileName, object dataToSave)
        {
            string directoryPath = Path.GetDirectoryName(cacheFileName);

            // Make sure the directory exists first
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else if (string.IsNullOrEmpty(directoryPath))
            {
                throw new NoNullAllowedException("The path to the directory must not be null or an empty string!");
            }

            File.WriteAllText(cacheFileName, JsonConvert.SerializeObject(dataToSave, Formatting.Indented));
        }
    }
}
