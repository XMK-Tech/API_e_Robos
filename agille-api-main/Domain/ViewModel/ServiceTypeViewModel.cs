using AgilleApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.ViewModel;

public class ServiceTypeViewModel
{
    public ServiceTypeViewModel() { }
    public ServiceTypeViewModel(Guid id, string name, IEnumerable<ServiceTypeDescriptionViewModel> descriptions)
    {
        Id = id;
        Name = name;
        Descriptions = descriptions;
    }

    public ServiceTypeViewModel(ServiceType entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Code = entity.Code;
        Descriptions = entity.Descriptions?.Select(e => new ServiceTypeDescriptionViewModel(e)).ToList();         
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public IEnumerable<ServiceTypeDescriptionViewModel> Descriptions { get; set; }
}

public class ServiceTypeDescriptionViewModel
{
    public ServiceTypeDescriptionViewModel() { }
    public ServiceTypeDescriptionViewModel(Guid id, decimal? iSSRate, decimal? iSSAnnualValue, string description, string code)
    {
        Id = id;
        Description = description;
        Code = code;

        if (iSSRate.HasValue)
            ISSRate = Round(iSSRate.Value);

        if (iSSAnnualValue.HasValue)
            ISSAnnualValue = Round(iSSAnnualValue.Value);
    }
    public ServiceTypeDescriptionViewModel(ServiceTypeDescription entity)
        : this(entity.Id, entity.ISSRate, entity.ISSAnnualValue, entity.Description, entity.Code)
    { }

    public Guid Id { get; set; }
    public decimal? ISSRate { get; set; }
    public decimal? ISSAnnualValue { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }

    private static decimal Round(decimal number) => Math.Round(number, 2);
}

public class ServiceTypeInsertUpdateViewModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public IEnumerable<ServiceTypeDescriptionInsertUpdateViewModel> Descriptions { get; set; }
}

public class ServiceTypeDescriptionInsertUpdateViewModel
{
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal? ISSRate { get; set; }
    public decimal? ISSAnnualValue { get; set; }
}