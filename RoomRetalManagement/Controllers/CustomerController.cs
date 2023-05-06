using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using X.PagedList;

namespace RoomRetalManagementWebapp.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerRepository custRepos = new();
        public RoomRepository roomRepos = new();
        // GET: CustomerController
        public ActionResult List()
        {
            ViewBag.GenderList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
            };
            List <Customer> customers = new List<Customer>();
            var cus = custRepos.GetListCustomer().ToList();
            var room = roomRepos.GetListRoom().ToList();
            var query = (from c in cus
                         join r in room on c.RoomId equals r.RoomId
                         select new
                         {
                             CustomerId = c.CustomerId,
                             RoomName = r.RoomName,
                             RoomId = r.RoomId,
                             Name = c.Name,
                             Sex = c.Sex,
                             Dob = c.Dob.ToString("dd/MM/yyyy"),
                             Phone = c.Phone,
                             Email = c.Email,
                             Address = c.Address
                         }).ToList();
            ViewBag.ListCust = query.ToList();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult List(int? page,
        //    string? CustomerId,
        //    string? RoomId,
        //    string? Name,
        //    string? Gender,
        //    string? Dob,
        //    string? Phone,
        //    string? Email,
        //    string? Address)
        //{
        //    List<Customer> customers = new List<Customer>();
        //    var cus = custRepos.GetListCustomer().ToList();
        //    var room = roomRepos.GetListRoom().ToList();
        //    var query = (from c in cus
        //                 join r in room on c.RoomId equals r.RoomId
        //                 select new
        //                 {
        //                     CustomerId = c.CustomerId,
        //                     RoomName = r.RoomName,
        //                     RoomId = r.RoomId,
        //                     Name = c.Name,
        //                     Sex = c.Sex,
        //                     Dob = c.Dob.ToString("dd/MM/yyyy"),
        //                     Phone = c.Phone,
        //                     Email = c.Email,
        //                     Address = c.Address
        //                 });
        //    if (!string.IsNullOrEmpty(CustomerId.Trim()))
        //    {
        //        query = query.Where(x => x.CustomerId == int.Parse(CustomerId.Trim()));
        //    };
        //    if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    }; if (!string.IsNullOrEmpty(CustomerId))
        //    {

        //    };
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    ViewBag.ListCust = query.ToList().ToPagedList(pageNumber, pageSize);
        //    return View();
        //}


        // GET: CustomerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = custRepos.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            var items = roomRepos.GetListRoom().ToList().Select(x => new SelectListItem
            {
                Value = x.RoomId.ToString(),
                Text = x.RoomName
            });
            ViewBag.GenderList =new List<SelectListItem>()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
            };
            ViewBag.Rooms = items;
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            var items = roomRepos.GetListRoom().ToList().Select(x => new SelectListItem
            {
                Value = x.RoomId.ToString(),
                Text = x.RoomName
            });
            ViewBag.GenderList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
            };
            ViewBag.Rooms = items;
            try
            {
                if (ModelState.IsValid)
                {
                    custRepos.AddCustomer(customer);
                }
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int? id)
        {
            var items = roomRepos.GetListRoom().ToList().Select(x => new SelectListItem
            {
                Value = x.RoomId.ToString(),
                Text = x.RoomName
            });
            ViewBag.Rooms = items;
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = custRepos.GetCustomerById(id.Value);
            customer.Sex = customer.Sex.Trim();
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Customer customer)
        {
            var items = roomRepos.GetListRoom().ToList().Select(x => new SelectListItem
            {
                Value = x.RoomId.ToString(),
                Text = x.RoomName
            });
            ViewBag.GenderList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
            };
            ViewBag.Rooms = items;
            try
            {
                if (ModelState.IsValid)
                {
                    custRepos.UpdateCustomer(customer);
                }
                return RedirectToAction(nameof(List));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(customer);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = custRepos.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.CustName = customer.Name;
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int custId = int.Parse(Request.Form["CustomerId"]);
            try
            {
                custRepos.DeleteCustomer(custId);
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
