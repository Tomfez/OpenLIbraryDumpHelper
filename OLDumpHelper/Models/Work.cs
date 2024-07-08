using System.Text.Json.Serialization;

namespace OLDumpHelper.Models
{
    internal class Work
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; } = default!;

        [JsonPropertyName("type")]
        public Type Type { get; set; } = default!;

        [JsonPropertyName("subjects")]
        public string[]? Subjects { get; set; }

        [JsonPropertyName("authors")]
        public Author[] Authors { get; set; } = [];

        [JsonPropertyName("covers")]
        public Cover[] Covers { get; set; } = [];

        [JsonPropertyName("first_publish_date")]
        public string? FirstPublishDate { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("latest_revision")]
        public int LatestRevision { get; set; }

        [JsonPropertyName("created")]
        public AuthorLastModified Created { get; set; } = default!;

        [JsonPropertyName("last_modified")]
        public AuthorLastModified LastModified { get; set; } = default!;
    }

    public class Cover
    {
        [JsonPropertyName("items")]
        public int[] Items { get; set; } = [];
    }
}
