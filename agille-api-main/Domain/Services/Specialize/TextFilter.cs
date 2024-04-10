using System.Globalization;
using System.Text;

namespace AgilleApi.Domain.Services.Specialize
{
    public static class TextFilter
    {
        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            char[] arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            string content = sbReturn.ToString();
            return content;
        }
    }
}