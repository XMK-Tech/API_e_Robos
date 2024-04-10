using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Data.ContextDb
{
  public class PermissionsSeed
  {
    public static void Seed(Context context, Dictionary<string, string> groupsSystems)
    {
      
    }
    public static void AdministratorUserSeed(Context context)
    {
      if (context != null)
      {
        Profile profile = context.Profiles.FirstOrDefault(e => e.Name.Equals("Administrator"));
        if (profile == null)
        {
          Guid ownerProfile_id = Guid.NewGuid();

          profile = new Profile(
            "Admin",
            "Administrator",
            "Administrator",
            ownerProfile_id
          );

          profile.Id = ownerProfile_id;

          context.Profiles.Add(profile);
          context.SaveChanges();
        }

        PersonBase person = context.Persons.Where(e => e.Name.Equals("Administrator")).Include(e => e.EmailPersons).FirstOrDefault();
        if (person == null)
        {
          Guid ownerProfile_id = Guid.NewGuid();
          PhysicalPersonBase physicalPerson = new PhysicalPersonBase("Administrator", "", "", Gender.NotSet, null);
          var physicalPerson_person = new PersonBase("Administrator", "00000000000", "Administrator", DateTime.Now, PersonType.Physical, true, "");
          context.Persons.Add(physicalPerson_person);

          physicalPerson.PersonId = physicalPerson_person.Id;

          context.PhysicalPersons.Add(physicalPerson);
          context.SaveChanges();
          person = physicalPerson.Person;
        }

        Email email = context.Emails.Where(p => p.EmailPersons.Any(e => e.PersonId == person.Id)).Where(p => p.Value.Equals("yellowstech@gmail.com")).FirstOrDefault();
        if (email == null)
        {
          email = new Email("yellowstech@gmail.com");

          var emailPersons = new List<EmailPerson>() { new EmailPerson(email.Id, person.Id) };
          email.EmailPersons = emailPersons;

          context.Emails.Add(email);
          context.SaveChanges();
        }

        User user = context.Users.FirstOrDefault(e => e.Username.Equals("Administrator"));
        if (user == null)
        {
          user = new User();
          user.Status = true;
          user.ProfileId = profile.Id;
          user.Username = "Administrator";
          user.Password = "Administrator";
          user.PersonId = person.Id;
          user.CustomPermissions = (bool)true;
          user.EmailId = email.Id;

          context.Users.Add(user);
          context.SaveChanges();
        }

        List<Guid> permissionregistered = context.UserPermissions.Where(e => e.UserId == user.Id).Select(e => e.PermissionId).ToList();
        List<Guid> userPermissions = context.Permissions.Where(e => !permissionregistered.Contains(e.Id)).Select(e => e.Id).ToList();

        if (userPermissions.Any())
        {
          foreach (Guid p in userPermissions)
          {
            UserPermission userPermission = new UserPermission(user.Id, p);
            context.UserPermissions.Add(userPermission);
          }
          context.SaveChanges();
        }

        List<Guid> templatePermissionregistered = context.Template_profile_permissions.Where(e => e.ProfileId == profile.Id).Select(e => e.PermissionId).ToList();
        List<Guid> templatePermissions = context.Permissions.Where(e => !templatePermissionregistered.Contains(e.Id)).Select(e => e.Id).ToList();

        if (templatePermissions.Any())
        {
          foreach (Guid p in templatePermissions)
          {
            TemplateProfilePermissions templatePermission = new TemplateProfilePermissions(profile.Id, p);
            context.Template_profile_permissions.Add(templatePermission);
          }
          context.SaveChanges();
        }
      }
    }
    /// <summary>
    /// Gerar o relacionamento dos Modulos(SubSystem) e os PermissionsGroups
    /// Deve ser chamado apenos depois que as PermissionsGroups e Permissions já foram cadastradas no Sistema
    /// </summary>
    /// <param name="context"></param>
    public static void ModulesSeed(Context context)
    {
      
    }

    public static string FirstLetterUpAndRestDown(string phrase)
    {
      if (String.IsNullOrEmpty(phrase)) return null;
      phrase = phrase.Replace("-", " ");
      string[] palavras = phrase.Split(' ');

      string primeiraLetra = "";
      string restante = "";

      //Percorri a string com cada palavra
      for (int i = 0; i < palavras.Length; i++)
      {
        primeiraLetra = palavras[i].Substring(0, 1).ToString().ToUpper();
        restante = palavras[i].Substring(1, palavras[i].Length - 1).ToString().ToLower();
        //atribuo a posição da string a palavra com a primeira maiuscula e o restante minusculo
        palavras[i] = primeiraLetra + restante;
      }
      //atribuo a junção do array no label novamente

      phrase = String.Join(" ", palavras);

      return phrase;
    }
  }
}


