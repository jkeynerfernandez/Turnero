using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Data;


namespace Turnero.Controllers{
    public class TurnosController : Controller{
        public readonly DataContext _context;

        public TurnosController(DataContext context){
            _context = context;

            

        }

        public IActionResult Index(){
            return View();
        }

        public int  contar(string? tipo){
            
            int cantidad =_context.Turnos.Count(m=> m.Tipo == tipo);
            return cantidad;

        }
    }
}