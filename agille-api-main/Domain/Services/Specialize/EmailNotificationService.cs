using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace AgilleApi.Domain.Services.Specialize
{
  public class EmailNotificationService
  {
    public string EmitterEmail { get; private set; }
    public string UsernameSmtp { get; private set; }
    public string PasswordSmtp { get; private set; }
    public string Port { get; private set; }
    public string Host { get; private set; }

    public EmailNotificationService(IConfiguration config)
    {
      EmitterEmail = config["Smtp:FromAddress"];
      UsernameSmtp = config["Smtp:Username"];
      PasswordSmtp = config["Smtp:Password"];
      Port = config["Smtp:Port"];
      Host = config["Smtp:Host"];
    }

    public MessageViewModelResult Send(MessageQueue message)
    {
      MessageViewModelResult result = new MessageViewModelResult();

      try
      {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(EmitterEmail);
        mail.To.Add(message.SendTo);

        if (!String.IsNullOrEmpty(message.SendCopyTo))
        {
          foreach (var sendCopyTo in message.SendCopyTo.Split(';'))
          {
            mail.CC.Add(sendCopyTo);
          }
        }

        if (!String.IsNullOrEmpty(message.SendCopyMyself))
          mail.CC.Add(message.SendCopyMyself);

        mail.Subject = message.Subject;
        mail.IsBodyHtml = true;
        mail.Body = message.Message;
        mail.Priority = MailPriority.High;

        SmtpClient smtp = new SmtpClient(Host, Convert.ToInt32(Port));
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(UsernameSmtp, PasswordSmtp);
        smtp.EnableSsl = false;

        smtp.Send(mail);
        result.Status = MessageStatus.ENVIADA;
        result.StatusDescription = MessageStatus.ENVIADA.GetDescription();
      }
      catch (Exception ex)
      {
        result.Status = MessageStatus.FALHAAOENVIAR;
        result.StatusDescription = MessageStatus.FALHAAOENVIAR.GetDescription();
        result.ErrosSending = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
      }

      return result;
    }
  }
}
