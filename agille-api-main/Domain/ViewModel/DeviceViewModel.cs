using System;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{

    public class DeviceListViewModel
    {
        public Guid Id { get; set; }
        public Guid Uuid { get; set; }
        public Guid UserId { get; set; }
    }

    public class DeviceInsertViewModel
    {
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public Guid? Uuid { get; set; }
        [Required]
        public string OperationSystem { get; set; }
        [Required]
        public string OsVersion { get; set; }
        [Required]
        public Guid? UserId { get; set; }

        public bool FilledFields()
        {
            return (Platform == null || Model == null || Manufacturer == null || (Uuid == null || Uuid == Guid.Empty) || OperationSystem == null || OsVersion == null || (UserId == null || UserId == Guid.Empty));
        }
    }
    public class DeviceUpdateViewModel
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public Guid? Uuid { get; set; }
        [Required]
        public string OperationSystem { get; set; }
        [Required]
        public string OsVersion { get; set; }
        [Required]
        public Guid? UserId { get; set; }

        public bool FilledFields()
        {
            return ((Id == null || Id == Guid.Empty) || Platform == null || Model == null || Manufacturer == null || (Uuid == null || Uuid == Guid.Empty) || OperationSystem == null || OsVersion == null || (UserId == null || UserId == Guid.Empty));
        }
    }
}
