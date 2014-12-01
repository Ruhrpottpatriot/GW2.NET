// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRenownTask.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RenownTaskDataContract" /> to objects of type <see cref="RenownTask" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    /// <summary>Converts objects of type <see cref="RenownTaskDataContract"/> to objects of type <see cref="RenownTask"/>.</summary>
    internal sealed class ConverterForRenownTask : IConverter<RenownTaskDataContract, RenownTask>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRenownTask"/> class.</summary>
        internal ConverterForRenownTask()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRenownTask"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        internal ConverterForRenownTask(IConverter<double[], Vector2D> converterForVector2D)
        {
            Contract.Requires(converterForVector2D != null);
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="RenownTaskDataContract"/> to an object of type <see cref="RenownTask"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RenownTask Convert(RenownTaskDataContract value)
        {
            Contract.Assume(value != null);
            var renownTask = new RenownTask
            {
                TaskId = value.TaskId, 
                Objective = value.Objective, 
                Level = value.Level, 
            };

            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                renownTask.Coordinates = this.converterForVector2D.Convert(coordinates);
            }

            return renownTask;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
        }
    }
}