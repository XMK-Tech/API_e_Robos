using System;
using System.Collections.Generic;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System.Linq;
using Xunit;
using Moq;
using System.IO;

namespace Test;

public class ManualImportParserTest
{
    private Mock<ImportFileFetcher> _fetcher;
    private ManualImportParserV2 _parser;

    private static string GetFileContents() {
        return File.ReadAllText("input/invoices.csv");
    }
    public ManualImportParserTest() {
        Setup();
    }
    private void Setup()
    {
        _fetcher = new Mock<ImportFileFetcher>();
        _fetcher.Setup(x => x.GetFileContents(It.IsAny<Guid?>())).Returns(GetFileContents());
        _parser = new ManualImportParserV2(_fetcher.Object);
    }
    
    [Fact]
    public void ParseShouldReturnEntryWithRightValue()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(360, result.First().Value);
    }

    
    [Fact]
    public void ParseShouldReturnEntriesWithRightValues()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(new List<decimal> () {360m, 83.3m}, result.Select(x => x.Value).ToList());
    }

    [Fact]
    public void ParseShouldReturnEntriesWithRightDocuments()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(new List<string> () {"00967863000132", "00967863000132"}, result.Select(x => x.Document).ToList());
    }
}
