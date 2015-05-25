// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWorld.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDataContract" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System;

    using GW2NET.Common;
    using GW2NET.Worlds;

    /// <summary>Converts objects of type <see cref="WorldDataContract"/> to objects of type <see cref="World"/>.</summary>
    internal sealed class ConverterForWorld : IConverter<WorldDataContract, World>
    {
        /// <inheritdoc />
        public World Convert(WorldDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state != null");
            }

            var response = state as IResponse<WorldDataContract>;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse<WorldDataContract>", "state");
            }
  
            return new World
            {
                WorldId = value.Id, 
                Name = value.Name,
                Culture = response.Culture
            };
        }
    }
}