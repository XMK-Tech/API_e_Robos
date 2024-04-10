using BaseSystem.Data.ContextDb;
using BaseSystem.Domain.Entities;
using BaseSystem.Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseSystem.Data.Repository.InsertDatas
{
  public class Datas
  {
    private readonly Context _con;

    public Datas(Context con)
    {
      _con = con;
    }
    private void AddOrModify<T>(T entity, Guid key) where T : class, IEntity // Implements MyKey 
    {
      if (!_con.Set<T>().Any(e => e.id == key))
      {
        _con.Entry(entity).State = EntityState.Added;
        _con.SaveChanges();
      }
    }
    public void InsertDatas()
    {
      var system = new Domain.Entities.System(name: "SytemPermission", description: "System do PermissionGroup");
      system.id = new Guid("1d00a071-3431-4bd4-866c-20f62c184446");

      var companyPermissionGroup = new PermissionGroup { Code = "1", Name = "COMPANY", Description = "Um grupo de funcionalidades relacionados à companhia.", System_id = system.id };
      var profilePermissionGroup = new PermissionGroup { Code = "2", Name = "PROFILE", Description = "Um grupo de funcionalidades relacionados ao perfil.", System_id = system.id };
      var userPermissionGroup = new PermissionGroup { Code = "3", Name = "USER", Description = "Um grupo de funcionalidades relacionados ao usuário.", System_id = system.id };
      var contactPermissionGroup = new PermissionGroup { Code = "4", Name = "CONTACT", Description = "Um grupo de funcionalidades relacionados ao contato.", System_id = system.id };
      var departmentPermissionGroup = new PermissionGroup { Code = "5", Name = "DEPARTMENT", Description = "Um grupo de funcionalidades relacionados ao departamento.", System_id = system.id };
      companyPermissionGroup.id = new Guid("000201c1-61b3-430f-8215-46cb64916996");
      profilePermissionGroup.id = new Guid("705fd9a7-9f00-4627-b91d-3893ff04798d");
      userPermissionGroup.id = new Guid("15eb8e15-f30d-4317-a27e-b034a7619df9");
      contactPermissionGroup.id = new Guid("8eec9eef-a284-4985-97cb-ef511d0954c3");
      departmentPermissionGroup.id = new Guid("b83119a2-b036-46f0-8361-d26fa8dda23d");



      var permissions = new List<Permission>
            {
                //Company
                new Permission{id = new Guid("d6677b2b-3add-4d76-b658-edd035e4a4d6"), Code = "yt-company-list", Name = "Listar Companhias", Description = "Permissão para visualizar uma lista de companhias.", Owner_permission_id = new Guid("d6677b2b-3add-4d76-b658-edd035e4a4d6"), Permission_group_id = companyPermissionGroup.id },
                new Permission{id = new Guid("8ac9a360-0d87-4c3d-8a61-93de335dae11"), Code = "yt-company-view", Name = "Visualizar Companhia", Description = "Permissão para visualizar detalhes de uma companhia.", Owner_permission_id = new Guid("d6677b2b-3add-4d76-b658-edd035e4a4d6"), Permission_group_id = companyPermissionGroup.id},
                new Permission{id = new Guid("47ca8158-063a-4545-8c84-e2685dc3b392"), Code = "yt-company-add", Name = "Incluir Companhia", Description = "Permissão para incluir companhia.", Owner_permission_id = new Guid("d6677b2b-3add-4d76-b658-edd035e4a4d6"),  Permission_group_id = companyPermissionGroup.id},
                new Permission{id = new Guid("37c4563c-6279-402a-b6fb-06b077f9514a"), Code = "yt-company-edit", Name = "Editar Companhia", Description = "Permissão para editar companhia.", Owner_permission_id = new Guid("8ac9a360-0d87-4c3d-8a61-93de335dae11"),  Permission_group_id = companyPermissionGroup.id},
                new Permission{id = new Guid("c2482722-bc93-49dc-80cb-4d3fb45e66f7"), Code = "yt-company-delete", Name = "Excluir Companhia", Description = "Permissão para excluir companhia.", Owner_permission_id = new Guid("d6677b2b-3add-4d76-b658-edd035e4a4d6"),  Permission_group_id = companyPermissionGroup.id},

                //Profile
                new Permission{id = new Guid("8dd35644-dfd1-4fe6-8b7a-addabfe84c9b"), Code = "yt-profile-list", Name = "Listar Perfis", Description = "Permissão para visualizar uma lista de perfis.", Owner_permission_id = new Guid("8dd35644-dfd1-4fe6-8b7a-addabfe84c9b"),  Permission_group_id = profilePermissionGroup.id},
                new Permission{id = new Guid("ad206d91-adcf-4fb6-9965-f83d8a82b01d"), Code = "yt-profile-view", Name = "Visualizar Perfil", Description = "Permissão para visualizar detalhes de um perfil.", Owner_permission_id = new Guid("8dd35644-dfd1-4fe6-8b7a-addabfe84c9b"),  Permission_group_id = profilePermissionGroup.id},
                new Permission{id = new Guid("28291754-3e13-4292-ac32-5dbb463d785e"), Code = "yt-profile-add", Name = "Incluir Perfil", Description = "Permissão para incluir perfil.", Owner_permission_id = new Guid("8dd35644-dfd1-4fe6-8b7a-addabfe84c9b"),  Permission_group_id = profilePermissionGroup.id},
                new Permission{id = new Guid("12e252c1-9656-4f11-9853-ce49189a56e9"), Code = "yt-profile-edit", Name = "Editar Perfil", Description = "Permissão para editar perfil.", Owner_permission_id = new Guid("ad206d91-adcf-4fb6-9965-f83d8a82b01d"),  Permission_group_id = profilePermissionGroup.id},
                new Permission{id = new Guid("6b4dfedc-e883-4279-b99d-2e829d18ccd2"), Code = "yt-profile-delete", Name = "Excluir Perfil", Description = "Permissão para excluir perfil.", Owner_permission_id = new Guid("8dd35644-dfd1-4fe6-8b7a-addabfe84c9b"),  Permission_group_id = profilePermissionGroup.id},
                
                //USER
                new Permission{id = new Guid("33668d2e-3088-4620-9cdf-df0d4f0da432"), Code = "yt-user-list", Name = "Listar Usuários", Description = "Permissão para visualizar uma lista de usuários.", Owner_permission_id = new Guid("33668d2e-3088-4620-9cdf-df0d4f0da432"),  Permission_group_id = userPermissionGroup.id},
                new Permission{id = new Guid("c7f5914c-06a7-40ca-b9af-a5a59805a791"), Code = "yt-user-view", Name = "Visualizar Usuário", Description = "Permissão para visualizar detalhes de um usuário.", Owner_permission_id = new Guid("33668d2e-3088-4620-9cdf-df0d4f0da432"),  Permission_group_id = userPermissionGroup.id},
                new Permission{id = new Guid("9d57d306-99e0-4a8d-8794-59e11977a7c0"), Code = "yt-user-add", Name = "Incluir Usuário", Description = "Permissão para incluir usuário.", Owner_permission_id = new Guid("33668d2e-3088-4620-9cdf-df0d4f0da432"),  Permission_group_id = userPermissionGroup.id},
                new Permission{id = new Guid("8b81c2ec-78f9-4e6a-a4dd-0d36cfc2087f"), Code = "yt-user-edit", Name = "Editar Usuário", Description = "Permissão para editar usuário.", Owner_permission_id = new Guid("c7f5914c-06a7-40ca-b9af-a5a59805a791"),  Permission_group_id = userPermissionGroup.id},
                new Permission{id = new Guid("810a07d9-8b43-44cd-8c3a-c6251d904ff6"), Code = "yt-user-delete", Name = "Excluir Usuário", Description = "Permissão para excluir usuário.", Owner_permission_id = new Guid("33668d2e-3088-4620-9cdf-df0d4f0da432"),  Permission_group_id = userPermissionGroup.id},

                //contact
                new Permission{id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"), Code = "yt-contact-list", Name = "Listar Contatos", Description = "Permissão para visualizar uma lista de contatos.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("b0d96405-cba9-4310-b7f2-9d1a9c8325c2"), Code = "yt-contact-view", Name = "Visualizar Contato", Description = "Permissão para visualizar detalhes de um contato.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("e31f019f-2510-4737-bd47-d7e91c1a5545"), Code = "yt-contact-add", Name = "Incluir Contato", Description = "Permissão para incluir contato.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("c811b907-c5b4-4c26-bcda-c7bce40242b7"), Code = "yt-contact-edit", Name = "Editar Contato", Description = "Permissão para editar contato.", Owner_permission_id = new Guid("b0d96405-cba9-4310-b7f2-9d1a9c8325c2"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("daf83e77-79f8-4943-903d-ed44a2ae6173"), Code = "yt-contact-delete", Name = "Excluir Contato", Description = "Permissão para excluir contato.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("0766943f-bfe8-460b-9361-aedb84d6e574"), Code = "yt-contact-employee-add", Name = "Incluir Dados de Funcionário", Description = "Permissão para incluir dados adicionais referentes ao funcionário.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("4544ddfa-de08-452d-92b4-b2e3f7e2bb14"), Code = "yt-contact-employee-edit", Name = "Editar Dados de Funcionário", Description = "Permissão para editar dados adicionais referentes ao funcionário.", Owner_permission_id = new Guid("b0d96405-cba9-4310-b7f2-9d1a9c8325c2"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("5eb68ced-cb29-4172-a456-6ae75aa46be1"), Code = "yt-contact-client-add", Name = "Incluir Dados de Cliente", Description = "Permissão para incluir dados adicionais referentes ao cliente.", Owner_permission_id = new Guid("20a2df51-2f11-410c-894e-73dd1914e87f"),  Permission_group_id = contactPermissionGroup.id},
                new Permission{id = new Guid("0c68440a-26c0-491e-983e-c59dca601c24"), Code = "yt-contact-client-edit", Name = "Editar Dados de Cliente", Description = "Permissão para editar dados adicionais referentes ao cliente.", Owner_permission_id = new Guid("b0d96405-cba9-4310-b7f2-9d1a9c8325c2"),  Permission_group_id = contactPermissionGroup.id},

                //DEPARTMENT
                new Permission{id = new Guid("0f69488e-b115-49a6-ba41-1b2f492efe1a"), Code = "yt-department-list", Name = "Listar Departamentos", Description = "Permissão para visualizar uma lista de departamentos.", Owner_permission_id = new Guid("0f69488e-b115-49a6-ba41-1b2f492efe1a"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("d7fb563f-4d3f-4b2d-8a12-8c7848c73e22"), Code = "yt-department-view", Name = "Visualizar Departamento", Description = "Permissão para visualizar detalhes de um departamento.", Owner_permission_id = new Guid("0f69488e-b115-49a6-ba41-1b2f492efe1a"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("a42fc1ad-92c2-496f-b4c4-691176032305"), Code = "yt-department-add", Name = "Incluir Departamento", Description = "Permissão para incluir departamento.", Owner_permission_id = new Guid("0f69488e-b115-49a6-ba41-1b2f492efe1a"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("5200381c-0058-47da-8dec-75865ea846e3"), Code = "yt-department-edit", Name = "Editar Departamento", Description = "Permissão para editar departamento.", Owner_permission_id = new Guid("d7fb563f-4d3f-4b2d-8a12-8c7848c73e22"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("b8ed3e7f-64e1-4de2-b26b-24b27cdf48da"), Code = "yt-department-delete", Name = "Excluir Departamento", Description = "Permissão para excluir departamento.", Owner_permission_id = new Guid("0f69488e-b115-49a6-ba41-1b2f492efe1a"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("e6cb7003-404c-419d-9a62-89a4b1e34528"), Code = "yt-department-list", Name = "Listar Departamentos", Description = "Permissão para visualizar uma lista de departamentos.", Owner_permission_id = new Guid("e6cb7003-404c-419d-9a62-89a4b1e34528"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("4f328a92-68ce-4631-9d91-3085bca9aeed"), Code = "yt-department-view", Name = "Visualizar Departamento", Description = "Permissão para visualizar detalhes de um departamento.", Owner_permission_id = new Guid("e6cb7003-404c-419d-9a62-89a4b1e34528"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("72ed225b-bc62-40cd-8b2f-a6c8049697e2"), Code = "yt-department-add", Name = "Incluir Departamento", Description = "Permissão para incluir departamento.", Owner_permission_id = new Guid("e6cb7003-404c-419d-9a62-89a4b1e34528"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("cc89708c-a1f0-45cc-8083-8e4ac11fa117"), Code = "yt-department-edit", Name = "Editar Departamento", Description = "Permissão para editar departamento.", Owner_permission_id = new Guid("4f328a92-68ce-4631-9d91-3085bca9aeed"),  Permission_group_id = departmentPermissionGroup.id},
                new Permission{id = new Guid("27029f21-0291-4ff9-ae77-f66b05d52260"), Code = "yt-department-delete", Name = "Excluir Departamento", Description = "Permissão para excluir departamento.", Owner_permission_id = new Guid("e6cb7003-404c-419d-9a62-89a4b1e34528"),  Permission_group_id = departmentPermissionGroup.id},

            };

      var adminProfile = new Profile(code: "P0", name: "Admin", description: "Nunca exibido", owner_profile_id: new Guid("7f893c04-5a19-4692-9627-c9d11cbb9515"));
      adminProfile.id = new Guid("7f893c04-5a19-4692-9627-c9d11cbb9515");

      var template_profile_permissions = new List<Template_profile_permissions>
            {
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("37C4563C-6279-402A-B6FB-06B077F9514A"))
                        {id = new Guid("a480fb5d-f573-436a-a00a-806df4ed8158")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("8B81C2EC-78F9-4E6A-A4DD-0D36CFC2087F"))
                        {id = new Guid("93aea74e-d649-4ca7-973b-202a3c3d2396")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("0F69488E-B115-49A6-BA41-1B2F492EFE1A"))
                        {id = new Guid("1fe0ce35-260a-4080-a1b9-b526fa46a3f8")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("B8ED3E7F-64E1-4DE2-B26B-24B27CDF48DA"))
                        {id = new Guid("3a9367f8-96ca-421f-9ab8-2f0480a8f01c")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("6B4DFEDC-E883-4279-B99D-2E829D18CCD2"))
                        {id = new Guid("33d2fef1-62ad-4339-941b-d8a0e083fc07")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("4F328A92-68CE-4631-9D91-3085BCA9AEED"))
                        {id = new Guid("cccb3d21-9975-4021-ad96-fdaf025ab225")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("C2482722-BC93-49DC-80CB-4D3FB45E66F7"))
                        {id = new Guid("e1fe5846-544c-4259-a3f9-19a36ce6eefd")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("9D57D306-99E0-4A8D-8794-59E11977A7C0"))
                        {id = new Guid("6843175e-8bd5-42b7-8589-b6af5ef0c2f2")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("28291754-3E13-4292-AC32-5DBB463D785E"))
                        {id = new Guid("24839cb1-6c9e-4660-8560-6936841e868f")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("A42FC1AD-92C2-496F-B4C4-691176032305"))
                        {id = new Guid("96f64842-bc20-4bdd-a834-2650e3be0c30")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("5EB68CED-CB29-4172-A456-6AE75AA46BE1"))
                        {id = new Guid("6742280b-efe2-4d90-8de8-436a1e9fbcea")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("20A2DF51-2F11-410C-894E-73DD1914E87F"))
                        {id = new Guid("b687f1a0-c012-4d5d-bdb0-aa58be38fd53")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("5200381C-0058-47DA-8DEC-75865EA846E3"))
                        { id = new Guid("347e4afb-2bf1-44ac-b9e7-f568ffcfa989")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("E6CB7003-404C-419D-9A62-89A4B1E34528"))
                        { id = new Guid("3457370b-b76e-4d06-ba2f-27d5bd396237")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("D7FB563F-4D3F-4B2D-8A12-8C7848C73E22"))
                        { id = new Guid("c4453b2c-2ccc-4e15-984a-d2e7deb647d8")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("CC89708C-A1F0-45CC-8083-8E4AC11FA117"))
                        { id = new Guid("e52050b2-3f3d-4e6d-bfeb-2dcc35264add")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("8AC9A360-0D87-4C3D-8A61-93DE335DAE11"))
                        { id = new Guid("48ac18f6-65c4-4074-9f7e-4d19b678e10e")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("B0D96405-CBA9-4310-B7F2-9D1A9C8325C2"))
                        { id = new Guid("7e78455f-b894-4b28-a7ea-f590ab49e52e")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("C7F5914C-06A7-40CA-B9AF-A5A59805A791"))
                        { id = new Guid("94062ff1-61cf-46b9-8143-5503f2c5b04b")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("72ED225B-BC62-40CD-8B2F-A6C8049697E2"))
                        { id = new Guid("8387e074-25f9-4e9b-812b-febf139f7c1b")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("8DD35644-DFD1-4FE6-8B7A-ADDABFE84C9B"))
                        { id = new Guid("71dedbdb-772b-4dbc-9f03-38db03d77316")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("0766943F-BFE8-460B-9361-AEDB84D6E574"))
                        { id = new Guid("970e2e81-906f-4a1f-93bd-d2749a3a81e4")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("4544DDFA-DE08-452D-92B4-B2E3F7E2BB14"))
                        { id = new Guid("bdea717a-01d1-4e0b-a9fa-ee7ba7a8f42b")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("0C68440A-26C0-491E-983E-C59DCA601C24"))
                        { id = new Guid("be59b058-5f30-4a2f-a007-e1919d731d0e")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("810A07D9-8B43-44CD-8C3A-C6251D904FF6"))
                        { id = new Guid("40149c44-7c01-4b27-9735-672599c1df01")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("C811B907-C5B4-4C26-BCDA-C7BCE40242B7"))
                        { id = new Guid("f8b951a4-a817-42df-be70-dfdaad67daf6")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("12E252C1-9656-4F11-9853-CE49189A56E9"))
                        { id = new Guid("43ffec76-c9ef-424b-bb7a-d3525032b0ae")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("E31F019F-2510-4737-BD47-D7E91C1A5545"))
                        { id = new Guid("efc4d9a5-db3a-4294-a5f7-d8cb90ad3c14")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("33668D2E-3088-4620-9CDF-DF0D4F0DA432"))
                        { id = new Guid("395102ba-ac75-483f-b01e-57c52fad8862")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("47CA8158-063A-4545-8C84-E2685DC3B392"))
                        { id = new Guid("0741ce88-b292-4472-925c-f6ff46353db8")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("DAF83E77-79F8-4943-903D-ED44A2AE6173"))
                        { id = new Guid("cedc4c15-d90a-44ba-a254-d84b9fa55b98")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("D6677B2B-3ADD-4D76-B658-EDD035E4A4D6"))
                        { id = new Guid("492254c7-6132-4149-a44b-7f8faf5d42f6")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("27029F21-0291-4FF9-AE77-F66B05D52260"))
                        { id = new Guid("aff6a741-c118-4343-aec5-78dfc79dc4e4")},
                    new Template_profile_permissions(profileId: new Guid("7F893C04-5A19-4692-9627-C9D11CBB9515"), permissionId: new Guid("AD206D91-ADCF-4FB6-9965-F83D8A82B01D"))
                        { id = new Guid("5640d053-3be6-4077-972a-f4025da42032")},
            };


      AddOrModify<Domain.Entities.System>(system, system.id);
      AddOrModify<PermissionGroup>(companyPermissionGroup, companyPermissionGroup.id);
      AddOrModify<PermissionGroup>(profilePermissionGroup, profilePermissionGroup.id);
      AddOrModify<PermissionGroup>(userPermissionGroup, userPermissionGroup.id);
      AddOrModify<PermissionGroup>(contactPermissionGroup, contactPermissionGroup.id);
      AddOrModify<PermissionGroup>(departmentPermissionGroup, departmentPermissionGroup.id);

      foreach (var permission in permissions)
        AddOrModify<Permission>(permission, permission.id);

      AddOrModify<Profile>(adminProfile, adminProfile.id);

      foreach (var template_profile_permission in template_profile_permissions)
        AddOrModify<Template_profile_permissions>(template_profile_permission, template_profile_permission.id);
    }
  }
}
