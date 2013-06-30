using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>
    /// Base class for all DataProvider classes.
    /// </summary>
    public class DataProviderBase : System.ComponentModel.Component
    {
        /// <summary>
        /// Tracks the state of any async tasks.
        /// </summary>
        protected readonly HybridDictionary userStateToLifetime = new HybridDictionary();

        /// <summary>
        /// Utility method for determining if a task has been canceled.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        protected bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }
    }
}
