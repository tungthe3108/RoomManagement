using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;

namespace RoomRetalManagementWebapp.Controllers
{
    public class AccountController : Controller
    {
        public readonly AccountRepository accRepos = new();
        // GET: AccountController
        public ActionResult List()
        {
            var account = accRepos.ListAccount();
            return View(account);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            
            account.Role = "Nhân viên";
            account.Status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    accRepos.AddAccount(account);
                }
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Account account = accRepos.GetAccountById(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    accRepos.UpdateAccount(account);
                }
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(account);
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Account account = accRepos.GetAccountById(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            ViewBag.account = account.Username;
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int custId = int.Parse(Request.Form["Id"]);
            try
            {
                accRepos.DeleteAccount(custId);
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
