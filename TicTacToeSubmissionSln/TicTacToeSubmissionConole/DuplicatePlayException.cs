using System;
using System.Runtime.Serialization;

namespace TicTacToeSubmissionConole
{
    [Serializable]
    internal class DuplicatePlayException : Exception
    {
        public DuplicatePlayException()
        {
        }

        public DuplicatePlayException(string message) : base(message)
        {
        }

        public DuplicatePlayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatePlayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}