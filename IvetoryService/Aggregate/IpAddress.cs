using System.Net;

namespace InventoryService.Aggregate
{
    public class IpAddress
    {
        public string Value { get; private set; }

        private IpAddress(string value)
        {   
            Value = value;
        }

        public static IpAddress Create(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("IP address cannot be null or empty.", nameof(value));

            if (!IPAddress.TryParse(value, out _))
            {
                throw new ArgumentException($"Invalid IP address format: {value}", nameof(value));
            }
            return new IpAddress(value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

