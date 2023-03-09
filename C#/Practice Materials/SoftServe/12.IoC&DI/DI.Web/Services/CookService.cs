using DI.Web.Services.Interfaces;
namespace DI.Web.Services
{
    public class CookService : ICookService
    {
        private readonly IOvenService OvenService = new OvenService();

        public CookService(IOvenService cookwareOvenService)
        {
            this.OvenService = cookwareOvenService;
        }
        public string Cooking()
        {
            return this.OvenService.Cook();
        }
    }
}
