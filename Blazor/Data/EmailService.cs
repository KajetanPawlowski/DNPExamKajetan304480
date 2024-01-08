namespace Blazor.Data;

public class EmailService : IEmailService
{
    private const string SENDER = "Kajetan";
    public List<Email> allMails { get; private set; }
    
    public EmailService()
    {
        allMails = CreateDummyMails(15);
    }
    public Task<Email> SendEmail(Email email)
    {
        email.SenderName = SENDER;
        email.Timestamp = DateTime.Now;
        allMails.Add(email);
        return Task.FromResult(email);
    }

    public List<Email> GetAllMails()
    {
        return allMails;
    }

    public int GetIncomingCount()
    {
        IEnumerable<Email> incoming = allMails.Where(e => e.ReceiverName.Equals(SENDER));
        return incoming.Count();
    }

    public int GetSendCount()
    {
        IEnumerable<Email> send = allMails.Where(e => e.SenderName.Equals(SENDER));
        return send.Count();
    }

    private List<Email> CreateDummyMails(int count)
    {
        Random random = new Random();
        string[] names = new[] { "Kajetan", "Maja", "Ariana", "Rado" };
        string[] titles = new[] { "Armagedon", "DNP Exam", "SEP Project", "Snow everywhere" };
        string[] bodies = new[] { "that is a long mail body", "somethong writen here" };
        List<Email> result = new List<Email>();
        for (int i = 0; i < count; i++)
        {
            Email next = new()
            {
                SenderName = names[random.Next(0,3)],
                ReceiverName = names[random.Next(0,3)],
                Title = titles[random.Next(0,3)],
                Body = bodies[random.Next(0,1)],
                Timestamp = DateTime.Now
            };
            result.Add(next);
        }

        return result;
    }
}