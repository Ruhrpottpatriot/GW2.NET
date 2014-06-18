// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceException.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an API error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.Utilities;
    using GW2DotNET.V2.Common.Contracts;

    /// <summary>Represents an API error.</summary>
    [Serializable]
    public sealed class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        public ServiceException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceException"/> class.</summary>
        /// <param name="details">The error details.</param>
        public ServiceException(ErrorResult details)
        {
            this.Details = details;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceException"/> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error. </param>
        /// <param name="details">The error details.</param>
        public ServiceException(string message, ErrorResult details)
            : base(message)
        {
            this.Details = details;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="details">The error details.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public ServiceException(string message, ErrorResult details, Exception innerException)
            : base(message, innerException)
        {
            this.Details = details;
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceException"/> class with serialized data.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        private ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Details = info.GetValue("Details", typeof(ErrorResult)) as ErrorResult;
        }

        /// <summary>Gets the error details.</summary>
        public ErrorResult Details { get; private set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <returns>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </returns>
        public override string Message
        {
            get
            {
                return (this.Details == null) ? base.Message : this.Details.Text;
            }
        }

        /// <summary>When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic). </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Preconditions.EnsureNotNull(paramName: "info", value: info);
            info.AddValue("Details", this.Details);
            base.GetObjectData(info, context);
        }
    }
}