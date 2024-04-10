using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using Project.Application.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
    public class MessageServices : Notifications
    {
        private readonly IMessageRepository _repository;
        private readonly EmailNotificationService _emailNotificationService;
        private readonly PushNotificationService _pushNotificationService;
        public MessageServices(IMessageRepository messageRepository,
                               EmailNotificationService emailNotificationService,
                               PushNotificationService pushNotificationService)
        {
            _repository = messageRepository;
            _emailNotificationService = emailNotificationService;
            _pushNotificationService = pushNotificationService;
        }
        public List<MessageViewModel> List(MessageListParams model, Metadata metadata)
        {
            try
            {
                IQueryable<MessageQueue> query = _repository.Query();
                query = Filter(model, query);
                List<MessageQueue> list = _repository.ExecuteQuery(query, metadata);

                if (ServiceErrorHandle.ListNotEmpty(query, ValidationMessages, StatusCode, "messages"))
                    return ConvertToViewModel(list);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public MessageQueue Insert(MessageInsertUpdateViewModel model)
        {
            try
            {
                return _repository.Insert(ConvertToEntity(model));
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
                return null;
            }
        }
        public void Update(MessageInsertUpdateViewModel model, Guid id)
        {
            try
            {
                if (!_repository.Exists(id))
                {
                    ValidationMessages.Add("Message id not valid");
                    return;
                }

                MessageQueue entity = ConvertToEntity(model);
                entity.Id = id;
                _repository.Update(entity);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                if (!_repository.Exists(id))
                {
                    ValidationMessages.Add("Message id not valid");
                    return;
                }
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        private IQueryable<MessageQueue> Filter(MessageListParams model, IQueryable<MessageQueue> query)
        {
            if (model.Id != Guid.Empty)
                query = query.Where(e => e.Id == model.Id);
            if (model.Status != Enums.MessageStatus.Null)
                query = query.Where(e => e.Status == model.Status);
            if (model.InitialDateTime != DateTime.MinValue)
                query = query.Where(e => e.Date >= model.InitialDateTime);
            if (model.EndDateTime != DateTime.MinValue)
                query = query.Where(e => e.Date <= model.InitialDateTime);
            return query;
        }
        private List<MessageViewModel> ConvertToViewModel(List<MessageQueue> list)
        {
            List<MessageViewModel> result = new List<MessageViewModel>();
            foreach (MessageQueue item in list)
            {
                result.Add(new MessageViewModel(item.Id, item.SendFrom, item.SendTo, item.Subject, item.Message, item.Date, item.Status, item.Observation));
            }
            return result;
        }
        private MessageQueue ConvertToEntity(MessageInsertUpdateViewModel model)
        {
            return new MessageQueue(model.Send_from,
                                    model.Send_to,
                                    model.Send_copy_myself,
                                    model.Send_copy_to,
                                    model.Subject,
                                    model.Message,
                                    model.Status,
                                    model.Type,
                                    model.Observation,
                                    model.Data);
        }
        public MessageViewModelResult Dispacher(Guid messageId)
        {
            var message = _repository.GetById(messageId);
            _repository.Reload(message);

            if (message.Type == MessageType.Email)
            {
                return EmailDispacher(message);
            }

            if (message.Type == MessageType.PushNotification)
            {
                return PushNotificationDispacher(message);
            }

            return null;
        }
        public MessageViewModelResult EmailDispacher(MessageQueue message)
        {
            return _emailNotificationService.Send(message);
        }
        public MessageViewModelResult PushNotificationDispacher(MessageQueue message)
        {
            return _pushNotificationService.Send(message);
        }
    }
}
