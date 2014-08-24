// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetBuildCommand.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the Get-Build command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.PS.Commands
{
    using System.Management.Automation;
    using System.Net;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Builds;

    /// <summary>Represents the Get-Build command.</summary>
    [Cmdlet(VerbsCommon.Get, "Build")]
    public class GetBuildCommand : ServiceCmdlet
    {
        /// <summary>The build service.</summary>
        private IBuildService buildService;

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        /// <param name="serviceClient">A service client.</param>
        protected override void BeginProcessing(IServiceClient serviceClient)
        {
            this.buildService = new BuildService(serviceClient);
        }

        /// <summary>Provides a record-by-record processing functionality for the cmdlet.</summary>
        protected override void ProcessRecord()
        {
            try
            {
                this.WriteObject(this.buildService.GetBuild());
            }
            catch (ServiceException serviceException)
            {
                this.ThrowTerminatingError(new ErrorRecord(serviceException, "ServiceError", ErrorCategory.ResourceUnavailable, null));
            }
            catch (WebException webException)
            {
                this.ThrowTerminatingError(new ErrorRecord(webException, "ConnectionError", ErrorCategory.ConnectionError, null));
            }
        }
    }
}