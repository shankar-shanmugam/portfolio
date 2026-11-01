# Shankar S — Portfolio

ASP.NET Core Razor Pages portfolio for Backend .NET Developer roles.

**Live site:** https://shankar-portfolio-pbxc.onrender.com

The free host sleeps after about 15 minutes with no visitors. The first open after that can take up to a minute.

## Run locally

```powershell
cd portfolio
dotnet restore
dotnet run
```

Then open the URL shown in the terminal (default `https://localhost:7164` or `http://localhost:5038`).

## Pages

- `/` — Home
- `/Experience` — Current role at Acess Meditech
- `/CaseStudy` — Non-Motor Claims ERP case study
- `/Projects` — Professional + personal project
- `/About` — Education, training, availability, location
- `/Contact` — Validated contact form

## Resume download

The PDF is served from:

`wwwroot/resume/Shankar-S-Resume.pdf`

Replace that file when you update your resume. Keep the same filename, or update the download links in the layout and pages.

## Contact form storage

Successful form submissions are saved as JSON files under:

`App_Data/contact-messages/`

No SMTP is configured in v1. To add email later:

1. Configure an SMTP provider in `appsettings.json`.
2. Inject `IEmailSender` (or a custom mail service) into `Contact.cshtml.cs`.
3. Send mail after `_messageStore.SaveAsync(...)` succeeds.

## Notes

- Content is aligned with the resume in the parent folder.
- Company name is spelled **Acess Meditech Private Limited** as on the resume.
- .NET 10 / ASP.NET Core 10 modernization is described as ongoing.
