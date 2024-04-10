using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel
{
  public class MessageTemplateListParams
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public MessageType MessageType { get; set; } = MessageType.Null;

    }
    public class MessageTemplateViewModel
    {
        public MessageTemplateViewModel(
            Guid id,
            string code,
            MessageType messageType,
            string templateName,
            string subject,
            string message,
            bool sendCopyMyself)
        {
            Id = id;
            Code = code;
            MessageType = messageType;
            TemplateName = templateName;
            Subject = subject;
            Message = message;
            SendCopyMyself = sendCopyMyself;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public MessageType MessageType { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool SendCopyMyself { get; set; }

    }
    public class MessageTemplateUpdateViewModel
    {
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool SendCopyMyself { get; set; }
    }
}
