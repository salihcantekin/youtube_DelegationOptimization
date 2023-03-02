using DelegationOptimization.WebApi.Extensions;
using DelegationOptimization.WebApi.Services;
using TechBuddy.Extensions.AspNetCore.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IEmailService>(sp =>
{
    var mailProvider = builder.Configuration.GetValue<MailProvider>("MailProvider");
    switch (mailProvider)
    {
        case MailProvider.Google:
            return new GoogleEmailService();
        case MailProvider.Microsoft:
            return new MicrosoftEmailService();
        default:
            throw new ArgumentOutOfRangeException(nameof(mailProvider), mailProvider, null);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();