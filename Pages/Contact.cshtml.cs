using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages;

public class ContactModel : PageModel
{
    private readonly IContactMessageStore _messageStore;
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(IContactMessageStore messageStore, ILogger<ContactModel> logger)
    {
        _messageStore = messageStore;
        _logger = logger;
    }

    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public bool Submitted { get; private set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _messageStore.SaveAsync(ContactForm, cancellationToken);
            Submitted = true;
            ModelState.Clear();
            ContactForm = new ContactFormModel();
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save contact message from {Email}", ContactForm.Email);
            ModelState.AddModelError(string.Empty, "Something went wrong while sending your message. Please try again or email me directly.");
            return Page();
        }
    }
}
