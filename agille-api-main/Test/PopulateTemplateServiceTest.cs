using AgilleApi.Domain.Services.Specialize;
using System.Collections.Generic;
using Xunit;

namespace Test;

public class PopulateTemplateServiceTest
{
    private readonly Dictionary<string, string> Data = new Dictionary<string, string>();
    private readonly string Template;
    private readonly string ExpectedAnswer;

    public PopulateTemplateServiceTest()
    {
        Data.Add("@nome", "Populate");
        Data.Add("@sobrenome", "Serv");
        Data.Add("@cargo", "Desenvolvedor");
        Data.Add("@idade", "18");
        Data.Add("@cidade", "Belo horizonte");
        Data.Add("@pais", "Brasil");

        Template = "Olá @nome @sobrenome, você é um @cargo, tem @idade anos, e mora na @cidade(@pais).";
        ExpectedAnswer = "Olá Populate Serv, você é um Desenvolvedor, tem 18 anos, e mora na Belo horizonte(Brasil).";
    }

    [Fact]
    public void TestPopulateTemplate()
    {
        var response = PopulateTemplateService.Populate(Template, Data);
        Assert.Equal(ExpectedAnswer, response);
    }
}