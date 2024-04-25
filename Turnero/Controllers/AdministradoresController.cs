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

        public async Task<IActionResult> Index(){
            ViewBag.Nombre= HttpContext.Session.GetString("Nombre");
            return View(await _context.Administradores.ToListAsync());
        }

        
    }
}