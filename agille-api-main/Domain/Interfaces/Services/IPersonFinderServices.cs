using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IPersonFinderServices
{
    void CreateSimplePerson(Guid personId, PersonType type);
    Guid? GetJuridicalOrPhysicalId(Guid personId, PersonType type);
    string GetJuridicalPersonMunicipalRegistration(Guid personId);
    Gender GetPersonGender(Guid personId, PersonType type);
}