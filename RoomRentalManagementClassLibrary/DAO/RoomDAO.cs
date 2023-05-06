using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.DAO
{
    public class RoomDAO
    {
        public static RoomDAO instance = null;
        public static readonly object instanceLock = new object();
        public static RoomDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Room> GetListRoom()
        {
            List<Room> list = new List<Room>();
            try
            {
                using var context = new RoomRetalManagementContext();
                list = context.Rooms.ToList().Select(x => new Room
                {
                    RoomId = x.RoomId,
                    RoomName = x.RoomName,
                    Floor = x.Floor,
                    Area = x.Area,
                    NumOfPerson = x.NumOfPerson,
                    NumOfLiving= x.NumOfLiving,
                    Price = x.Price
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Room GetRoomByID(int id)
        {
            Room room = new Room();
            try
            {
                using var context = new RoomRetalManagementContext();
                room = context.Rooms.SingleOrDefault(x => x.RoomId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Room is not valid!");
            }
            return room;
        }
        public void AddRoom(Room room)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                context.Rooms.Add(room);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteRoom(int id)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                Room room = GetRoomByID(id);
                List<Customer> customers = context.Customers.Where(x=> x.RoomId == id).ToList();
                context.Customers.RemoveRange(customers);
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateRoom(Room roomUpdate)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                context.Rooms.Update(roomUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

