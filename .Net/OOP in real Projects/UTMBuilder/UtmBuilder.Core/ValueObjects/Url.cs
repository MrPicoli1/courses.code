using System.Net.Http.Headers;
using System.Text;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {


        /// <summary>
        /// Create a New URL
        /// </summary>
        /// <param name="address">Addres of a URL (Website Link)</param>

        public Url(string address)
        {
            Address = address;

            InvalidUrlException.ThrowIfInvalid(Address);

        }


        /// <summary>
        /// Addres of a URL (Website Link)
        /// </summary>
        public string Address { get;  }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Address);
            sb.Append("utm_source=");

            return sb.ToString();
        }

    }
}
