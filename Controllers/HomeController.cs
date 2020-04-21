using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Diagnostics;
using www.Data;
using www.Models;

namespace www.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext _db;
        readonly IToastNotification _toastNotification;

        public HomeController(ApplicationDbContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.Time = DateTime.Now;
                _db.Messages.Add(message);
                _db.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Wiadomość wysłana");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddErrorToastMessage("Wiadomość nie wysłana");
            return View(message);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
