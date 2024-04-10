using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IProprietyServices
{
    IEnumerable<ProprietyViewModel> View(Metadata meta, ProprietyParams @params = null);
    ProprietyViewModel View(Guid id);    
    ProprietyViewModel Insert(ProprietyInsertUpdateViewModel model);
    ProprietyViewModel Update(ProprietyInsertUpdateViewModel model, Guid id);
    void Delete(Guid id);
    ProprietyDashboardViewModel Dashboard();
    CsvResponseViewModel InsertCSV(CsvInsertViewModel fileBody);
    bool CibExist(string cib);
    void AddOwner(string personDocument, string proprietyCib);
    bool Exists(Guid id);
    IEnumerable<TaxPayerDeclarationDashBoardViewModel> ViewCARData();
    ProprietyCARDataViewModel ViewCARData(string car);
    IEnumerable<ShortProprietyViewModel> Select();
    Guid? GetIdByCib(string cib);
    bool IsOwner(Guid id, Guid? proprietyId);
    IEnumerable<SelectPersonViewModel> SelectProprietaries(Guid proprietyId);
    Dictionary<string, Propriety> GetIdsByCib(List<string> cibs);
    void UpdateMany(List<Propriety> entities);
    void UpdateProprietyAddress(Propriety entity, ProprietyAddressViewModel addressInfo, bool isFromImport = false);
}