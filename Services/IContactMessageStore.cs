using Portfolio.Models;

namespace Portfolio.Services;

public interface IContactMessageStore
{
    Task SaveAsync(ContactFormModel message, CancellationToken cancellationToken = default);
}
