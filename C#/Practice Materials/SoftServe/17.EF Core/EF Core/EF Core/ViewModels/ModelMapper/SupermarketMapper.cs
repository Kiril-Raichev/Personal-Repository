using DAL.Models;

namespace EF_Core.ViewModels.ModelMapper
{
    public class SupermarketMapper
    {
        public SuperMarket ModelToSupermarket(SupermarketCreateAndEditViewModel viewModel)
        {
            return new SuperMarket()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Address = viewModel.Address,
            };
        }
        public SupermarketCreateAndEditViewModel SupermarketToModel(SuperMarket supermarket)
        {
            return new SupermarketCreateAndEditViewModel()
            {
                Id = supermarket.Id,
                Name = supermarket.Name,
                Address = supermarket.Address,
            };
        }
    }
}
