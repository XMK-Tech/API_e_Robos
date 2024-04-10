using System;

namespace AgilleApi.Domain.ViewModel
{
    public class ResultCreatePersonAgiprevViewModel
    {
        public ResultCreatePersonAgiprevViewModel(){}
        public ResultCreatePersonAgiprevViewModel(Guid personId)
        {
            PersonId = personId;
        }

        public Guid PersonId { get; set; }
    }
    public class OperatorViewModel
    {
        public Guid Id { get; set; }
        public string AgiPrevCode { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
