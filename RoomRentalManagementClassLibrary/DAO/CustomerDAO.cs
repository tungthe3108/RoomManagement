using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.DAO
{
    public class CustomerDAO
    {
        public static CustomerDAO instance = null;
        public static readonly object instanceLock = new object();
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Customer> GetListCustomer()
        {
            List<Customer> list = new List<Customer>();
            try
            {
                using var context = new RoomRetalManagementContext();
                list = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Customer GetCustomerByID(int id)
        {
            Customer customer = new Customer();
            try
            {
                using var context = new RoomRetalManagementContext();
                customer = context.Customers.SingleOrDefault(x => x.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Customer is not valid!");
            }
            return customer;
        }
        public List<Customer> GetCustomerByRoomID(int id)
        {
            List<Customer> list = new List<Customer>();
            try
            {
                using var context = new RoomRetalManagementContext();
                list = context.Customers.Where(x => x.RoomId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Customer is not valid!");
            }
            return list;
        }
        public string AddCustomer(Customer customer)
        {
            string addStatus = "";
            try
            {
                using var context = new RoomRetalManagementContext();
                Room room = context.Rooms.SingleOrDefault(x => x.RoomId == customer.RoomId);
                if(room.NumOfPerson == room.NumOfLiving) {
                    addStatus = "Phòng đã đủ người, không thể thêm";
                }
                else
                {
                    room.NumOfLiving = room.NumOfLiving + 1;
                    context.Customers.Add(customer);
                    context.Rooms.Update(room);
                    context.SaveChanges();
                    addStatus = "Thêm khách hàng thành công";
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return addStatus;
        }
        public void DeleteCustomer(int id)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                Customer customer = GetCustomerByID(id);
                Room room = context.Rooms.SingleOrDefault(x => x.RoomId == customer.RoomId);
                room.NumOfLiving = room.NumOfLiving - 1;
                context.Rooms.Update(room);
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateCustomer(Customer customerUpdate)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                Customer customer = GetCustomerByID(customerUpdate.CustomerId);
                Room room1 = context.Rooms.SingleOrDefault(x => x.RoomId == customer.RoomId);
                room1.NumOfLiving = room1.NumOfLiving - 1;
                Room room2 = context.Rooms.SingleOrDefault(x => x.RoomId == customerUpdate.RoomId);
                room2.NumOfLiving = room2.NumOfLiving + 1;
                context.Rooms.Update(room1);
                context.Rooms.Update(room2);
                context.Customers.Update(customerUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
