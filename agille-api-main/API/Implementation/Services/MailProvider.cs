
using AgilleApi.API.Implementation.Interfaces;

namespace AgilleApi.API.Implemantation.Services
{
    public class MailProvider : IMailProvider
    {
        //private readonly IRazorPageRenderer _render;

        //public MailProvider(IRazorPageRenderer render)
        //{
        //    this._render = render;
        //}
        //public async void SendAsync(GenericMailDto model, string templateName) {

        //    try
        //    {
        //		var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        //		var configuration = builder.Build();

        //		MailAddress from = new MailAddress(configuration["Smtp:FromAddress"], configuration["Smtp:FromName"]);
        //		MailAddress to = new MailAddress(model.ToAddress, model.ToName);
        //		MailMessage message = new MailMessage(from, to);

        //		message.Subject = model.Subject;

        //		var page = await _render.RenderViewToStringAsync(
        //			$"Resources/Mail/{templateName}.cshtml", model
        //			);
        //		message.IsBodyHtml = true;

        //		message.Body = page;

        //		SmtpClient client = new SmtpClient(configuration["Smtp:Host"])
        //		{
        //			Port = int.Parse(configuration["Smtp:Port"]),
        //			Credentials = new NetworkCredential(configuration["Smtp:Username"], configuration["Smtp:Password"]),
        //			EnableSsl = true
        //		};

        //		try
        //		{
        //			client.SendAsync(message, null);
        //		}
        //		catch (SmtpException e)
        //		{
        //			Console.Write(e.StatusCode);
        //		}
        //		catch (Exception ex)
        //		{
        //			Console.WriteLine("Exception: {0}",
        //				ex.ToString());
        //		}

        //	}
        //    catch (Exception)
        //    {
        //		//Precisamos tratar quando não enviar o e-mail..
        //    }
        //}
    }
}
