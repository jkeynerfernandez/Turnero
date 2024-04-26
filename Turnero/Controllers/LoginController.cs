using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Data;
using Turnero.Models;
using Microsoft.AspNetCore.Http;

namespace Turnero.Controllers{
    public class LoginController : Controller{
        public readonly DataContext _context;

        public LoginController(DataContext context){
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Usuario(){
            return View();
        }

           public IActionResult Buttons_services(){
            return View( "Button_service");
        }


        [HttpPost]
        public async Task<IActionResult> Login(string NombreLogin, string ContraseñaLogin){

            if(NombreLogin != null && ContraseñaLogin != null){
                var adminLog = await _context.Administradores.FirstOrDefaultAsync(ad => ad.Nombre == NombreLogin);

                if(adminLog != null && adminLog.Contraseña == ContraseñaLogin){

                    //datos extraidos al iniciar sesion 
                    HttpContext.Session.SetString("Nombre",adminLog.Nombre);
                    HttpContext.Session.SetString("Puesto",adminLog.Puesto);
                    //fin de extraccion de datos 

                    return RedirectToAction("Index" , "Administradores");
                }else{
                    TempData["alerta"] = "El nombre o la contraseña son incorrectos";
                    return RedirectToAction("Index");
                }
            }else{
                TempData["alerta"] = "Debes llenar todos los campos";
                return RedirectToAction("Index") ;    
            }   
        }
        public IActionResult Botones(){
            return View();
        }

        public IActionResult CreateSC(){
            var Num = _context.Turnos.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Tipo == "SC");
            var n = 0;
            if(Num == null){
                n = 1;
                var NuevoTurno = new Turno (){
                    Tipo = "SC",
                    Numero = n,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }else
            {
                n = Num.Numero; 
                var NuevoTurno = new Turno (){
                    Tipo = "SC",
                    Numero = n + 1,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }
        }

        public IActionResult CreatePF(){
            var Num = _context.Turnos.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Tipo == "PF");
            var n = 0;
            if(Num == null){
                n = 1;
                var NuevoTurno = new Turno (){
                    Tipo = "PF",
                    Numero = n,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }else
            {
                n = Num.Numero; 
                var NuevoTurno = new Turno (){
                    Tipo = "PF",
                    Numero = n + 1,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }            
        }

        public IActionResult CreateAM(){
            var Num = _context.Turnos.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Tipo == "AM");
            var n = 0;
            if(Num == null){
                n = 1;
                var NuevoTurno = new Turno (){
                    Tipo = "AM",
                    Numero = n,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }else
            {
                n = Num.Numero; 
                var NuevoTurno = new Turno (){
                    Tipo = "AM",
                    Numero = n + 1,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }            
        }

        public IActionResult CreateIG(){
            var Num = _context.Turnos.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Tipo == "IG");
            var n = 0;
            if(Num == null){
                n = 1;
                var NuevoTurno = new Turno (){
                    Tipo = "IG",
                    Numero = n,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }else
            {
                n = Num.Numero; 
                var NuevoTurno = new Turno (){
                    Tipo = "IG",
                    Numero = n + 1,
                    ModuloId = 1
                };
                _context.Turnos.Add(NuevoTurno);
                _context.SaveChanges();
                return RedirectToAction("VistaTurno");
            }            
        }

        public async Task<IActionResult> VistaTurno(){
            var turno = await _context.Turnos.OrderByDescending(x => x.Id).Take(1).ToListAsync();
            return View(turno);
        }
    }
}