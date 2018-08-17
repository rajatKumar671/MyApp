using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Data;
using Microsoft.EntityFrameworkCore;
using Student.Domain;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult front()
        {
            return View();
        }
    }
}
