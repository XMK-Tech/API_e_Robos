using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
    public class EmailServices : Notifications
    {
        private readonly IEmailRepository _repository;
        public EmailServices(IEmailRepository repository)
        {
            _repository = repository;
        }
        public List<EmailViewModel> List(Guid person_id)
        {
            try
            {
                List<Email> emails = _repository.Query().Where(e => e.EmailPersons.Any(e => e.PersonId == person_id)).ToList();
                return ConvertToViewModel(emails);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public Email Insert(string email)
        {
            try
            {
                return _repository.Insert(new Email { Value = email });
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);

                return null;
            }
        }
        public void Insert(List<string> models, Guid personId)
        {
            try
            {
                var entities = models.Select(e => ConvertToEntity(new EmailViewModel() { Value = e }, personId)).ToList();
                _repository.InsertMany(entities);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }

        public static List<EmailPerson> Create(List<string> models, Guid personId)
        {
            if (!models.Any())
                return new();

            return models.Select(e => new EmailPerson() 
            { 
                Email = new(e),
                PersonId = personId,
            }).ToList();
        }
        public void Update(Guid id, string email)
        {
            try
            {
                Email modelEmail = _repository.Get(e => e.Id == id).FirstOrDefault();

                if (modelEmail == null)
                {
                    StatusCode = 200;
                    ValidationMessages.Add("Email id is not valid");
                }

                modelEmail.Value = email;
                _repository.Update(modelEmail);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Update(List<string> models, Guid personId)
        {
            try
            {
                this.DeleteManyByPersonId(personId);

                _repository.InsertMany(models.Select(e => ConvertToEntity(new EmailViewModel() { Value = e }, personId)).ToList());

            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Delete(Guid email_id)
        {
            try
            {
                if (!_repository.Exists(email_id))
                {
                    StatusCode = 200;
                    ValidationMessages.Add("Email id is not valid");
                }

                _repository.Delete(email_id);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void DeleteManyByPersonId(Guid personId)
        {
            try
            {
                List<Email> emails = _repository.Query()
                  .Include(e => e.EmailPersons)
                  .Include(e => e.Users)
                  .Where(e =>
                    //Buscar todos os email que na tabela de EmailPersons esteja relacionado com o 'personId'
                    e.EmailPersons.Any(x => x.PersonId == personId) &&
                    //Mas não sejá um email de login do usuario
                    !e.Users.Any(x => x.EmailId == e.Id))
                  .ToList();

                _repository.DeleteMany(emails);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public bool Exists(string email)
        {
            return _repository.Get(e => e.Value.Equals(email)).Any();
        }
        public List<EmailViewModel> ConvertToViewModel(List<Email> model)
        {
            List<EmailViewModel> result = new List<EmailViewModel>();

            if (model == null) return result;

            foreach (Email item in model)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }
        public EmailViewModel ConvertToViewModel(Email model)
        {
            if (model == null) return null;

            EmailViewModel e = new EmailViewModel();
            e.Id = model.Id;
            e.Value = model.Value;
            return e;
        }
        public Email ConvertToEntity(EmailViewModel model, Guid personId)
        {
            if (model == null) return null;

            Email e = new Email(model.Value);

            var emailPersons = new List<EmailPerson>() { new EmailPerson(e.Id, personId) };
            e.EmailPersons = emailPersons;
            return e;
        }
    }
}
