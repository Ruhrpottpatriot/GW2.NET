namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;

    public interface IResponse : ILocalizable
    {
        /// <summary>Gets or sets the <see cref="DateTimeOffset"/> at which the message originated.</summary>
        DateTimeOffset Date { get; set; }

        /// <summary>Gets or sets a collection of custom response headers.</summary>
        /// <exception cref="ArgumentNullException">The value is a null reference.</exception>
        IDictionary<string, string> ExtensionData { get; set; }
    }
}
