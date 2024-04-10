using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
    public class PhoneServices : Notifications
    {
        private readonly IPhoneRepository _repository;
        public PhoneServices(IPhoneRepository repository)
        {
            _repository = repository;
        }
        public List<PhoneViewModel> List(Guid person_id)
        {
            try
            {
                List<Phone> Phones = _repository.Get(e => e.PersonId == person_id);
                return ConvertToViewModel(Phones);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public void Insert(PhoneViewModel model, Guid personId)
        {
            try
            {
                Phone entity = ConvertToEntity(model, personId);
                if (entity == null)
                {
                    ValidationMessages.Add("Fail to find the entity");
                    return;
                }

                _repository.Insert(entity);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Insert(List<PhoneViewModel> models, Guid personId)
        {
            try
            {
                _repository.InsertMany(Create(models, personId));
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }

        public List<Phone> Create(List<PhoneViewModel> models, Guid personId)
        {
            if (!models.Any())
                return new();

            return models.Select(e => ConvertToEntity(e, personId)).ToList();
        }

        public void Update(List<PhoneViewModel> models, Guid personId)
        {
            try
            {
                this.DeleteManyByPersonId(personId);
                _repository.InsertMany(models.Select(e => ConvertToEntity(e, personId)).ToList());
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Delete(Guid Phone_id)
        {
            try
            {
                if (!_repository.Exists(Phone_id))
                {
                    StatusCode = 200;
                    ValidationMessages.Add("Phone id is not valid");
                }

                _repository.Delete(Phone_id);
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
                List<Phone> phones = _repository.Get(e => e.PersonId == personId).ToList();
                if (phones.Any())
                    _repository.DeleteMany(phones);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public static List<PhoneViewModel> ConvertToViewModel(List<Phone> model)
        {
            List<PhoneViewModel> result = new List<PhoneViewModel>();
            if (model == null) return result;

            foreach (Phone item in model)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }
        public static PhoneViewModel ConvertToViewModel(Phone model)
        {
            if (model == null) return null;

            return new PhoneViewModel(model.Type,
                                      model.Number);
        }
        public Phone ConvertToEntity(PhoneViewModel model, Guid personId)
        {
            if (model == null) return null;

            return new Phone(model.Number,
                             model.Type,
                             personId);
        }
    }
}
