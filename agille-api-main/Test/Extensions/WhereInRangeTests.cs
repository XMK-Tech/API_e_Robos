using AgilleApi.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Extensions;

public class WhereInRangeTests
{
    private readonly List<Item> entities;
    
    public WhereInRangeTests()
    {
        entities = new()
        {
            new Item { Id = 1, Date = new DateTime(2021, 1, 1), Value = 150 },
            new Item { Id = 2, Date = new DateTime(2021, 2, 1), Value = 160 },
            new Item { Id = 3, Date = new DateTime(2021, 3, 1), Value = 170 },
            new Item { Id = 4, Date = new DateTime(2021, 4, 1), Value = 180 },
            new Item { Id = 5, Date = new DateTime(2021, 5, 1), Value = 190 },
            new Item { Id = 6, Date = new DateTime(2021, 6, 1), Value = 200 },
            new Item { Id = 7, Date = new DateTime(2021, 7, 1), Value = 210 },
            new Item { Id = 8, Date = new DateTime(2021, 8, 1), Value = 220 },
            new Item { Id = 9, Date = new DateTime(2021, 9, 1), Value = 230 },
            new Item { Id = 10, Date = new DateTime(2021, 10, 1), Value = 240 },
            new Item { Id = 11, Date = new DateTime(2021, 11, 1), Value = 250 },
            new Item { Id = 12, Date = new DateTime(2021, 12, 1), Value = 260 },
        };
    }

    [Fact]
    public void Should_Filter_DateTime()
    {
        var startingReference = new DateTime(2021, 8, 1);
        var endingReference = new DateTime(2021, 11, 1);

        var expectedEntities = entities
                                .Where(e => e.Date >= startingReference && e.Date <= endingReference)
                                .Select(e => e.Id)
                                .ToList();

        var response = entities.AsQueryable().WhereInRange(startingReference, endingReference, e => e.Date);

        Assert.All(response, res => expectedEntities.Contains(res.Id));
    }

    [Fact]
    public void Should_Filter_Decimal()
    {
        decimal startingReference = 160;
        decimal endingReference = 220;

        var expectedEntities = entities
                                .Where(e => e.Value >= startingReference && e.Value <= endingReference)
                                .Select(e => e.Id)
                                .ToList();

        var response = entities.AsQueryable().WhereInRange(startingReference, endingReference, e => e.Value);

        Assert.All(response, res => expectedEntities.Contains(res.Id));
    }

    private class Item
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}