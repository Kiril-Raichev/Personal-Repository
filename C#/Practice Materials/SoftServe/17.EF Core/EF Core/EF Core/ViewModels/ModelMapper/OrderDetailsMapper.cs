using DAL.Models;

namespace EF_Core.ViewModels.ModelMapper
{
    public class OrderDetailsMapper
    {
        public OrderDetail ModelToOrderDetails(OrderDetailCreateAndEditViewModel viewModel)
        {
            return new OrderDetail()
            {
                Id = viewModel.Id,
                ProductId = viewModel.ProductId,
                OrderId = viewModel.OrderId,
                Quantity = viewModel.Quantity
            };
        }
        public OrderDetailCreateAndEditViewModel OrderDetailsToModel(OrderDetail orderDetail)
        {
            return new OrderDetailCreateAndEditViewModel()
            {
                Id = orderDetail.Id,
                ProductId = orderDetail.ProductId,
                OrderId = orderDetail.OrderId,
                Quantity = orderDetail.Quantity
            };
        }
    }
}
