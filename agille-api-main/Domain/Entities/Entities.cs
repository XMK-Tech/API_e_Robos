using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Entities;

public class Entities
{
    public Entities() 
    {
        Content = new Content()
        {
            ISS = new(),
            ITR = new(),
            DTE = new(),
        };
    }
    public Entities(string json)
        : this()
    {
        SetContent(json);
    }

    public string Name { get; set; }
    public string EntityImage { get; set; }
    public string Document { get; set; }

    public string FixedContentString { get; set; }
    public string ContentString { get => Content.ConvertToJson(); set => SetContent(value); }
    public Content Content { get; set; }
    public EntityAddress Address { get; set; }

    private void SetContent(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        if (Content == null)
            Content = new(json);
        else
            Content.LoadFromJson(json);
    }
}

[Serializable]
public class EntityAddress
{
    public EntityAddress() { }
    public EntityAddress(EntityAddressViewModel model)
    {
        Patch(model);
    }

    public string Street { get; set; } = "";
    public string District { get; set; } = "";
    public string Complement { get; set; } = "";
    public string Zipcode { get; set; } = "";
    public string Number { get; set; } = "";

    public AddressType Type { get; set; } = AddressType.Others;

    public Guid? CityId { get; set; }
    public string CityName { get; set; }

    public Guid? StateId { get; set; }
    public string StateName { get; set; }

    public void Patch(EntityAddressViewModel model) 
    {
        if (model == null)
            return;

        Street = Street.Patch(model.Street);
        District = District.Patch(model.District);
        Complement = Complement.Patch(model.Complement);
        Zipcode = Zipcode.Patch(model.Zipcode);
        Number = Number.Patch(model.Number);

        Type = model.Type ?? Type;
        CityId = model.CityId ?? CityId;
        StateId = model.StateId ?? StateId;
    }
}