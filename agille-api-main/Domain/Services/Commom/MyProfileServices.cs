using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Services.Commom;

public class MyProfileServices : Notifications
{
    private readonly ISessionServices _sessionServices;
    private readonly PhysicalPersonServices _physicalPersonServices;
    private readonly IPersonServices _personServices;

    public MyProfileServices(
        ISessionServices sessionServices, 
        PhysicalPersonServices physicalPersonServices, 
        IPersonServices personServices)
    {
        _sessionServices = sessionServices;
        _physicalPersonServices = physicalPersonServices;
        _personServices = personServices;
    }

    public PhysicalPersonViewModel View()
    {
        var userId = _sessionServices.GetUserId();
        var physicalPersonId = GetPhysicalPersonId(userId.Value);

        if (!physicalPersonId.HasValue)
            throw new NotFoundException("Nenhuma pessoa está relacionada ao usuário atual.");
        
        return _physicalPersonServices.View(physicalPersonId.Value);
    }

    private Guid? GetPhysicalPersonId(Guid userId)
    {
        return _personServices.GetPhysicalPersonIdByUserId(userId);
    }
}