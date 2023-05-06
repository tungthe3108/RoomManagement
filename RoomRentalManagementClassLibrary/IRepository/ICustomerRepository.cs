using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.IRepository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetListCustomer();
        public Customer GetCustomerById(int id);
        public List<Customer> GetCustomerByRoomId(int id);
        public void DeleteCustomer(int id);
        public void UpdateCustomer(Customer customer);
        public string AddCustomer(Customer customer);
    }
}
