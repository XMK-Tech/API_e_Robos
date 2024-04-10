using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface INoticeTemplateServices
    {
        public NoticeTemplate GetById(Guid id);
        List<string> GetFields(Guid id, bool allFields = false);
    }
}