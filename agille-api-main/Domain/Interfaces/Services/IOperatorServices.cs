using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface IOperatorServices
    {
        ResultCreatePersonAgiprevViewModel Insert(PersonInsertUpdateViewModelAgiPrev viewModel);
        void Update(PersonInsertUpdateViewModelAgiPrev viewModel, Guid id);
        OperatorViewModel View(Guid personId);
    }
}
