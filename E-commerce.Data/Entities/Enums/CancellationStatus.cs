using System.Text.Json.Serialization;

namespace E_commerce.Entities.Enums
{
  

        // Enum to represent the status of a cancellation request
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum CancellationStatus
        {
            Pending = 1,
            Approved = 8,
            Rejected = 9
        }
    }

