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
            //variables que contendrán la cantidad de turnos por cada tipo 
            var cantidadSC = _context.Turnos.Count(m => m.Tipo == "SC");
            var cantidadPF = _context.Turnos.Count(m => m.Tipo == "PF");
            var cantidadAM = _context.Turnos.Count(m => m.Tipo == "AM");
            var cantidadIG = _context.Turnos.Count(m => m.Tipo == "IG");

            ViewBag.CantidadSC = cantidadSC;
            ViewBag.CantidadPF = cantidadPF;
            ViewBag.CantidadAM = cantidadAM;
            ViewBag.CantidadIG = cantidadIG;

            //fin del conteo :)

            
            return View(await _context.Turnos.Where(t=>  t.Tipo=="PRF"|| t.Tipo==tipo ).Take(10).ToListAsync());
        }
        //agregar turno a Historial y mostrar en pantalla
        public IActionResult Create(string Tipo, int Numero, string Modulo){
             Console.WriteLine("Create action called");
            var historialTurno = new HistorialTurno
            {
               Tipo = Tipo,
               Numero = Numero,
               Modulo = Modulo
            };

            _context.HistorialTurnos.Add(historialTurno);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Screen(int id){
            return View(await _context.Turnos.ToListAsync());
        }

        //fin de agregar y mostrar historial


        public int  contar(string? tipo){ // nod está en uso 
            //esta funcion contará cuantos turnos hay en cola segun el tipo, tipo asignado por el modulo
            //cuando el usuario elege en que módulo trabajar 
            
            int cantidad =_context.Turnos.Count(m=> m.Tipo == tipo);
            return cantidad;

        }
    }
}