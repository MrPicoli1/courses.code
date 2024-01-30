using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core
{
    public class Utm
    {/// <summary>
     /// Create a UTM
     /// </summary>
     /// <param name="url"> URL (Website Link)</param>
     /// <param name="campaign">Campaing Information</param>
        public Utm(Url url, Campaign campaign)
        {
            Url = url;
            Campaign = campaign;

        }
        /// <summary>
        /// URL (Website Link)
        /// </summary>
        public Url Url { get; private set; }
        /// <summary>
        /// Campaing Datails
        /// </summary>
        public Campaign Campaign { get; private set; }
    }
}
