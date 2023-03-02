namespace DelegationOptimization.WebApi.Services;


public class GoogleEmailService: IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        // Send email with Google
        Thread.Sleep(100);
    }
}