using System;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
    public class EmailViewModel
    {
        public Guid Id { get; set; }
        //[Required]
        [DataType(DataType.EmailAddress)]
        public string Value { get; set; }
    }

}
