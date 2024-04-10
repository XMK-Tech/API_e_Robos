using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
    public class ServerServices : IServerServices
    {
        private readonly IServerRepository _repository;
        private readonly IPersonServices _personServices;
        private readonly PhysicalPersonServices _physicalPersonServices;

        public ServerServices(IServerRepository repository,
            IPersonServices personServices,
            PhysicalPersonServices physicalPersonServices)
        {
            _repository = repository;
            _personServices = personServices;
            _physicalPersonServices = physicalPersonServices;
        }
        public ResultCreatePersonAgiprevViewModel Insert(ServerInsertUpdateViewModel viewModel)
        {
            var person = _personServices.InsertUpdate(viewModel.ConvertToPersonViewModel(), AgiPrevPersonType.Server);

            var entity = ConvertToEntity(viewModel, personId: person.Id);
            _repository.Insert(entity);
            _physicalPersonServices.CreateAgiPrev(person.Id, person.Name);
            return new ResultCreatePersonAgiprevViewModel(person.Id);
        }
        public void Update(ServerInsertUpdateViewModel viewModel, Guid id)
        {
            Server entity = _repository.GetById(id);
            if (entity == null)
                throw new NotFoundException("Server not found.");
            _personServices.InsertUpdate(viewModel.ConvertToPersonViewModel(), AgiPrevPersonType.Server, entity.PersonId);

            entity = ConvertToEntity(viewModel, entity: entity);
            _repository.Update(entity);
        }
        public IEnumerable<ServerSelectViewModel> SelectCategory()
        {
            return Enum.GetValues(typeof(ServerCategory))
                                .Cast<ServerCategory>()
                                .Where(v => (int)v != 0)
                                .Select(v => new ServerSelectViewModel(v.GetDescription(), (int)v));
        }
        public ServerViewModel View(Guid personId)
        {
            var result = _repository.Query()
                            .Where(x => x.PersonId == personId)
                            .Select(ConvertToViewModel())
                            .FirstOrDefault();
            if (result == null)
                throw new NotFoundException("Server not found.");
            return result;

        }
        private static Expression<Func<Server, ServerViewModel>> ConvertToViewModel()
        {
            return x => new ServerViewModel()
            {
                Id = x.Id,
                AgiPrevCode = x.Person.AgiPrevCode,
                Email = x.Person.EmailPersons.FirstOrDefault().Email.Value,
                Name = x.Person.Name,
                AdmissionDate = x.AdmissionDate,
                CTPSNumber = x.CTPSNumber,
                CTPSSeries = x.CTPSSeries,
                Registration = x.Registration,
                PisPasepNumber = x.PIS_PASEPNumber,
                ServerCategory = x.ServerCategory,
            };
        }
        private static Server ConvertToEntity(ServerInsertUpdateViewModel viewModel, Guid? personId = null, Server entity = null)
        {
            if (entity == null)
                entity = new Server((Guid)personId, viewModel.AdmissionDate, viewModel.CTPSNumber, viewModel.CTPSSeries, viewModel.Registration, viewModel.PisPasepNumber, viewModel.ServerCategory);
            else
                entity.Update(viewModel.AdmissionDate, viewModel.CTPSNumber, viewModel.CTPSSeries, viewModel.Registration, viewModel.PisPasepNumber, viewModel.ServerCategory);
            return entity;
        }
    }
}