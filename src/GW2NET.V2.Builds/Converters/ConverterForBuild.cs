// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="BuildDataContract" /> to objects of type <see cref="Build" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Builds.Converters
{
    using System;

    using GW2NET.Builds;
    using GW2NET.Common;
    using GW2NET.V2.Builds.Json;

    /// <summary>Converts objects of type <see cref="BuildDataContract"/> to objects of type <see cref="Build"/>.</summary>
    internal sealed class ConverterForBuild : IConverter<BuildDataContract, Build>
    {
        /// <inheritdoc />
        public Build Convert(BuildDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Build
            {
                BuildId = value.BuildId
            };
        }
    }
}