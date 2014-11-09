// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetItemsCommand.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the Get-Item command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.PS.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

    using GW2NET.Common;
    using GW2NET.Entities.Builds;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items;

    /// <summary>Represents the Get-Item command.</summary>
    [Cmdlet(VerbsCommon.Get, "Items")]
    public class GetItemsCommand : ServiceCmdlet
    {
        private IServiceClient serviceClient;

        /// <summary>Gets or sets the build identifier.</summary>
        [Parameter]
        public Build Build { get; set; }

        /// <summary>Gets or sets the culture.</summary>
        [Parameter(Position = 1)]
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        [Parameter(Position = 0)]
        public int[] Id { get; set; }

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        /// <param name="serviceClient">A service client.</param>
        protected override void BeginProcessing(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Provides a record-by-record processing functionality for the cmdlet.</summary>
        protected override void ProcessRecord()
        {
            var ids = this.Id;
            if (ids == null)
            {
                this.WriteItemsDiscovered();
            }
            else
            {
                this.WriteItemDetails(ids);
            }
        }

        /// <summary>Writes a collection of item details for the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        private void WriteItemDetails(IList<int> identifiers)
        {
            // Configure the language (default: English)
            var culture = this.Culture;

            // Configure the build number (default: 0)
            var buildId = this.Build != null ? this.Build.BuildId : 0;

            // Configure a progress object for the specified number of items
            var progressRecord = new ProgressRecord(0, "Retrieving item details.", string.Format("Item 1 of {0}", identifiers.Count))
                {
                    RecordType = ProgressRecordType.Processing
                };

            // Process each identifier
            for (var i = 0; i < identifiers.Count; i++)
            {
                // Get the current identifier
                var id = identifiers[i];

                // Update the progress bar
                progressRecord.CurrentOperation = string.Format("/v1/item_details.json?lang={1}&item_id={0}", id, culture.TwoLetterISOLanguageName);
                progressRecord.StatusDescription = string.Format("Item {0} of {1}", i + 1, identifiers.Count);
                progressRecord.PercentComplete = (int)(((double)i / (double)identifiers.Count) * 100D);
                this.WriteProgress(progressRecord);

                // Try to get item details for the current identifier
                try
                {
                    IRepository<int, Item> repo = new ItemRepository(this.serviceClient)
                    {
                        Culture = this.Culture
                    };

                    // Get the item details from the service
                    var item = repo.Find(id);

                    // Configure a build that uniquely identifies the item revision
                    item.BuildId = buildId;

                    // Write the object to the pipeline
                    this.WriteObject(item);
                }
                catch (ServiceException serviceException)
                {
                    // Write a non-fatal error that indicates a service error
                    this.WriteError(new ErrorRecord(serviceException, "ItemNotFound", ErrorCategory.ObjectNotFound, id));
                }
                catch (WebException webException)
                {
                    // Write a fatal error that indicates a connection error
                    this.ThrowTerminatingError(new ErrorRecord(webException, "ConnectionError", ErrorCategory.ConnectionError, id));
                }
            }

            // Update the progress bar
            progressRecord.RecordType = ProgressRecordType.Completed;
            this.WriteProgress(progressRecord);
        }

        /// <summary>Writes a collection of identifiers of discovered items.</summary>
        private void WriteItemsDiscovered()
        {
            // Try to get discovered item identifiers
            try
            {
                IRepository<int, Item> itemRepository = new ItemRepository(this.serviceClient);

                // Get the item identifiers from the service
                var items = itemRepository.Discover();

                // Write the collection to the pipeline
                this.WriteObject(items);
            }
            catch (ServiceException serviceException)
            {
                // Write a fatal error that indicates a service error
                this.ThrowTerminatingError(new ErrorRecord(serviceException, "ServiceError", ErrorCategory.ResourceUnavailable, null));
            }
            catch (WebException webException)
            {
                // Write a fatal error that indicates a connection error
                this.ThrowTerminatingError(new ErrorRecord(webException, "ConnectionError", ErrorCategory.ConnectionError, null));
            }
        }
    }
}