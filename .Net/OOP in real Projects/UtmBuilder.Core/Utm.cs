using System.Reflection.Metadata.Ecma335;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

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


        /// <summary>
        /// Utm to string conversion
        /// </summary>
        /// <param name="utm"></param>
        public static implicit operator string(Utm utm) => utm.ToString();


        /// <summary>
        /// String to UTM conversion
        /// </summary>
        /// <param name="link"></param>
        public static implicit operator Utm(string link)
        {
            if(string.IsNullOrEmpty(link))
                throw new InvalidUrlException();

            var url = new Url(link);

            var segments = url.Address.Split('?');
            if(segments.Length == 1 )
                throw new InvalidUrlException();

            var pars = segments[1].Split("&");
            var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            return new Utm(new Url(segments[0]), new Campaign(name,source,medium,id,term,content));
        }
      
        public override string ToString()
        {
            var segmets = new List<string>();
            segmets.AddIfNotNull("utm_source",Campaign.Source);
            segmets.AddIfNotNull("utm_medium", Campaign.Medium);
            segmets.AddIfNotNull("utm_campaign", Campaign.Name);
            segmets.AddIfNotNull("utm_id", Campaign.Id);
            segmets.AddIfNotNull("utm_term", Campaign.Term);
            segmets.AddIfNotNull("utm_content", Campaign.Content);
            return $"{Url.Address}?{string.Join("&",segmets)}" ;
        }
    }
}
