using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel
{
    public class ServerSelectViewModel
    {
        public ServerSelectViewModel(string descricao, int value)
        {
            Descricao = descricao;
            Value = value;
        }

        public string Descricao { get; set; }
        public int Value { get; set; }
    }
    public class ServerInsertUpdateViewModel
    {
        public string AgiPrevCode { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

        public DateTime AdmissionDate { get; set; }
        public string CTPSNumber { get; set; }
        public string CTPSSeries { get; set; }
        public string Registration { get; set; }
        public string PisPasepNumber { get; set; }
        public ServerCategory ServerCategory { get; set; }

        public PersonInsertUpdateViewModelAgiPrev ConvertToPersonViewModel()
        {
            return new PersonInsertUpdateViewModelAgiPrev(Name, Email, AgiPrevCode, Document);
        }
    }
    public class ServerViewModel
    {
        public Guid Id { get; set; }
        public string AgiPrevCode { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public DateTime AdmissionDate { get; set; }
        public string CTPSNumber { get; set; }
        public string CTPSSeries { get; set; }
        public string Registration { get; set; }
        public string PisPasepNumber { get; set; }
        public ServerCategory ServerCategory { get; set; }
    }
}
