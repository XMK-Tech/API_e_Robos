using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
    public class ParamServices : Notifications
    {
        private readonly IParamRepository _repository;

        public ParamServices(IParamRepository repository)
        {
            _repository = repository;
        }
        public List<ParamViewModel> List(ParamViewModel model, Metadata metadata)
        {
            try
            {
                IQueryable<Param> query = _repository.Query();
                query = Filter(model, query,metadata);
                Expression<Func<Param, object>> filter = e => e.Code;
                List<Param> list = _repository.ExecuteQuery(query, metadata,filter);
                if (ServiceErrorHandle.ListNotEmpty(query, ValidationMessages, StatusCode, "Param"))
                    return ConvertToViewModel(list);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void Insert(ParamInsertViewModel model)
        {
            try
            {
                _repository.Insert(ConvertToEntity(model));
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void Delete(Guid param_id)
        {
            try
            {
                if (!_repository.Exists(param_id))
                {
                    ValidationMessages.Add("Param id not valid");
                    return;
                }
                _repository.Delete(param_id);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void Update(ParamInsertViewModel model, Guid id)
        {
            try
            {
                if (!_repository.Exists(id))
                {
                    ValidationMessages.Add("Param id not valid");
                    return;
                }
                Param entity = ConvertToEntity(model);
                entity.Id = id;
                _repository.Update(entity);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        private IQueryable<Param> Filter(ParamViewModel model, IQueryable<Param> query,Metadata metadata)
        {
            if (model.Id != Guid.Empty)
                query = query.Where(e => e.Id == model.Id);
            if (model.Code != null)
                query = query.Where(e => e.Code == model.Code);
            if (model.Description != null)
                query = query.Where(e => e.Description.Contains(model.Description));
            if (metadata.QuickSearch != null)
                query = query.Where(e => e.Code.Contains(metadata.QuickSearch) || e.Description.Contains(metadata.QuickSearch));
            return query;
        }
        private List<ParamViewModel> ConvertToViewModel(List<Param> list)
        {
            List<ParamViewModel> models = new List<ParamViewModel>();
            foreach (Param item in list)
            {
                ParamViewModel viewModel = new ParamViewModel()
                {
                    Id = item.Id,
                    Code = item.Code,
                    Description = item.Description
                };
                models.Add(viewModel);
            }
            return models;
        }
        private Param ConvertToEntity(ParamInsertViewModel model)
        {
            return new Param(model.Code, model.Description);

        }
    }
}
