using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Translator.interfaces;

namespace Translator.services;


internal class JsonDestination : IDestination
{
    [JsonInclude][JsonPropertyName("identitier")]
    public required long Identifier { get; set; }
    [JsonPropertyName("lst_mod_dt")]
    [JsonConverter(typeof(CustomDestinationDateTimeConverter))]
    public required DateTime LastModificationDate { get; set; }
    [JsonInclude][JsonPropertyName("details")]
    public required Details Details { get; set; }
}

internal class CustomDestinationDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString()!, "u", CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("s", CultureInfo.InvariantCulture));
    }
}

internal class Details
{
    [JsonInclude][JsonPropertyName("name")]
    public required string Name { get; set; } = string.Empty;
    [JsonInclude][JsonPropertyName("ids")]
    public required IList<long> SubLevelIdentifiers { get; set; }
}