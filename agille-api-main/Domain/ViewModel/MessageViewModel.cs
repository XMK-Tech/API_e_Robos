using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel
{
    public class MessageListParams
    {
        public Guid Id { get; set; }
        public MessageStatus Status { get; set; }
        public DateTime InitialDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
    public class MessageViewModel
    {
        public MessageViewModel(Guid id, string send_from, string send_to, string subject, string message, DateTime date_time, MessageStatus status, string observation)
        {
            Id = id;
            Send_from = send_from;
            Send_to = send_to;
            Subject = subject;
            Message = message;
            Date_time = date_time;
            Status = status;
            Observation = observation;
        }

        public Guid Id { get; set; }
        public string Send_from { get; set; }
        public string Send_to { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date_time { get; set; }
        public MessageStatus Status { get; set; }
        public string Observation { get; set; }
    }
    public class MessageTemplateInsertUpdateViewModel
    {
        public string Send_from { get; set; }
        public string Send_to { get; set; }
        public string Send_copy_myself { get; set; }
        public string Send_copy_to { get; set; }
        public string Data { get; set; }
        public string Message_template_code { get; set; }
        public IDictionary<string, string> Dynamic_field_options_values { get; set; } = new Dictionary<string, string>();
        /*public IDictionary<int, Dictionary<string, string>> Exception_dynamic_field_options_values { get; set; } = new Dictionary<int, Dictionary<string, string>>();*/
        public IDictionary<string, string> Attributes_options_values { get; set; } = new Dictionary<string, string>();
    }

    public class MessageTemplateBuild
    {
        public MessageTemplateBuild(string message, string subject, Guid messageId, /*IDictionary<int, Dictionary<string, string>> exception_dynamic_field_options_values,*/ IDictionary<string, string> dynamic_field_options_values, IDictionary<string, string> attributes_options_values)
        {
            Subject = subject;
            Message = message;
            MessageId = messageId;
            /*Exception_dynamic_field_options_values =exception_dynamic_field_options_values;*/
            Dynamic_field_options_values = dynamic_field_options_values;
            Attributes_options_values = attributes_options_values;
        }

        public string Subject { get; set; }
        public string Message { get; set; }
        public Guid MessageId { get; set; }
        public IDictionary<string, string> Dynamic_field_options_values { get; set; } = new Dictionary<string, string>();
        /*public IDictionary<int, Dictionary<string, string>> Exception_dynamic_field_options_values { get; set; } = new Dictionary<int, Dictionary<string, string>>();*/
        public IDictionary<string, string> Attributes_options_values { get; set; } = new Dictionary<string, string>();
    }

    public class MessageInsertUpdateViewModel
    {
        public MessageInsertUpdateViewModel(string send_to, MessageStatus status, MessageType type, string subject, string message, string send_copy_to = null, string send_copy_myself = null, string send_from = null, string data = null, string observation = null)
        {
            Send_from = send_from;
            Send_to = send_to;
            Send_copy_myself = send_copy_myself;
            Send_copy_to = send_copy_to;
            Data = data;
            Status = status;
            Type = type;
            Subject = subject;
            Message = message;
            Observation = observation;
        }

        public string Send_from { get; set; }
        public string Send_to { get; set; }
        public string Send_copy_myself { get; set; }
        public string Send_copy_to { get; set; }
        public string Data { get; set; }
        public MessageStatus Status { get; set; }
        public MessageType Type { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Observation { get; set; }
    }
    public class MessageViewModelResult
    {
        public string ErrosSending { get; set; }
        public string StatusDescription { get; set; }
        public MessageStatus Status { get; set; }
    }
}
