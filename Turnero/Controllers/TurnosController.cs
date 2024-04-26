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

         public async Task<IActionResult> Screen(){
            return View(await _context.Turnos.ToListAsync());
        }

 

        public int  contar(string? tipo){
            //esta funcion contará cuantos turnos hay en cola segun el tipo, tipo asignado por el modulo
            //cuando el usuario elege en que módulo trabajar 
            
            int cantidad =_context.Turnos.Count(m=> m.Tipo == tipo);
            return cantidad;

        }
    }
}