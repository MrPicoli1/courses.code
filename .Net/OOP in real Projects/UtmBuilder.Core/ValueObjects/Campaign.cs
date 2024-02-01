using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campaign : ValueObject
    {
        /// <summary>
        /// Generate a new campaign for a URL
        /// </summary>
        /// <param name="source">The referrer (e.g. google, newsletter)</param>
        /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
        /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.</param>
        /// <param name="id">The ads campaign id.</param>
        /// <param name="term">Identify the paid keywords</param>
        /// <param name="content">Use to differentiate ads</param>
        public Campaign(string name, string source, string medium, string? id = null, string? term = null, string? content = null)
        {
            Name = name;
            Source = source;
            Medium = medium;
            Id = id;
            Term = term;
            Content = content;
            InvalidCampaignExeption.ThrowIfNull(Name, "Name is null");
            InvalidCampaignExeption.ThrowIfNull(Source, "Source is null");
            InvalidCampaignExeption.ThrowIfNull(Medium, "Medium is null");

        }
        /// <summary>
        /// Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The referrer (e.g. google, newsletter)
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Marketing medium (e.g. cpc, banner, email)
        /// </summary>
        public string Medium { get; set; }
        /// <summary>
        /// The ads campaign id.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// Identify the paid keywords
        /// </summary>
        public string? Term { get; set; }
        /// <summary>
        /// Use to differentiate ads
        /// </summary>
        public string ?Content { get; set; }


    }
}
