using System.Text.Json.Serialization;

namespace OLDumpHelper.Models
{
    public class Author
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("type")]
        public Type Type { get; set; } = default!;

        [JsonPropertyName("alternate_names")]
        public string[]? AlternateNames { get; set; }

        // Some bios have wrong format
        //public AuthorType? Bio { get; set; }

        [JsonPropertyName("birth_date")]
        public string? BirthDate { get; set; }

        [JsonPropertyName("death_date")]
        public string? DeathDate { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; } = default!;

        [JsonPropertyName("fuller_name")]
        public string? FullerName { get; set; }

        [JsonPropertyName("personal_name")]
        public string? PersonalName { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("photos")]
        public int[]? Photos { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("latest_revision")]
        public int LatestRevision { get; set; }

        [JsonPropertyName("created")]
        public AuthorLastModified Created { get; set; } = default!;

        [JsonPropertyName("last_modified")]
        public AuthorLastModified LastModified { get; set; } = default!;

        [JsonPropertyName("source_records")]
        public string[]? SourceRecords { get; set; }
    }

    public class AuthorType
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("value")]
        public string Value { get; set; } = default!;
    }

    public class AuthorLastModified
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("value")]
        public DateTime Value { get; set; } = default!;
    }

    public class Type
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;
    }

}

