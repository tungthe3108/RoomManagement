using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RoomRetalManagementWebapp.Controllers
{
    public class RoomController : Controller
    {
        public readonly RoomRepository roomRepos = new();
        // GET: RoomController
        public ActionResult List()
        {
            ViewBag.FloorList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "1" },
                new SelectListItem { Value = "2", Text = "2" },
                new SelectListItem { Value = "3", Text = "3" },
                new SelectListItem { Value = "4", Text = "4" },
                new SelectListItem { Value = "5", Text = "5" },
            };
            ViewBag.NumOfPersonList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "2", Text = "2" },
                new SelectListItem { Value = "3", Text = "3" },
                new SelectListItem { Value = "4", Text = "4" },
                new SelectListItem { Value = "5", Text = "5" },
            };
            ViewBag.AreaList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "20", Text = "20" },
                new SelectListItem { Value = "25", Text = "25" },
                new SelectListItem { Value = "30", Text = "30" },
            };
            ViewBag.PriceList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "2000000", Text = "2,000,000" },
                new SelectListItem { Value = "2500000", Text = "2,500,000" },
                new SelectListItem { Value = "3000000", Text = "3,000,000" },
            };
            var rooms = roomRepos.GetListRoom().Select(x => new
            {
                RoomId = x.RoomId,
                RoomName = x.RoomName,
                Floor = x.Floor,
                NumOfPerson = x.NumOfPerson,
                NumOfLiving = x.NumOfLiving,
                Area = x.Area,
                Price = x.Price,
                Status = (x.NumOfLiving == 0) ? "Trống" : (x.NumOfPerson == x.NumOfLiving) ? "Đã đủ" : "Chưa đủ"
            }).ToList();
            ViewBag.rooms = rooms.ToList();
            return View();
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room room = roomRepos.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            room.NumOfLiving = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    roomRepos.AddRoom(room);
                }
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room room = roomRepos.GetRoomById(id.Value);
            if(room.Price != null)
            {
                room.Price = Convert.ToInt32(room.Price);
            }
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roomRepos.UpdateRoom(room);
                }
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(room);
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room room = roomRepos.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.RoomName = room.RoomName;
            return View(room);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int roomId = int.Parse(Request.Form["RoomId"]);
            try
            {
                roomRepos.DeleteRoom(roomId);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
