using System;
using System.Runtime.Serialization;

namespace VehicleManager.Business
{
    [Serializable]
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException()
        {
        }

        public DuplicateEntryException(string message) : base(message)
        {
        }

        public DuplicateEntryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DuplicateEntryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}