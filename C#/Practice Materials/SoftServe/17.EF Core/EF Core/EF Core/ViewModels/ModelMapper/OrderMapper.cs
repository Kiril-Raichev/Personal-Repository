using DAL.Models;

namespace EF_Core.ViewModels.ModelMapper
{
    public class OrderMapper
    {
        public Order ModelToOrder(OrderCreateAndEditViewModel viewModel)
        {
            return new Order()
            {
                Id = viewModel.Id,
                OrderDate = viewModel.OrderDate,
                CustomerId = viewModel.CustomerId,
                SuperMarketId = viewModel.SuperMarketId
            };
        }
        public OrderCreateAndEditViewModel OrderToModel(Order order)
        {
            return new OrderCreateAndEditViewModel()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                SuperMarketId = order.SuperMarketId
            };
        }
    }
}
