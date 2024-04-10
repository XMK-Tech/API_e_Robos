using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface IJuridicalPersonServices
    {
        JuridicalPersonBase GetByDocument(string document);
        Dictionary<string, bool> DocumentsExists(IEnumerable<string> documents);
        Dictionary<string, Guid?> GetIdsByDocument(IEnumerable<string> documents);
        JuridicalPersonBase Create(JuridicalPersonInsertUpdateViewModel model);
        JuridicalPersonViewModel View(Guid id);
    }
}
