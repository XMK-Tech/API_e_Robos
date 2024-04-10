using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
    public class SocialMediaServices : Notifications
    {
        private readonly ISocialMediaRepository _repository;
        public SocialMediaServices(ISocialMediaRepository repository)
        {
            _repository = repository;
        }
        public List<SocialMediaViewModel> List(Guid person_id)
        {
            try
            {
                List<SocialMedia> SocialMedias = _repository.Get(e => e.PersonId == person_id);
                if (SocialMedias.Count == 0)
                {
                    ValidationMessages.Add("None SocialMedia was found");
                    return null;
                }
                return ConvertToViewModel(SocialMedias);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public void Insert(SocialMediaViewModel model, Guid personId)
        {
            try
            {
                SocialMedia entity = ConvertToEntity(model, personId);
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
        public void Insert(List<SocialMediaViewModel> models, Guid personId)
        {
            try
            {
                _repository.InsertMany(Create(models,personId));
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }

        public List<SocialMedia> Create(List<SocialMediaViewModel> models, Guid personId)
        {
            if (!models.Any())
                return new();

            return models.Select(e => ConvertToEntity(e, personId)).ToList();
        }

        public void Update(List<SocialMediaViewModel> models, Guid person_id)
        {
            try
            {
                this.DeleteManyByPersonId(person_id);

                _repository.InsertMany(models.Select(e => ConvertToEntity(e, person_id)).ToList());

            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Delete(Guid SocialMedia_id)
        {
            try
            {
                if (!_repository.Exists(SocialMedia_id))
                {
                    StatusCode = 200;
                    ValidationMessages.Add("SocialMedia id is not valid");
                }

                _repository.Delete(SocialMedia_id);
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
                List<SocialMedia> socialMedia = _repository.Get(e => e.PersonId == personId).ToList();
                if (socialMedia.Any())
                    _repository.DeleteMany(socialMedia);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public static List<SocialMediaViewModel> ConvertToViewModel(List<SocialMedia> model)
        {
            List<SocialMediaViewModel> result = new List<SocialMediaViewModel>();
            if (model == null) return result;

            foreach (SocialMedia item in model)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }
        public static SocialMediaViewModel ConvertToViewModel(SocialMedia model)
        {
            if (model == null) return null;

            return new SocialMediaViewModel(model.Type,
                                            model.Url);
        }
        public SocialMedia ConvertToEntity(SocialMediaViewModel model, Guid personId)
        {
            if (model == null) return null;

            return new SocialMedia(model.Type,
                                   model.Url,
                                   personId);
        }
    }
}
