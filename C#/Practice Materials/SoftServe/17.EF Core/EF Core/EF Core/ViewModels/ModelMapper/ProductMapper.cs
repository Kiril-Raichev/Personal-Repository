using DAL.Models;

namespace EF_Core.ViewModels.ModelMapper
{
    public class ProductMapper
    {
        public Product ModelToProduct(ProductCreateAndEditViewModel viewModel)
        {
            return new Product()
            {
                Id= viewModel.Id,
                Name = viewModel.Name,
                Price= viewModel.Price,
                 
            };
        }
        public ProductCreateAndEditViewModel ProductToModel(Product order)
        {
            return new ProductCreateAndEditViewModel()
            {
                Id = order.Id,
                Name= order.Name,
                Price= order.Price,
            };
        }
    }
}
