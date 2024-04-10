using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel {

    public abstract class BaseDataCrossingViewModel {
        public DateTime StartingReference {get;set;}
        public DateTime EndingReference {get;set;}
    }
    public class DataCrossingInsertUpdateViewModel: BaseDataCrossingViewModel
    {
    }

    public class DataCrossingViewModel: BaseDataCrossingViewModel
    {
        public Guid Id {get; set;}
        public DataCrossingStatus Status { get; set; }
        public Guid? ResponsibleId {get;set;}
        public string ResponsibleName { get;  set; }
        public int DivergencyCount {get;set;}
        public bool HasInvalidDivergences { get; set; }
    }

    public class DataCrossingEntryViewModel
    {
        public Guid Id {get;set;}
        public string CompanyDocument { get; set; }
        public Guid? CompanyId { get; set;}
        public decimal Difference { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime ReferenceDate { get; set; }
        public bool IsCompanyRegistered {get;set;}
        public bool IsInvalid { get; set; }
    }

    public class DivergencysDataViewModel
    {
        public DivergencysDataViewModel() { }

        public DivergencysDataViewModel(DateTime startReference, DateTime endingReference, int total, List<DivergencyViewModel> data)
        {
            StartReference = startReference;
            EndingReference = endingReference;
            Total = total;
            Data = data;
        }
        public DateTime StartReference { get; set; }
        public DateTime EndingReference { get; set; }
        public int Total { get; set; }
        public List<DivergencyViewModel> Data;
    }

    public class DivergencyViewModel
    {
        public DivergencyViewModel() { }
        public DivergencyViewModel(int divergencyCount, string monthName, string year, int monthId)
        {
            DivergencyCount = divergencyCount;
            MonthName = monthName;
            Year = year;
            MonthId = monthId;
        }

        public int DivergencyCount { get; set; }
        public string MonthName { get; set; }
        public string Year { get; set; }
        public int MonthId { get; set; }
    }

    public class UserInfoViewModel 
    {
        public Guid UserId {get;set;}
        public string Fullname {get;set;}
        public string Email {get;set;}
        public string Document { get; set; }
    }
}