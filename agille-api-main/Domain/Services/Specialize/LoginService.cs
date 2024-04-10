using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AgilleApi.Domain.Services.Specialize
{
    public class LoginService : Notifications
    {
        public bool InvalidLogin { get; set; }
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly PermissionServices _permissionServices;
        private readonly MessageTemplateServices _messageTemplateServices;
        private readonly MessageServices _messageServices;
        private readonly DateTime ExpirationToken;

        public LoginService(IUserRepository userRepository,
                            IConfiguration config,
                            PermissionServices permissionServices,
                            MessageTemplateServices messageTemplateServices,
                            MessageServices messageServices)
        {
            ExpirationToken = DateTime.UtcNow.AddMinutes(120);
            _permissionServices = permissionServices;
            _userRepository = userRepository;
            _config = config;
            _messageTemplateServices = messageTemplateServices;
            _messageServices = messageServices;
        }
        public UserSignInViewModel Login(UserSignInParam model)
        {
            try
            {
                User user = _userRepository.Query()
                    .Where(e => (e.Username == model.Username || e.Email.Value == model.Username))
                    .FirstOrDefault();

                if(user == null)
                {
                    ValidationMessages.Add("Este usuário não existe!");
                    StatusCode = 404;
                    return null;
                }

                if(string.IsNullOrEmpty(model.Password))
                {
                    ValidationMessages.Add("The password cannot be null or empty!");
                    StatusCode = 404;
                    return null;
                }

                var passwordIsCorrect = Password.GetEncryptPasswordConfiguration() ? Password.Validate(model.Password, user.Password) : user.Password == model.Password;

                if (!passwordIsCorrect)
                {
                    ValidationMessages.Add("Senha incorreta!");
                    StatusCode = 404;
                    return null;
                }

                string token = GenerateJWT(user);

                List<string> permissions = new List<string>();
                var userPermissions = _permissionServices.ListToModel(user.Id);

                if (userPermissions == null) return null;

                permissions.AddRange(userPermissions.Select(x => x.Code).ToList());

                return new UserSignInViewModel(token, permissions);
            }
            catch (Exception ex)
            {
                return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void SetPassword(SetPasswordViewModel model)
        {
            try
            {
                User user = _userRepository.Get(e => e.SetPasswordToken.Replace("-", "") == model.SetPasswordToken.Replace("-", "")).FirstOrDefault();

                if (user == null)
                {
                    ValidationMessages.Add("Inválido. O token enviado não confere. Tente redefinir sua senha, caso não funcione, entre em contato com o Administrador do sistema.");
                    return;
                }

                user.SetPasswordToken = null;
                user.Password = model.Password;
                user.TokenPushNotifications = model.TokenPushNotifications;
                _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
            }
        }
        public void RecoverPassword(RecoverPasswordViewModel model)
        {
            try
            {
                User user = _userRepository.Query()
                    .Include(e => e.Email)
                    .AsNoTracking()
                    .Where(e => e.Email.Value == model.Email)
                    .FirstOrDefault();

                if (user == null)
                {
                    StatusCode = 404;
                    ValidationMessages.Add("User with this email not exists");
                    return;
                }
                Random rdn = new Random();
                int number1 = rdn.Next(1000, 2000);
                int number2 = rdn.Next(2000, 6000);

                string token = $"{number1}-{number2}";

                user.SetPasswordToken = token;
                _userRepository.Update(user);

                SendEmailWithToken(user);

            }
            catch (Exception ex)
            {
                ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
                return;
            }
        }
        private void SendEmailWithToken(User user)
        {
            var db = GetCS();

            MessageTemplateInsertUpdateViewModel messageTemplate = new MessageTemplateInsertUpdateViewModel();
            messageTemplate.Message_template_code = "recovery-password";
            messageTemplate.Send_to = user.Email.Value;

            messageTemplate.Dynamic_field_options_values.Add($"{db}.User", user.Id.ToString());
            messageTemplate.Dynamic_field_options_values.Add($"{db}.Person", user.PersonId.ToString());

            //messageTemplate.Dynamic_field_options_values.Add("sympapps.User", user.Id.ToString());
            //messageTemplate.Dynamic_field_options_values.Add("sympapps.Person", user.PersonId.ToString());

            //messageTemplate.Dynamic_field_options_values.Add("homologacao_sympapps.User", user.Id.ToString());
            //messageTemplate.Dynamic_field_options_values.Add("homologacao_sympapps.Person", user.PersonId.ToString());

            messageTemplate.Attributes_options_values.Add("[[description]]", DateTime.Now.ToShortDateString());

            var message = _messageTemplateServices.InsertMessegaQueue(messageTemplate);
            if (message == null)
            {
                StatusCode = 400;
                ValidationMessages.Add("Fail to make replace");
                return;
            }
        }
        private string GenerateJWT(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ApiSecret"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            List<PermissionViewModel> permissions = _permissionServices.List(user.Id);

            if (permissions != null)
            {
                foreach (PermissionViewModel permission in permissions)
                {
                    claims.Add(new Claim(ClaimTypes.Role, permission.Name));
                }
            }
            claims.Add(new Claim("user_id", user.Id.ToString()));

            JwtSecurityToken token = new JwtSecurityToken
                (
                    "Issuer",
                    "Issuer",
                    claims,
                    expires: ExpirationToken,
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GetCS()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            return configuration["DataBase"];
        }
    }
}
