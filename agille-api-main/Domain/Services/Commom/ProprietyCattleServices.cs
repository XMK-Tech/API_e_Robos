using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class ProprietyCattleServices : IProprietyCattleServices
{
    private readonly IProprietyCattleRepository _repository;
    private readonly ITaxProcedureServices _taxProcedureServices;

    public ProprietyCattleServices(IProprietyCattleRepository repository, ITaxProcedureServices taxProcedureServices)
    {
        _repository = repository;
        _taxProcedureServices = taxProcedureServices;
    }

    public IEnumerable<ProprietyCattleViewModel> View(Guid procedureId)
    {
        return _repository
                .Query()
                .Where(e => e.ProcedureId == procedureId)
                .OrderBy(e => e.Month)
                .Select(e => new ProprietyCattleViewModel(e.Month, e.Cattle, e.Buffalos, e.Equine, e.Sheep, e.Goats, e.Procedure.IntimationYear, e.ProcedureId))
                .ToList();
    }

    public void Upsert(CattleManyViewModel entities)
    {
        var validation = ValidateModel(entities);

        entities.Models.ForEach(e =>
        {
            if (Exist(e.Reference, entities.ProcedureId.Value))
                Update(e, entities.ProcedureId.Value);
            else
                Insert(e, entities.ProcedureId.Value);
        });

        if (validation.messages.Any())
            throw new BadRequestException(validation.messages);
    }

    private void Insert(ProprietyCattleInsertUpdateViewModel model, Guid procedureId)
    {
        var entity = ConvertToEntity(model, procedureId);
        _repository.Insert(entity);
    }

    private void Update(ProprietyCattleInsertUpdateViewModel model, Guid procedureId)
    {
        var entity = Get(model.Reference, procedureId);
        if (entity == null)
            return;

        SetCattleData(model, entity);

        _repository.Update(entity);
    }

    private ProprietyCattle Get(int reference, Guid procedureId)
    {
        return _repository
                .Query()
                .Where(e => e.ProcedureId == procedureId)
                .Where(e => e.Month == reference)
                .FirstOrDefault();
    }

    private bool Exist(int reference, Guid procedureId)
    {
        return _repository
                .Query()
                .Where(e => e.ProcedureId == procedureId)
                .Where(e => e.Month == reference)
                .Any();
    }

    private static ProprietyCattle ConvertToEntity(ProprietyCattleInsertUpdateViewModel viewModel, Guid proprietyId)
    {
        var entity = new ProprietyCattle(proprietyId, viewModel.Reference);
        SetCattleData(viewModel, entity);

        return entity;
    }

    private static void SetCattleData(ProprietyCattleInsertUpdateViewModel viewModel, ProprietyCattle entity)
    {
        entity.Cattle = viewModel.Cattle;
        entity.Buffalos = viewModel.Buffalos;
        entity.Equine = viewModel.Equine;
        entity.Sheep = viewModel.Sheep;
        entity.Goats = viewModel.Goats;
    }

    private (List<ProprietyCattleInsertUpdateViewModel>, List<string> messages) ValidateModel(CattleManyViewModel models)
    {
        if (models == null)
            throw new BadRequestException("Modelos inválidos.");

        if (!_taxProcedureServices.Exist(models.ProcedureId))
            throw new NotFoundException($"Procedimento({models.ProcedureId}) não encontrada.");

        var messages = new List<string>();
        var valid = new List<ProprietyCattleInsertUpdateViewModel>();

        models.Models.ForEach(e =>
        {
            try
            {
                ValidateModel(e);
                valid.Add(e);
            }
            catch (DomainException ex)
            {
                messages.Add(ex.Message);
            }
        });

        if (messages.Any())
            throw new BadRequestException(messages);

        return (valid, messages);
    }

    private static void ValidateModel(ProprietyCattleInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        if (model.Cattle < 0)
            messages.Add($"(Mês - {model.Reference}): A quantidade de bovinos deve ser maior ou igual a zero.");

        if (model.Goats < 0)
            messages.Add($"(Mês - {model.Reference}): A quantidade de caprinos deve ser maior ou igual a zero.");

        if (model.Equine < 0)
            messages.Add($"(Mês - {model.Reference}): A quantidade de equinos deve ser maior ou igual a zero.");

        if (model.Buffalos < 0)
            messages.Add($"(Mês - {model.Reference}): A quantidade de bufalinos deve ser maior ou igual a zero.");

        if (model.Sheep < 0)
            messages.Add($"(Mês - {model.Reference}): A quantidade de ovinos deve ser maior ou igual a zero.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }
}