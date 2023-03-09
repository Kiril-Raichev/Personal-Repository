using System;
using DI.Web.Services.Interfaces;

namespace DI.Web.Services
{
    public class OvenService : IOvenService
    {
        public string Cook()
        {
            return $"Cooking with oven." + GetHashCode();
        }
    }
}
