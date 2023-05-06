using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.IRepository
{
    public interface IRoomRepository
    {
        public List<Room> GetListRoom();
        public Room GetRoomById(int id);
        public void DeleteRoom(int id);
        public void UpdateRoom(Room room);
        public void AddRoom(Room room);
    }
}
