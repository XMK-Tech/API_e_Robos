using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Domain.ViewModel
{
    public class MyProfileViewModel
    {
        public MyProfileViewModel(string document,
            Guid id,
            string name,
            string displayName,
            DateTime? date,
            string profilePicUrl,
            List<AddressViewModel> address,
            List<EmailViewModel> emails,
            List<PhoneViewModel> phone,
            List<SocialMediaViewModel> socialMedia,
            Gender gender,
            string detail,
            EmailViewModel email)
        {
            Document = document;
            Id = id;
            Name = name;
            DisplayName = displayName;
            Date = date;
            ProfilePicUrl = profilePicUrl;
            Address = address;
            Emails = emails;
            Phone = phone;
            SocialMedia = socialMedia;
            Gender = gender;
            Detail = detail;
            Email = email;
        }

        public string Document { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime? Date { get; set; }
        public string ProfilePicUrl { get; set; }
        public List<AddressViewModel> Address { get; set; }
        public List<EmailViewModel> Emails { get; set; }
        public List<PhoneViewModel> Phone { get; set; }
        public List<SocialMediaViewModel> SocialMedia { get; set; }
        public Gender Gender { get; set; }
        public string Detail { get; set; }
        public EmailViewModel Email { get; set; }

    }
    public class MyProfileResumViewModel
    {
        public MyProfileResumViewModel(Guid id, string profilePicUrl, string displayName, MyProfilePhysicalPersonViewModel physicalPerson)
        {
            Id = id;
            ProfilePicUrl = profilePicUrl;
            DisplayName = displayName;
            PhysicalPerson = physicalPerson;
        }

        public Guid Id { get; set; }
        public string ProfilePicUrl { get; set; }
        public string DisplayName { get; set; }
        public MyProfilePhysicalPersonViewModel PhysicalPerson { get; set; }


    }
    public class MyProfilePhysicalPersonViewModel
    {
        public MyProfilePhysicalPersonViewModel(Guid id, string username, string email, ProfileSearchViewModel profile, Gender gender, List<PermissionModel> permission)
        {
            Id = id;
            Username = username;
            Email = email;
            Profile = profile;
            Gender = gender;
            Permission = permission;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ProfileSearchViewModel Profile { get; set; }
        public Gender Gender { get; set; }
        public List<PermissionModel> Permission { get; set; }
    }
}
