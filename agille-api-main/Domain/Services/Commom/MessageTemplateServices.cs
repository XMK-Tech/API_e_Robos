using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using AgilleApi.Domain.Entities;
using Domain.Services.Utils;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.Services.Commom
{
    public class MessageTemplateServices : Notifications
    {
        private readonly IMessageTemplateRepository _repository;
        private readonly IDynamicFieldsRepository _dynamicFieldsRepository;
        private readonly MessageServices _messageServices;
        public MessageTemplateServices(IMessageTemplateRepository messageRepository,
                                       IDynamicFieldsRepository dynamicFieldsRepository, MessageServices messageServices)
        {
            _repository = messageRepository;
            _dynamicFieldsRepository = dynamicFieldsRepository;
            _messageServices = messageServices;
        }
        public List<MessageTemplateViewModel> List(MessageTemplateListParams model, Metadata metadata)
        {
            try
            {
                IQueryable<MessageTemplate> query = _repository.Query();
                query = Filter(model, query, metadata);
                Expression<Func<MessageTemplate, object>> filter = e => e.Code;

                List<MessageTemplate> list = _repository.ExecuteQuery(query, metadata, filter);
                if (ServiceErrorHandle.ListNotEmpty(query, ValidationMessages, StatusCode, "messages templates"))
                    return ConvertToViewModel(list);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void Update(MessageTemplateUpdateViewModel model, Guid id)
        {
            try
            {
                MessageTemplate entity = _repository.Query().Where(e => e.Id == id).FirstOrDefault();

                if (entity == null)
                {
                    ValidationMessages.Add("Message id not valid");
                    return;
                }

                foreach (var code in GetBetween(entity.Message))
                {
                    var dynamicField = _dynamicFieldsRepository.Query().Where(e => e.Code.Equals(code)).FirstOrDefault();

                    if (dynamicField == null)
                    {
                        ValidationMessages.Add($"DynamicField {code} not found");
                        return;
                    }
                }

                entity.TemplateName = model.TemplateName;
                entity.Subject = model.Subject;
                entity.Message = model.Message;
                entity.SendCopyToMyself = model.SendCopyMyself;
                _repository.Update(entity);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public List<string> GetBetween(string strSource)
        {
            List<string> results = new List<string>();
            var rgx = new Regex(@"[[+[a-zA-Z0-9._-]+]]", RegexOptions.Compiled | RegexOptions.Multiline);
            var matches = rgx.Matches(strSource);
            foreach (Match match in matches)
            {
                results.Add(match.Value);
            }

            return results;
        }
        private IQueryable<MessageTemplate> Filter(MessageTemplateListParams model, IQueryable<MessageTemplate> query, Metadata metadata)
        {
            if (model.Id != Guid.Empty)
                query = query.Where(e => e.Id == model.Id);

            if (model.MessageType != Enums.MessageType.Null)
                query = query.Where(e => e.Type == model.MessageType);

            if (model.Code != null)
                query = query.Where(e => e.Code.Contains(model.Code));

            if (metadata.QuickSearch != null)
                query = query.Where(e => e.Code.Contains(metadata.QuickSearch));

            return query;
        }
        private List<MessageTemplateViewModel> ConvertToViewModel(List<MessageTemplate> list)
        {
            List<MessageTemplateViewModel> result = new List<MessageTemplateViewModel>();

            foreach (MessageTemplate item in list)
            {
                result.Add(new MessageTemplateViewModel(item.Id,
                                                        item.Code,
                                                        item.Type,
                                                        item.TemplateName,
                                                        item.Subject,
                                                        item.Message,
                                                        item.SendCopyToMyself));
            }
            return result;
        }
        public MessageTemplate View(string code)
        {
            return _repository.Query().Where(e => e.Code.Equals(code)).AsNoTracking().FirstOrDefault();
        }
        public void BuildMessage(MessageTemplateBuild messageTemplate)
        {
            try
            {
                //var i = 0;
                foreach (var code in GetBetween(messageTemplate.Message))
                {
                    //i++;

                    var dynamicField = _dynamicFieldsRepository.Query().Where(e => e.Code.Equals(code)).FirstOrDefault();

                    if (dynamicField == null)
                    {
                        ValidationMessages.Add($"DynamicField {code} not found");
                        return;
                    }
                    else
                    {
                        string sqlCommand = null;
                        if (messageTemplate.Dynamic_field_options_values.ContainsKey($"{dynamicField.Schema}.{dynamicField.Table}"))
                        {
                            string valueToReplace = "";

                            //if (messageTemplate.Exception_dynamic_field_options_values[i] != null)
                            //valueToReplace = messageTemplate.Exception_dynamic_field_options_values[i][$"{dynamicField.Schema}.{dynamicField.Table}"];
                            //else
                            valueToReplace = messageTemplate.Dynamic_field_options_values[$"{dynamicField.Schema}.{dynamicField.Table}"];
                            if (valueToReplace != null)
                            {
                                if (dynamicField.Schema == "[dbo]")
                                {
                                    //MSSQL
                                    sqlCommand = $"update messages set message = REPLACE(message, '" + dynamicField.Code + "', " +
                                             $"(select top 1 Convert(varchar(100), [{dynamicField.Column}]) from {dynamicField.Schema}.[{dynamicField.Table}] where [{dynamicField.ColumnKey}] = '{valueToReplace}')) " +
                                             $"where id = '{messageTemplate.MessageId}'";

                                }
                                else
                                {
                                    //MySQL
                                    sqlCommand = $"update {dynamicField.Schema}.messages set message = REPLACE(message, '" + dynamicField.Code + "', " +
                                    $"(Select Convert({dynamicField.Column}, char(100)) as {dynamicField.Column} from {dynamicField.Schema}.{dynamicField.Table} where {dynamicField.ColumnKey} = '{valueToReplace}' Limit 1)) where id = '{messageTemplate.MessageId}'";
                                }
                            }
                        }

                        if (messageTemplate.Attributes_options_values.ContainsKey($"{dynamicField.Code}"))
                        {
                            string valueToReplace = messageTemplate.Attributes_options_values[$"{dynamicField.Code}"];
                            if (valueToReplace != null)
                            {
                                if (dynamicField.Schema == "[dbo]")
                                {
                                    //MSSQL
                                    sqlCommand = $"update messages set message = REPLACE(message, '" + dynamicField.Code + "','" + valueToReplace + "') " +
                                             $"where id = '{messageTemplate.MessageId}'";
                                }
                                else
                                {
                                    //MySQL
                                    sqlCommand = $"update {dynamicField.Schema}.messages set message = REPLACE(message, '" + dynamicField.Code + "','" + valueToReplace + "') " + $"where id = '{messageTemplate.MessageId}'";
                                }

                            }
                        }

                        if (!String.IsNullOrEmpty(sqlCommand))
                        {
                            _repository.ExecuteSqlRaw(sqlCommand);
                            sqlCommand = null;
                        }
                    }
                }

                foreach (var code in GetBetween(messageTemplate.Subject))
                {
                    var dynamicField = _dynamicFieldsRepository.Query().Where(e => e.Code.Equals(code)).FirstOrDefault();

                    if (dynamicField == null)
                    {
                        ValidationMessages.Add($"DynamicField {code} not found");
                        return;
                    }
                    else
                    {
                        string sqlCommand = null;
                        if (messageTemplate.Dynamic_field_options_values.ContainsKey($"{dynamicField.Schema}.{dynamicField.Table}"))
                        {
                            string valueToReplace = messageTemplate.Dynamic_field_options_values[$"{dynamicField.Schema}.{dynamicField.Table}"];
                            if (valueToReplace != null)
                                if (dynamicField.Schema == "[dbo]")
                                {
                                    //MSSQL
                                    sqlCommand = $"update messages set subject = REPLACE(subject, '" + dynamicField.Code + "', " +
                                           $"(select top 1 Convert(varchar(100), {dynamicField.Column}) from {dynamicField.Schema}.{dynamicField.Table} where {dynamicField.ColumnKey} = '{valueToReplace}')) " +
                                           $"where id = '{messageTemplate.MessageId}'";
                                }
                                else
                                {
                                    //MySQL
                                    sqlCommand = $"update {dynamicField.Schema}.messages set subject = REPLACE(subject, '" + dynamicField.Code + "', " +
                                           $"(Select Convert({dynamicField.Column}, char(100)) as {dynamicField.Column} from {dynamicField.Schema}.{dynamicField.Table} where {dynamicField.ColumnKey} = '{valueToReplace}' Limit 1)) " +
                                           $"where id = '{messageTemplate.MessageId}'";
                                }
                        }

                        if (!String.IsNullOrEmpty(sqlCommand))
                        {
                            _repository.ExecuteSqlRaw(sqlCommand);
                            sqlCommand = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
                return;
            }
        }
        public MessageQueue InsertMessegaQueue(MessageTemplateInsertUpdateViewModel messageTemplateViewModel, bool buildMessageAutomatic = true, bool dispacherAutomatic = true)
        {
            var messageTemplate = this.View(messageTemplateViewModel.Message_template_code);
            if (messageTemplate == null)
            {
                ValidationMessages.Add("Template Message not found");
                return null;
            }

            var messageQueue = _messageServices.Insert(new MessageInsertUpdateViewModel(
              messageTemplateViewModel.Send_to,
              MessageStatus.NAFILA,
              messageTemplate.Type,
              messageTemplate.Subject,
              messageTemplate.Message,
              messageTemplateViewModel.Send_copy_to,
              messageTemplateViewModel.Send_copy_myself,
              messageTemplateViewModel.Send_from,
              messageTemplateViewModel.Data
            ));

            if (buildMessageAutomatic)
            {
                this.BuildMessage(new MessageTemplateBuild(messageQueue.Message, messageQueue.Subject, messageQueue.Id, /*messageTemplateViewModel.Exception_dynamic_field_options_values,*/ messageTemplateViewModel.Dynamic_field_options_values, messageTemplateViewModel.Attributes_options_values));
            }

            if (dispacherAutomatic)
            {
                _messageServices.Dispacher(messageQueue.Id);
            }
            return messageQueue;
        }
    }
}
