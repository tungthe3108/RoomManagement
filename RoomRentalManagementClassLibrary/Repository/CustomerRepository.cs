using RoomRentalManagementClassLibrary.DAO;
using RoomRentalManagementClassLibrary.IRepository;
using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public string AddCustomer(Customer customer) => CustomerDAO.Instance.AddCustomer(customer);

        public void DeleteCustomer(int id) => CustomerDAO.Instance.DeleteCustomer(id);

        public Customer GetCustomerById(int id) => CustomerDAO.Instance.GetCustomerByID(id);

        public List<Customer> GetCustomerByRoomId(int id) => CustomerDAO.Instance.GetCustomerByRoomID(id);

        public List<Customer> GetListCustomer() => CustomerDAO.Instance.GetListCustomer();

        public void UpdateCustomer(Customer customer) => CustomerDAO.Instance.UpdateCustomer(customer);
    }
}
