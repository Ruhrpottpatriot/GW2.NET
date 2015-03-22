// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="TaskDataContract" /> to objects of type <see cref="RenownTask" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="TaskDataContract"/> to objects of type <see cref="RenownTask"/>.</summary>
    internal sealed class TaskConverter : IConverter<TaskDataContract, RenownTask>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="TaskConverter"/> class.</summary>
        internal TaskConverter()
            : this(new Vector2DConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TaskConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="TaskConverter"/>.</param>
        internal TaskConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            Contract.Requires(vector2DConverter != null);
            this.vector2DConverter = vector2DConverter;
        }

        /// <summary>Converts the given object of type <see cref="TaskDataContract"/> to an object of type <see cref="RenownTask"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RenownTask Convert(TaskDataContract value)
        {
            Contract.Assume(value != null);
            var renownTask = new RenownTask
                                 {
                                     // ReSharper disable once PossibleNullReferenceException
                                     TaskId = value.TaskId,
                                     Objective = value.Objective,
                                     Level = value.Level,
                                 };

            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                renownTask.Coordinates = this.vector2DConverter.Convert(coordinates);
            }

            return renownTask;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.vector2DConverter != null);
        }
    }
}