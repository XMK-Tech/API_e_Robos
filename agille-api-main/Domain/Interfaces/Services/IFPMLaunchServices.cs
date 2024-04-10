using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IFPMLaunchServices
{
    IEnumerable<FPMLaunchViewModel> List(Metadata meta, FPMLaunchParams @params);
    FPMLaunchViewModel View(Guid id);
    IQueryable<FPMLaunch> GetQueryForCompetence(string year, string month);
    void ImportFromCrawler(AgiprevImportParams @params);
}