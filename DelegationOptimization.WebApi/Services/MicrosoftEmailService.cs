namespace DelegationOptimization.WebApi.Services;

public class MicrosoftEmailService: IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        // Send email with Microsoft
        Thread.Sleep(100);
    }
}