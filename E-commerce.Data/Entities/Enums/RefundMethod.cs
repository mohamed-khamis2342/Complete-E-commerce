
 using System.Text.Json.Serialization;

namespace E_commerce.Entities.Enums
{
   
   
        // Enum representing available refund methods.
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RefundMethod
        {
            Original,   // Refund back to the original payment method
            PayPal,
            Stripe,
            BankTransfer,
            Manual
        }
    
}
