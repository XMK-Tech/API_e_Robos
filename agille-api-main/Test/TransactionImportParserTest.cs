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

public class TransactionImportParserTest
{
    private Mock<ImportFileFetcher> _fetcher;
    private TransactionImportParserV2 _parser;
    private static string GetFileContents()
    {
        return File.ReadAllText("input/transactions.txt");
    }

    public TransactionImportParserTest()
    {
        Setup();
    }

    private void Setup()
    {
        _fetcher = new Mock<ImportFileFetcher>();
        _fetcher.Setup(x => x.GetFileContents(It.IsAny<Guid?>())).Returns(GetFileContents());
        _parser = new TransactionImportParserV2(_fetcher.Object);
    }

    [Fact]
    public void ParseShouldReturnEntryWithRightValue()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(10070, result.First().Value);
    }

    [Fact]
    public void ParseShouldReturnEntryWithRightDate()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(new DateTime(2022, 01, 01), result.First().ReferenceDate);
    }

    [Fact]
    public void ParseShouldReturnEntryWithRightTypes()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        TransactionEntry[] transactionEntries = result.ToArray();
        Assert.Equal(TransactionEntryType.UNINFORMED, transactionEntries[0].TransactionType);
    }

    [Fact]
    public void ParseShouldReturnEntryWithRightDocument()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal("04884023000167", result.First().Document);
    }

    [Fact]
    public void ParseShouldReturnEntryWithRightOperatorDocument()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal("10440482000154", result.First().CardOperatorDocument);
    }

    [Fact]
    public void ParseShouldReturnEntriesWithRightValues()
    {
        var result = _parser.Parse(new ImportFile(ImportType.Transactions, ImportStatus.WaitingForDownload, false));
        Assert.Equal(new List<decimal>() { 10070, 2852, 4823, 60896.79m, 3723.5m, 51729.25m, 6020, 4291.1m }, result.Select(x => x.Value).ToList());
    }
}