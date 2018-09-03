using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace TravelMoney.Models
{
    public partial class UserProfileGoogle
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("organizations")]
        public Organization[] Organizations { get; set; }

        [JsonProperty("placesLived")]
        public PlacesLived[] PlacesLived { get; set; }

        [JsonProperty("isPlusUser")]
        public bool IsPlusUser { get; set; }

        [JsonProperty("circledByCount")]
        public long CircledByCount { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }
    }

    public partial class Cover
    {
        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("coverPhoto")]
        public CoverPhoto CoverPhoto { get; set; }

        [JsonProperty("coverInfo")]
        public CoverInfo CoverInfo { get; set; }
    }

    public partial class CoverInfo
    {
        [JsonProperty("topImageOffset")]
        public long TopImageOffset { get; set; }

        [JsonProperty("leftImageOffset")]
        public long LeftImageOffset { get; set; }
    }

    public partial class CoverPhoto
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }
    }

    public partial class Organization
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("startDate")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long StartDate { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? EndDate { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }

    public partial class PlacesLived
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("primary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Primary { get; set; }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
