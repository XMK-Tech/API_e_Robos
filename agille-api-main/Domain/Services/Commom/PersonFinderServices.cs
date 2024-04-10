using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class PersonFinderServices : IPersonFinderServices
{
    private readonly IJuridicalPersonRepository _juridicalPersonRepository;
    private readonly IPhysicalPersonRepository _physicalPersonRepository;

    public PersonFinderServices(IJuridicalPersonRepository juridicalPersonRepository, IPhysicalPersonRepository physicalPersonRepository)
    {
        _juridicalPersonRepository = juridicalPersonRepository;
        _physicalPersonRepository = physicalPersonRepository;
    }

    public Guid? GetJuridicalOrPhysicalId(Guid personId, PersonType type)
    {
        return type switch
        {
            PersonType.Juridical => _juridicalPersonRepository.Get(e => e.PersonId == personId).FirstOrDefault()?.Id,
            PersonType.Physical => _physicalPersonRepository.Get(e => e.PersonId == personId).FirstOrDefault()?.Id,
            _ => null
        };
    }

    public string GetJuridicalPersonMunicipalRegistration(Guid personId)
    {
        return _juridicalPersonRepository.Get(e => e.PersonId == personId).FirstOrDefault()?.MunicipalRegistration;
    }

    public Gender GetPersonGender(Guid personId, PersonType type)
    {
        var gender = type switch
        {
            PersonType.Physical => _physicalPersonRepository.Get(e => e.PersonId == personId).FirstOrDefault()?.Gender,
            _ => null
        };

        return gender ?? Gender.NotSet;
    }

    public void CreateSimplePerson(Guid personId, PersonType type)
    {
        if(type == PersonType.Juridical)
        {
            var entity = new JuridicalPersonBase()
            {
                PersonId = personId,
                Discriminator = JuridicalPersonServices.Discriminator,
            };

            _juridicalPersonRepository.Insert(entity);
        }
        else if(type == PersonType.Physical)
        {
            var entity = new PhysicalPersonBase()
            {
                PersonId = personId,
                Discriminator = PhysicalPersonServices.Discriminator,
            };

            _physicalPersonRepository.Insert(entity);
        }
    }
}