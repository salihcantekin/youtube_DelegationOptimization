using TechBuddy.Extensions.AspNetCore.ExceptionHandling;

namespace DelegationOptimization.WebApi.Extensions;

public static class ExceptionHandlerExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        var logEverything = app.Configuration.GetValue<bool>("LogEverything");
        if (logEverything)
        {
            ExceptionHandlerWithDetails(app);
        }
        else
        {
            ExceptionHandlerWithNoDetails(app);
        }
    }

    private static void ExceptionHandlerWithNoDetails(WebApplication app)
    {
        ExceptionHandlerWithAction(app, ((_, logger) =>
        {
            logger.LogError("An error occurred");
        }));
    }
    
    private static void ExceptionHandlerWithDetails(WebApplication app)
    {
        ExceptionHandlerWithAction(app, ((exception, logger) =>
        {
            logger.LogError(exception,"An error occurred");
        }));
    }

    private static void ExceptionHandlerWithAction(WebApplication app, Action<Exception, ILogger> logAction)
    {
        app.ConfigureTechBuddyExceptionHandling(opt =>
        {
            opt.UseLogger();
            opt.UseCustomHandler((context, exception, logger) =>
            {
                logAction(exception, logger);
                context.Response.StatusCode = 500;
                return context.Response.WriteAsync("An error occurred");
            });
        });
    }
}