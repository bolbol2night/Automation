using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Translator.interfaces;

namespace Translator.services;

internal class CustomSourceDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString()!, "s", CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("s", CultureInfo.InvariantCulture));
    }
}

internal class JsonSubSubLevel
{
    [JsonInclude][JsonPropertyName("id_sub_sub_level")]
    public required long Id { get; set; }
}

internal class JsonSubLevel
{
    [JsonInclude][JsonPropertyName("id_sub_level")]
    public required long Id {  get; set; }
    [JsonInclude][JsonPropertyName("name")]
    public required string Name { get; set; } = string.Empty;
    [JsonInclude][JsonPropertyName("sub_sub_level")]
    public required JsonSubSubLevel SubSubLevel { get; set; }
}

internal class JsonSource : ISource
{
    [JsonInclude][JsonPropertyName("id")]
    public required long Id {  get; set; }
    [JsonInclude][JsonPropertyName("name")]
    public required string Name { get; set; } = string.Empty;
    [JsonInclude]
    [JsonPropertyName("lst_mod_dt")]
    [JsonConverter(typeof(CustomSourceDateTimeConverter))]
    public required DateTime LastModificationDate { get; set; }
    [JsonInclude][JsonPropertyName("sub_levels")]
    public required IList<JsonSubLevel> SubLevels { get; set; }
}
