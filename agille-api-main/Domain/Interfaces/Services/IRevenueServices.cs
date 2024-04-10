using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IRevenueServices
{
    IEnumerable<RevenueViewModel> List(Metadata meta, RevenueParams @params);
    RevenueViewModel View(Guid id);
    FilterSumViewModel GetFilterSum(RevenueParams @params);
    void Insert(RevenueInsertUpdateViewModel model);
    void Update(Guid id, RevenueInsertUpdateViewModel model);
    IQueryable<Revenue> GetQueryForYear(string year);
    IQueryable<Revenue> GetQueryForCompetence(string year, string month);
    void Delete(Guid id);
    ReportResponseViewModel GeneratePDFReport(Metadata meta, RevenueParams @params);
    ReportResponseViewModel GenerateCSVReport(Metadata meta, RevenueParams @params);
    void ImportFromCrawler(AgiprevImportParams @params);
}