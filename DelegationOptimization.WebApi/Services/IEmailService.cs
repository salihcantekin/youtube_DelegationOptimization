namespace DelegationOptimization.WebApi.Services;

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public enum MailProvider
{
    Google,
    Microsoft
}