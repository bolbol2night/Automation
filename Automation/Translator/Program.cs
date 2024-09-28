using Translator.services;

namespace Translator;

internal class Program
{
    static void Main(string[] args)
    {
        var translator = new services.Translator();
        var source = new JsonSource
        {
            Id = 1,
            Name = "test",
            LastModificationDate = DateTime.Now,
            SubLevels = new[] {
                new JsonSubLevel{Id = 10, Name = "Test10", SubSubLevel = new() { Id = 100 } },
                new JsonSubLevel{Id = 11, Name = "Test11", SubSubLevel = new() { Id = 101 } },
                new JsonSubLevel{Id = 12, Name = "Test12", SubSubLevel = new() { Id = 102 } },
            }
        };
        var destination = translator.Translate(source);
    }
}
