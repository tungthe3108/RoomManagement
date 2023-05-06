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
    public class RoomRepository : IRoomRepository
    {
        public void AddRoom(Room room) => RoomDAO.Instance.AddRoom(room);
        public void DeleteRoom(int id) => RoomDAO.Instance.DeleteRoom(id);

        public List<Room> GetListRoom() => RoomDAO.Instance.GetListRoom();

        public Room GetRoomById(int id) => RoomDAO.Instance.GetRoomByID(id);

        public void UpdateRoom(Room room) => RoomDAO.Instance.UpdateRoom(room);
    }
}
