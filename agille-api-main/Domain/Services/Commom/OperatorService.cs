using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
    public class OperatorServices : IOperatorServices
    {
        private readonly IOperatorRepository _repository;
        private readonly IPersonServices _personServices;
        private readonly PhysicalPersonServices _physicalPersonServices;

        public OperatorServices(IOperatorRepository repository,
            IPersonServices personServices,
            PhysicalPersonServices physicalPersonServices)
        {
            _repository = repository;
            _personServices = personServices;
            _physicalPersonServices = physicalPersonServices;
        }
        public ResultCreatePersonAgiprevViewModel Insert(PersonInsertUpdateViewModelAgiPrev viewModel)
        {
            var person = _personServices.InsertUpdate(viewModel, AgiPrevPersonType.Operator);

            var entity = new Operator(person.Id);
            _repository.Insert(entity);
            _physicalPersonServices.CreateAgiPrev(person.Id, person.Name);
            return new ResultCreatePersonAgiprevViewModel(person.Id);
        }
        public void Update(PersonInsertUpdateViewModelAgiPrev viewModel, Guid id)
        {
            Operator entity = _repository.GetById(id);
            if (entity == null)
                throw new NotFoundException("Operator not found.");
            _personServices.InsertUpdate(viewModel, AgiPrevPersonType.Operator, entity.PersonId);
        }
        public OperatorViewModel View(Guid personId)
        {
            var result = _repository.Query()
                            .Where(x => x.PersonId == personId)
                            .Select(ConvertToViewModel())
                            .FirstOrDefault();
            if (result == null)
                throw new NotFoundException("Operator not found.");
            return result;

        }
        private static Expression<Func<Operator, OperatorViewModel>> ConvertToViewModel()
        {
            return x => new OperatorViewModel()
            {
                Id = x.Id,
                AgiPrevCode = x.Person.AgiPrevCode,
                Email = x.Person.EmailPersons.FirstOrDefault().Email.Value,
                Name = x.Person.Name,
            };
        }
    }
}