using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel
{
    public class PhoneViewModel
    {
        public PhoneViewModel(PhoneType type, string number)
        {

            Number = number;
            Type = type;
            TypeDescription = type.GetDescription();
        }

        public string Number { get; set; }
        public PhoneType Type { get; set; }
        public string TypeDescription { get; set; }
    }
}
