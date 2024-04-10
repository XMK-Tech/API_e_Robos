using DinkToPdf;
using DinkToPdf.Contracts;
using System.Threading.Tasks;

namespace AgilleApi.API.Implemantation.Services
{
    // Classe resposnsável por carregar os arquivos necessários para o DinkToPD

    //public class GeneratePdf : IPdfGenerator
    //{
    //    private readonly IConverter _converter;
    //    private readonly IRazorPageRenderer _render;

    //    public GeneratePdf(
    //        IConverter converter,
    //        IRazorPageRenderer render
    //    )
    //    {
    //        _converter = converter;
    //        _render = render;

    //    }

    //    public async Task<byte[]> Generate(object data)
    //    {

    //        HtmlToPdfDocument doc = new HtmlToPdfDocument()
    //        {
    //            GlobalSettings = {
    //                            ColorMode = ColorMode.Color,
    //                            Orientation = Orientation.Portrait,
    //                            PaperSize = PaperKind.A4,
    //                    },
    //            Objects = {
    //                                    new ObjectSettings() {
    //                                            PagesCount = true,
    //                                            HtmlContent = await _render.RenderViewToStringAsync(
    //                                                    $"Resources/Pdf/PreventiveOrder.cshtml",
    //                                                    data),
    //                                            WebSettings = { DefaultEncoding = "utf-8" },
    //                                            HeaderSettings = { FontSize = 12, Right = "Página [page] de [toPage]",
    //                                                        Line = true,
    //                                                        Spacing = 2.812
    //                                            }
    //                                    }
    //                            }
    //        };

    //        byte[] pdf = _converter.Convert(doc);

    //        // return File(pdf, "application/pdf");
    //        return pdf;
    //    }
    //}
}
