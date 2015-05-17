﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWorld.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDataContract" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Worlds;

    /// <summary>Converts objects of type <see cref="WorldDataContract"/> to objects of type <see cref="World"/>.</summary>
    internal sealed class ConverterForWorld : IConverter<WorldDataContract, World>
    {
        /// <inheritdoc />
        public World Convert(WorldDataContract value)
        {
            Contract.Assume(value != null);
            return new World
            {
                WorldId = value.Id, 
                Name = value.Name
            };
        }
    }
}