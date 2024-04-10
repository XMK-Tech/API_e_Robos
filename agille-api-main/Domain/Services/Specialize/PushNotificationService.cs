using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Project.Application.Notifications
{
    public class PushNotificationService
    {
        private string SERVER_API_KEY { get; set; }
        private string SENDER_ID { get; set; }

        public PushNotificationService(IConfiguration config)
        {
            SERVER_API_KEY = config["FireBase:APIKey"];
            SENDER_ID = config["FireBase:SenderId"];
        }
        public MessageViewModelResult Send(MessageQueue message)
        {
            MessageViewModelResult result = new MessageViewModelResult();

            try
            {
                if (!string.IsNullOrEmpty(message.SendTo))
                {
                    dynamic notification = new
                    {
                        to = message.SendTo,
                        notification = new
                        {
                            title = message.Subject,
                            body = message.Message
                        },
                        data = new
                        {
                            type = message.Type.GetDescription(),
                            data = message.Data,
                            click_action = "FLUTTER_NOTIFICATION_CLICK"
                        }
                    };

                    var json = JsonSerializer.Serialize(notification);
                    var byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                    var tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    tRequest.ContentLength = byteArray.Length;

                    var dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    var tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();

                    var tReader = new StreamReader(dataStream);
                    var sResponseFromServer = tReader.ReadToEnd();

                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();

                    result.Status = MessageStatus.ENVIADA;
                    result.StatusDescription = MessageStatus.ENVIADA.GetDescription();

                }
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
