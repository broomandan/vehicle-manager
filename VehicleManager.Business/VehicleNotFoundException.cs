using System;
using System.Runtime.Serialization;

namespace VehicleManager.Business
{
    [Serializable]
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException()
        {
        }

        public VehicleNotFoundException(string message) : base(message)
        {
        }

        public VehicleNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected VehicleNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}