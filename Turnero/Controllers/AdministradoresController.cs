using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Data;
using Turnero.Models;

namespace Turnero.Controllers{
    public class AdministradoresController : Controller{
        public readonly DataContext _context;

        public AdministradoresController(DataContext context){
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }
    }
}