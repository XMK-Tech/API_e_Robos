using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Specialize.PDF.Implementations
{
    public class PDFGeneratorService : IPDFGenerator
    {
        private readonly IConverter _converter;
        private readonly IRazorPageRenderer _renderer;

        public PDFGeneratorService(
            IConverter converter,
            IRazorPageRenderer renderer
        )
        {
            _converter = converter;
            _renderer = renderer;
        }

        public byte[] Generate(string content) {
            return ConvertContent(null, content);
        }
        
        public async Task<byte[]> Generate(object data, string template, bool reverse = false, bool isLandscape = false)
        {
            string cssPath = $"/Resources/pdf/css/{template.ToLower()}.css";

            string content = await _renderer.RenderViewToStringAsync(
                                        $"/Resources/pdf/{template}.cshtml",
                                        data
                                    );
            return ConvertContent(cssPath, content, isLandscape);
        }

        public async Task<string> GenerateHtml(object data, string template)
        {
            return await _renderer.RenderViewToStringAsync(
                                        $"/Resources/pdf/{template}.cshtml",
                                        data
                                    );
        }

        private byte[] ConvertContent(string cssPath, string content, bool isLandscape = false)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = 
                {
                    ColorMode = ColorMode.Color,
                    Orientation = (isLandscape) ? Orientation.Landscape : Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = 
                {
                    new ObjectSettings() 
                    {
                        PagesCount = true,
                        HtmlContent = content,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8",
                            UserStyleSheet = cssPath,
                            LoadImages = true
                        },
                        HeaderSettings =
                        {
                            FontSize = 9,
                            //Right = "Página [page] de [toPage]",
                            Line = false,
                            Spacing = 2.812
                        },
                        FooterSettings =
                        {
                            Spacing = 20.000
                        }
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}
