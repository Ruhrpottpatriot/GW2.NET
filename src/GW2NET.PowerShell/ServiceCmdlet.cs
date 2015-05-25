// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCmdlet.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for cmdlets that depend on a remote service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.PS.Commands
{
    using System;
    using System.Management.Automation;
    using System.Threading;

    using GW2NET.Common;
    using GW2NET.Common.Serializers;
    using GW2NET.Compression;

    /// <summary>Provides the base class for cmdlets that depend on a remote service.</summary>
    public abstract class ServiceCmdlet : PSCmdlet
    {
        /// <summary>The cancellation token source.</summary>
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        /// <summary>Gets the <see cref="CancellationToken"/> that provides cancellation support.</summary>
        public CancellationToken CancellationToken
        {
            get
            {
                return this.cancellationTokenSource.Token;
            }
        }

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        protected override sealed void BeginProcessing()
        {
            var baseUrl = new Uri("https://api.guildwars2.com", UriKind.Absolute);
            var serializerFactory = new DataContractJsonSerializerFactory();
            var gzipInflator = new GzipInflator();
            var serviceClient = new ServiceClient(baseUrl, serializerFactory, serializerFactory, gzipInflator);
            this.BeginProcessing(serviceClient);
            base.BeginProcessing();
        }

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        /// <param name="serviceClient">A service client.</param>
        protected virtual void BeginProcessing(IServiceClient serviceClient)
        {
        }

        /// <summary>Provides a record-by-record processing functionality for the cmdlet.</summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        /// <summary>Stops processing records when the user stops the cmdlet asynchronously.</summary>
        protected override sealed void StopProcessing()
        {
            this.cancellationTokenSource.Cancel();
            base.StopProcessing();
        }
    }
}