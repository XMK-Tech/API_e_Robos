using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface IServerServices
    {
        ResultCreatePersonAgiprevViewModel Insert(ServerInsertUpdateViewModel viewModel);
        void Update(ServerInsertUpdateViewModel viewModel, Guid Id);
        IEnumerable<ServerSelectViewModel> SelectCategory();
        ServerViewModel View(Guid personId);
    }
}
