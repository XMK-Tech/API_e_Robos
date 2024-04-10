using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Domain.ViewModel
{
    public class MessageUserListParams
    {
        public Guid Id { get; set; }
        public Guid MessageQueueId { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageTemplateId { get; set; }
    }
    public class MessageUserViewModel
    {
        public MessageUserViewModel(Guid id, Guid messageQueueId, Guid userId, Guid messageTemplateId)
        {
            Id = id;
            MessageQueueId = messageQueueId;
            UserId = userId;
            MessageTemplateId = messageTemplateId;
        }

        public Guid Id { get; set; }
        public Guid MessageQueueId { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageTemplateId { get; set; }
    }
    public class MessageUserInsertViewModel
    {
        public Guid MessageQueueId { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageTemplateId { get; set; }
    }

}
