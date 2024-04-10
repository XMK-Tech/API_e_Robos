using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Specialize.PDF.Interfaces
{
    public interface IPDFGenerator
    {
        public Task<byte[]> Generate(object data, string template, bool reverse = false, bool isLandscape = false);
        public byte[] Generate(string content);
        Task<string> GenerateHtml(object data, string template);
    }
}
