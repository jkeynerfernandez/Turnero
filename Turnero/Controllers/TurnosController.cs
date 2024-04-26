using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Data;
using Turnero.Models;


namespace Turnero.Controllers{
    public class TurnosController : Controller{
        public readonly DataContext _context;

        public TurnosController(DataContext context){
            _context = context;

            

        }

        public async Task<IActionResult> Index(string tipo){

            
            return View(await _context.Turnos.Where(t=> t.Tipo==tipo).Take(10).ToListAsync());
        }

        public int  contar(string? tipo){ // nod está en uso 
            //esta funcion contará cuantos turnos hay en cola segun el tipo, tipo asignado por el modulo
            //cuando el usuario elege en que módulo trabajar 
            
            int cantidad =_context.Turnos.Count(m=> m.Tipo == tipo);
            return cantidad;

        }

        public IActionResult Atendiendo(int Id){
            var turno = _context.Turnos.FirstOrDefault(t => t.Id == Id);
            var numeroTurno = turno.Numero;
            var IdTurnito = turno.Id;
            var elTurno = turno.Tipo + numeroTurno.ToString();
            var puesto = HttpContext.Session.GetString("Puesto");
            var nuevoTv = new Tv(){
                TurnoId = elTurno,
                puesto = puesto,
                IdTurno = IdTurnito
            };
            _context.Tv.Add(nuevoTv);
            _context.SaveChanges();
            
            return RedirectToAction("Tv");
        }

        public async Task<IActionResult> Tv(){
            return View(await _context.Tv.ToListAsync());
        }
    }
}