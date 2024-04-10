using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ICardCrossingServices
{
    SimpleCardCrossingReportViewModel IntervalCreate(CardCrossingInsertIntervalViewModel interval);
    SimpleCardCrossingReportViewModel MonthCreate(CardCrossingMonthInsertViewModel model);
    CardCrossingViewModel View(Guid id);
    IEnumerable<CardCrossingViewModel> ViewAll(Metadata meta);
}