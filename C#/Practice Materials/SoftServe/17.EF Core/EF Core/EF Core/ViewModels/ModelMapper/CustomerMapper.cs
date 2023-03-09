using DAL.Models;
using EF_Core.ViewModels;
namespace EF_Core.ViewModels.ModelMapper
{
    public class CustomerMapper
    {
        public Customer ModelToCustomer(CustomerCreateAndEditViewModel viewModel)
        {
            return new Customer()
            {
                Id = viewModel.Id,
                FName = viewModel.FName,
                LName = viewModel.LName,
                Address = viewModel.Address,
                Discount = viewModel.Discount
            };
        }
        public CustomerCreateAndEditViewModel CustomerToModel(Customer customer)
        {
            return new CustomerCreateAndEditViewModel()
            {
                Id = customer.Id,
                FName = customer.FName,
                LName = customer.LName,
                Address = customer.Address,
                Discount = customer.Discount
            };
        }
    }
}
