using asp06.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
var mailsettings = builder.Configuration.GetSection("MailSetting");

builder.Services.Configure<MailSetting>(mailsettings);
builder.Services.AddTransient<SendMailService>();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/SendMail", async context =>
    {
        var message = await MailUtils.MailUtils.SendMail("123456nuct@gmail.com", "123456nuct@gmail.com","Test","Test send mail");
        await context.Response.WriteAsync(message);
    });
    endpoints.MapGet("/SendGmail", async context =>
    {
        var message = await MailUtils.MailUtils.SendGmail("sarasadisure@gmail.com", "sarasadisure@gmail.com", "TestGmail 2024", "Xin chao Ninh Son 2024", "sarasadisure@gmail.com", "rijd upal jajt jyba");
        await context.Response.WriteAsync(message);
    });
    endpoints.MapGet("/SendMailService", async context =>
    {
        var sendMailService = context.RequestServices.GetService<SendMailService>();
        var mailContent = new MailContent();

        mailContent.To = "sarasadisure@gmail.com";
        mailContent.Subject = "Test Send Mail Service";
        mailContent.Body = "<h1>bai hoc da ket thuc</h1>";

     var kq = await sendMailService.SendMail(mailContent);
        
        await context.Response.WriteAsync( kq);
    });
});
app.MapGet("/", () => "Hello World!");


app.Run();
