using Microsoft.Extensions.Configuration;

namespace AgilleApi.Domain.Services.Specialize
{
    public static class Password
    {
        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Validate(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static bool GetEncryptPasswordConfiguration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var result = configuration["EncryptPassword"];

            if (string.IsNullOrEmpty(result))
                return true;
            else if (result == "0")
                return false;
            else
                return true;
        }
    }
}
