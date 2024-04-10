using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IReportServices
{
    ReportResponseViewModel GenerateCSVReport(string[] headers, List<dynamic> objects);
    ReportResponseViewModel GeneratePDFReport(ReportViewModel report);
    ReportResponseViewModel GeneratePDFReport(string title, string[] headers, List<dynamic> objects, string imageUrl = null, DateTime? startingReference = null, DateTime? endingReference = null, string requestedBy = "", bool isLandscape = false);
    ReportResponseViewModel GenerateReport(ReportType type, string[] headers, List<dynamic> objects, string title = null, string imageUrl = null, DateTime? startingReference = null, DateTime? endingReference = null, string requestedBy = "", bool isLandscape = false);
    ReportResponseViewModel GenerateXLSXReport(string[] headers, List<dynamic> objects);
    ReportResponseViewModel GenerateXMLReport(string[] headers, List<dynamic> objects);
}