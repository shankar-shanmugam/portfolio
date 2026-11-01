using System.Text.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class FileContactMessageStore : IContactMessageStore
{
    private readonly string _directory;
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public FileContactMessageStore(IWebHostEnvironment environment)
    {
        _directory = Path.Combine(environment.ContentRootPath, "App_Data", "contact-messages");
    }

    public async Task SaveAsync(ContactFormModel message, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(_directory);

        var payload = new
        {
            ReceivedAtUtc = DateTime.UtcNow,
            message.Name,
            message.Email,
            message.Company,
            message.Subject,
            message.Message
        };

        var fileName = $"{DateTime.UtcNow:yyyyMMdd-HHmmssfff}-{Guid.NewGuid():N}.json";
        var path = Path.Combine(_directory, fileName);
        var json = JsonSerializer.Serialize(payload, JsonOptions);
        await File.WriteAllTextAsync(path, json, cancellationToken);
    }
}
