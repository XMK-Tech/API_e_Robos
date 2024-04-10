using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ICollectionServices
{
    void AttachFile(Guid collectionId, CollectionAttachmentInsertUpdateViewModel model);
    IEnumerable<CollectionViewModel> List(Metadata meta, CollectionParams @params);
    CollectionViewModel View(Guid id);
    FilterSumViewModel GetFilterSum(CollectionParams @params);
    void Insert(CollectionInsertUpdateViewModel viewModel);
    void Update(CollectionInsertUpdateViewModel viewModel, Guid id);
    IQueryable<Collection> GetQueryForCompetence(string year, string month);
    void Delete(Guid id);
    ReportResponseViewModel GeneratePDFReport(Metadata meta, CollectionParams @params);
    ReportResponseViewModel GenerateCSVReport(Metadata meta, CollectionParams @params);
    void ImportFromCrawler(AgiprevImportParams @params);
}