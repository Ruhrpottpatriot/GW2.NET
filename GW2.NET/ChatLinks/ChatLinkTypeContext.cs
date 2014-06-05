// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinkTypeContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The chat link type context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;
    using System.ComponentModel;

    /// <summary>The chat link type context.</summary>
    internal class ChatLinkTypeContext : ITypeDescriptorContext
    {
        /// <summary>Initializes a new instance of the <see cref="ChatLinkTypeContext"/> class.</summary>
        /// <param name="input">The input.</param>
        public ChatLinkTypeContext(string input)
        {
            this.Instance = input;
        }

        /// <summary>
        /// Gets the container representing this <see cref="T:System.ComponentModel.TypeDescriptor"/> request.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.ComponentModel.IContainer"/> with the set of objects for this <see cref="T:System.ComponentModel.TypeDescriptor"/>; otherwise, null if there is no container or if the <see cref="T:System.ComponentModel.TypeDescriptor"/> does not use outside objects.
        /// </returns>
        public IContainer Container { get; private set; }

        /// <summary>
        /// Gets the object that is connected with this type descriptor request.
        /// </summary>
        /// <returns>
        /// The object that invokes the method on the <see cref="T:System.ComponentModel.TypeDescriptor"/>; otherwise, null if there is no object responsible for the call.
        /// </returns>
        public object Instance { get; private set; }

        /// <summary>
        /// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"/> that is associated with the given context item.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.ComponentModel.PropertyDescriptor"/> that describes the given context item; otherwise, null if there is no <see cref="T:System.ComponentModel.PropertyDescriptor"/> responsible for the call.
        /// </returns>
        public PropertyDescriptor PropertyDescriptor { get; private set; }

        /// <summary>Gets the service object of the specified type.</summary>
        /// <returns>A service object of type <paramref name="serviceType"/>.-or- null if there is no service object of type <paramref name="serviceType"/>.</returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param>
        public object GetService(Type serviceType)
        {
            return null;
        }

        /// <summary>
        /// Raises the <see cref="E:System.ComponentModel.Design.IComponentChangeService.ComponentChanged"/> event.
        /// </summary>
        public void OnComponentChanged()
        {
        }

        /// <summary>
        /// Raises the <see cref="E:System.ComponentModel.Design.IComponentChangeService.ComponentChanging"/> event.
        /// </summary>
        /// <returns>
        /// true if this object can be changed; otherwise, false.
        /// </returns>
        public bool OnComponentChanging()
        {
            return false;
        }
    }
}