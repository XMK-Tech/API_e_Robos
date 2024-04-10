using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(Guid personId, Guid profileId, string username, Guid emailId, bool customPermissions, string password = null)
        {
            ProfileId = profileId;
            Username = username;
            EmailId = emailId;
            PersonId = personId;
            CustomPermissions = customPermissions;
            Status = true;
            Password = password;
            SetPasswordToken = GenerateSetPasswordToken();
        }
        public ICollection<MessageQueue> MessageQueues { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Username { get; set; }
        private string _password { get; set; }
        public string Password {
            get {
                return this._password;
            }
            set
            {
                this._password = Services.Specialize.Password.GetEncryptPasswordConfiguration() ? Services.Specialize.Password.EncryptPassword(value) : value;
            }
        }
        public Guid EmailId { get; set; }
        public Email Email { get; set; }
        public Guid PersonId { get; set; }
        public PersonBase Person { get; set; }
        public string SetPasswordToken { get; set; }
        public bool CustomPermissions { get; set; }
        public bool Status { get; set; }
        public string TokenPushNotifications { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }


        private static string GenerateSetPasswordToken()
        {
            string caracters = "0123456789";
            string setPasswordToken = "";

            Random random = new Random();

            for (int c = 0; c < 8; c++)
            {
                if (c == 4)
                    setPasswordToken += "-";
                setPasswordToken += caracters.Substring(random.Next(0, caracters.Length - 1), 1);
            }

            return setPasswordToken;
        }
    }

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

            builder.HasOne(h => h.Profile)
              .WithMany(w => w.Users)
              .HasForeignKey(h => h.ProfileId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();

            builder.HasOne(h => h.Email)
              .WithMany(w => w.Users)
              .HasForeignKey(h => h.EmailId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();

            builder.HasOne(s => s.Person)
              .WithOne(ad => ad.User)
              .OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey<User>(ad => ad.PersonId);

            builder.Property(e => e.Username).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Password).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.SetPasswordToken).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.TokenPushNotifications).HasMaxLength(300).IsRequired(false);
        }
    }
}