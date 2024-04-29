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

            
            return View(await _context.Turnos.Where(t=>  (t.Tipo=="PRF"|| t.Tipo==tipo) &&(t.Estado ==1)  ).Take(10).ToListAsync());
        }

        public IActionResult EditTurno( Turno turno){

           var turnoActual = _context.Turnos.FirstOrDefault(t => t.Id == turno.Id);
            if (turnoActual != null)
            {
                turnoActual.Estado = turno.Estado; 
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Administradores");


        }

         public async Task<IActionResult> Screen(){
            return View(await _context.Turnos.ToListAsync());
        }

 
        //agregar turno a Historial y mostrar en pantalla
        // public IActionResult Create(string Tipo, int Numero, string Modulo){
        //      Console.WriteLine("Create action called");
        //     var historialTurno = new HistorialTurno
        //     {
        //        Tipo = Tipo,
        //        Numero = Numero,
        //        Modulo = Modulo
        //     };

        //     _context.HistorialTurnos.Add(historialTurno);
        //     _context.SaveChanges();

        //     return RedirectToAction("Index");
        // }
       

        //fin de agregar y mostrar historial


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
            return View(await _context.Turnos.Where(t=>  (t.Estado ==2)  ).Take(5).ToListAsync());
        }
    }
}