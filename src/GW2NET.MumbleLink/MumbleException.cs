namespace GW2NET.MumbleLink
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>The exception that is thrown when an error occurs in the Mumble Link.</summary>
    [Serializable]
    public class MumbleException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="MumbleException" /> class.</summary>
        public MumbleException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MumbleException" /> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public MumbleException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MumbleException" /> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">
        ///     The exception that is the cause of the current exception, or a null reference (<c>Nothing</c> in
        ///     Visual Basic) if no inner exception is specified.
        /// </param>
        public MumbleException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MumbleException" /> class with serialized data.</summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <c>null</c>.</exception>
        /// <exception cref="SerializationException">The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).</exception>
        protected MumbleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}