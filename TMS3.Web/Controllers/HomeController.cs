using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMS3.Library.Entities;
using TMS3.Web.ViewModels;
using TMS3.Library.Interfaces;

namespace TMS3.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Library.Entities.Task> _personRepository;

        public HomeController(IRepository<Library.Entities.Task> personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            var tasks = _personRepository.GetAll();//.OrderBy(r => r.TaskID).ToList();
            return View(tasks.Entities.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
