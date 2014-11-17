// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBuild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="BuildDataContract" /> to objects of type <see cref="Build" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Builds
{
    using System.Diagnostics.Contracts;

    using GW2NET.Builds;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="BuildDataContract"/> to objects of type <see cref="Build"/>.</summary>
    internal sealed class ConverterForBuild : IConverter<BuildDataContract, Build>
    {
        /// <summary>Converts the given object of type <see cref="BuildDataContract"/> to an object of type <see cref="Build"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Build Convert(BuildDataContract value)
        {
            Contract.Assume(value != null);
            return new Build
            {
                BuildId = value.BuildId
            };
        }
    }
}