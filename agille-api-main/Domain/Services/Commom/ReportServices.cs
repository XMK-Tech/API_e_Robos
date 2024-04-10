using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace AgilleApi.Domain.Services.Commom;

public class ReportServices : IReportServices
{
    private readonly IPDFGenerator _pDFGenerator;

    public static readonly char CSVBreaker = ';';

    public ReportServices(IPDFGenerator pDFGenerator)
    {
        _pDFGenerator = pDFGenerator;
    }

    public ReportResponseViewModel GenerateReport(ReportType type, string[] headers, List<dynamic> objects, string title = null, string imageUrl = null, DateTime? startingReference = null, DateTime? endingReference = null, string requestedBy = "", bool isLandscape = false)
    {
        ThrowExceptionIfIntervalIsInvalid(startingReference, endingReference);
        return type switch
        {
            ReportType.PDF => GeneratePDFReport(title, headers, objects, imageUrl, startingReference, endingReference, requestedBy, isLandscape),
            ReportType.CSV => GenerateCSVReport(headers, objects),
            ReportType.XLSX => GenerateXLSXReport(headers, objects),
            ReportType.XML => GenerateXMLReport(headers, objects),
            _ => GenerateCSVReport(headers, objects)
        };
    }

    public ReportResponseViewModel GeneratePDFReport(ReportViewModel model)
    {
        ThrowExceptionIfIntervalIsInvalid(model.StartingReference, model.EndingReference);
        model.ObjectFields = model?.Objects?.Select(GetDynamicFields).ToList() ?? new();

        var bytes = _pDFGenerator.Generate(model, "GenericReport", isLandscape: model.IsLandscape).Result;

        return new()
        {
            Content = bytes,
            ContentType = "application/pdf",
            Title = "Report.pdf"
        };
    }
    public ReportResponseViewModel GeneratePDFReport(string title, string[] headers, List<dynamic> objects, string image = null, DateTime? startingReference = null, DateTime? endingReference = null, string requestedBy = "", bool isLandscape = false)
    {
        var model = new ReportViewModel()
        {
            Title = title,
            Image = image,
            RequestedBy = requestedBy,

            Headers = headers,
            ObjectFields = objects.Select(GetDynamicFields).ToList(),

            StartingReference = startingReference,
            EndingReference = endingReference,
            IsLandscape = isLandscape,
        };

        return GeneratePDFReport(model);
    }

    public ReportResponseViewModel GenerateXMLReport(string[] headers, List<dynamic> objects)
    {
        var dt = CreatedDataTable(headers, objects);
        var ds = new DataSet("RequestedReport")
        {
            Locale = dt.Locale,
            Tables =
            {
                dt
            }
        };

        var bytes = Encoding.UTF8.GetBytes(ds.GetXml());

        return new()
        {
            Content = bytes,
            ContentType = "application/xml",
            Title = "Report.xml"
        };
    }

    public ReportResponseViewModel GenerateXLSXReport(string[] headers, List<dynamic> objects)
    {
        var dt = CreatedDataTable(headers, objects);
        var wb = new XLWorkbook();

        wb.Worksheets.Add(dt, "Report");

        var workbookBytes = Array.Empty<byte>();
        using (var ms = new MemoryStream())
        {
            wb.SaveAs(ms);
            workbookBytes = ms.ToArray();
        }

        return new()
        {
            Content = workbookBytes,
            ContentType = "application/xlsx",
            Title = "Report.xlsx"
        };
    }

    public ReportResponseViewModel GenerateCSVReport(string[] headers, List<dynamic> objects)
    {
        var lines = new List<string>
        {
            string.Join(CSVBreaker, headers)
        };

        lines.AddRange(objects.Select(ConvertDynamicToCsvLine));
        var bytes = Encoding.UTF8.GetBytes(string.Join("\n", lines));

        return new()
        {
            Content = bytes,
            ContentType = "text/csv",
            Title = "Report.csv"
        };
    }

    private DataTable CreatedDataTable(string[] headers, List<dynamic> objects)
    {
        DataTable dt = new("Data")
        {
            Locale = System.Threading.Thread.CurrentThread.CurrentCulture
        };

        foreach (var column in headers)
            dt.Columns.Add(column);

        objects.ForEach(obj =>
        {
            ConvertDynamicToDataTableRow(obj, dt);
        });

        return dt;
    }

    private static void ConvertDynamicToDataTableRow(dynamic data, DataTable dt)
    {
        var row = dt.NewRow();

        List<string> fields = GetDynamicFields(data);
        List<string> headers = row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

        for (int i = 0; i < headers.Count; i++)
            row.SetField(headers[i], fields[i]);

        dt.Rows.Add(row);
    }

    private static string ConvertDynamicToCsvLine(dynamic data)
    {
        List<string> lineData = GetDynamicFields(data);
        var linie = new StringBuilder();

        lineData.ForEach(item =>
        {
            if (linie.Length > 0)
                linie.Append(CSVBreaker);

            linie.Append(item);
        });

        return linie.ToString();
    }

    private static List<string> GetDynamicFields(dynamic data)
    {
        var fields = ((Type)data.GetType()).GetRuntimeFields();
        var values = new List<string>();

        foreach (var field in fields)
        {
            var value = field.GetValue(data);

            string final;
            if (value is DateTime date)
                final = date.ToString("dd/MM/yyyy HH:mm");
            else
                final = value?.ToString() ?? string.Empty;

            values.Add(final);
        }

        return values;
    }
    private static void ThrowExceptionIfIntervalIsInvalid(DateTime? startingReference = null, DateTime? endingReference = null)
    {
        if (startingReference.HasValue && endingReference.HasValue)
        {
            if (startingReference > endingReference)
                throw new BadRequestException("Invalid reference.");
        }
    }
}