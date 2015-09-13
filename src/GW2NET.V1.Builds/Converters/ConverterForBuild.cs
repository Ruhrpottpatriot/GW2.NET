// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="BuildDataContract" /> to objects of type <see cref="Build" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Builds;
using GW2NET.Common;
using GW2NET.V1.Builds.Json;

namespace GW2NET.V1.Builds.Converters
{
    using System;

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

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse<BuildDataContract>");
            }

            var response = state as IResponse<BuildDataContract>;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse<BuildDataContract>", "state");
            }

            return new Build
            {
                BuildId = value.BuildId,
                Timestamp = response.Date
            };
        }
    }
}