namespace Blazor.Data;

public interface IEmailService
{
    Task<Email> SendEmail(Email email);
    List<Email> GetAllMails();
    int GetIncomingCount();
    int GetSendCount();
}