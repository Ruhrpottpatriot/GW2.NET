// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskFactoryExtensions.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides extension methods for the <see cref="System.Threading.Tasks.TaskFactory" /> type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Extensions
{
    using System.Threading.Tasks;

    /// <summary>Provides extension methods for the <see cref="System.Threading.Tasks.TaskFactory" /> type.</summary>
    public static class TaskFactoryExtensions
    {
        /// <summary>Creates a <see cref="System.Threading.Tasks.Task{TResult}"/> that's completed successfully with the specified result.</summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="result">The result to store into the completed task.</param>
        /// <returns>The successfully completed task.</returns>
        public static Task<TResult> FromResult<TResult>(this TaskFactory instance, TResult result)
        {
            var tcs = new TaskCompletionSource<TResult>(instance.CreationOptions);
            tcs.SetResult(result);
            return tcs.Task;
        }
    }
}