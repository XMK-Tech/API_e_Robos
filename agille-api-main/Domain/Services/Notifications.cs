using AgilleApi.Domain.Interfaces.Shared;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services
{
    public class Notifications : INotifications
    {
        public List<string> ValidationMessages { get; set; } = new List<string>();
        public int StatusCode { get; set; } = 0;
        public bool Valid { get { return (ValidationMessages.Count == 0); } }
    }
}
