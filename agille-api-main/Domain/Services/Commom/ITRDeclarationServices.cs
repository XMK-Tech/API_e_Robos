using System;
using System.Collections.Generic;
using System.Linq;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Services.Commom;

public class ITRDeclarationServices : IITRDeclarationServices
{
    private readonly ITaxProcedureServices _taxProcedureService;
    private readonly ITaxPayerDeclarationServices _taxPayerDeclarationServices;
    private readonly IBareLandValueServices _bareLandValueServices;
    private readonly IEntitiesServices _entitiesServices;
    public ITRDeclarationServices(ITaxProcedureServices taxProcedureService, ITaxPayerDeclarationServices taxPayerDeclarationServices, IBareLandValueServices bareLandValueServices, IEntitiesServices entitiesServices)
    {
        _taxProcedureService = taxProcedureService;
        _taxPayerDeclarationServices = taxPayerDeclarationServices;
        _bareLandValueServices = bareLandValueServices;
        _entitiesServices = entitiesServices;
    }

    public ITRDeclarationViewModel GetITRDeclaration(Guid procedureId) {
        var procedure = _taxProcedureService.View(procedureId);
        var propriety = procedure.Propriety;
        var declaration = _taxPayerDeclarationServices.GetDeclaration(procedure.IntimationYear, propriety.Id, propriety.CibNumber);
        var bareLandValues = _bareLandValueServices.GetByYear(procedure.IntimationYear);
        decimal aliquot = _entitiesServices.GetAliquot();
        
        var viewmodel = new ITRDeclarationViewModel()
        {
            Declarations = new List<ITRDeclarationEntryViewModel>()
            {
                new()
                {
                    LandValue = declaration.PermanentPreservationArea * bareLandValues.PreservationOfFaunaOrFlora,
                    Area = declaration.PermanentPreservationArea,
                    Description = "Area de Preservacao Permanente"
                },
                new()
                {
                    LandValue = declaration.LegalReserveArea * bareLandValues.PreservationOfFaunaOrFlora,
                    Area = declaration.LegalReserveArea,
                    Description = "Area de Reserva Legal"
                },
                new()
                {
                    LandValue = null,
                    Area = declaration.TaxableArea,
                    Description = "Area tributavel"
                },
                new()
                {
                    LandValue = declaration.AreaOccupiedWithWorks * bareLandValues.ForestryOrNaturalPasture,
                    Area = declaration.AreaOccupiedWithWorks,
                    Description = "Area Ocupada com Bendeitorias"
                },
                new()
                {
                    LandValue = null,
                    Area = declaration.UsableArea,
                    Description = "Area Aproveitavel"
                },
                new()
                {
                    LandValue = declaration.AreaWithReforestation * bareLandValues.ForestryOrNaturalPasture,
                    Area = declaration.AreaWithReforestation,
                    Description = "Area com Reflorestamento"
                },
                new()
                {
                    LandValue = null,
                    Area = declaration.AreaUsedInRuralActivity,
                    Description = "Area Utilizada na Atividade Rural"
                }
            }
        };

        viewmodel.TotalITRValue = viewmodel.Declarations.Where(e => e.LandValue != null).Select(i => i.LandValue.Value).Sum() * aliquot;
        viewmodel.Declarations.Add(new()
        {
            Area = declaration.Total,
            LandValue = viewmodel.TotalITRValue,
            Description = "Area total",
        });
        return viewmodel;
    }
}