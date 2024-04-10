using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Domain.ViewModel
{
    public class TaxpayerViewModel
    {
        public TaxpayerViewModel() { }

        public TaxpayerViewModel(Guid id, UserInfoViewModel userInfo, JuridicalPersonViewModel companyInfo) 
        {
            Id = id;
            UserInfo = userInfo;
            CompanyInfo = companyInfo;
        }

        public Guid Id { get; set; }
        public UserInfoViewModel UserInfo { get; set; }
        public JuridicalPersonViewModel CompanyInfo { get; set; }
    }

    public class InsertTaxpayerViewModel
    {
        public Guid UserId { get; set; }
        public Guid JuridicalPersonId { get; set; }
    }
}
