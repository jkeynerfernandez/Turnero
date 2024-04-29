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
            //variable de inicio de sesion para saludar a el usuario logueado
            ViewBag.Nombre= HttpContext.Session.GetString("Nombre");


            //variables que contendrán la cantidad de turnos por cada tipo 
            var cantidadSC = _context.Turnos.Count(m => m.Tipo == "SC" && m.Estado == 1);
            var cantidadPF = _context.Turnos.Count(m => m.Tipo == "PF" && m.Estado == 1);
            var cantidadAM = _context.Turnos.Count(m => m.Tipo == "AM" && m.Estado == 1);
            var cantidadIG = _context.Turnos.Count(m => m.Tipo == "IG" && m.Estado == 1);

            ViewBag.CantidadSC = cantidadSC;
            ViewBag.CantidadPF = cantidadPF;
            ViewBag.CantidadAM = cantidadAM;
            ViewBag.CantidadIG = cantidadIG;

            //fin del conteo :)

            return View(await _context.Administradores.ToListAsync());
        }

       
        

        
    }
}