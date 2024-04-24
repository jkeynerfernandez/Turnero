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

        [HttpPost]
        public async Task<IActionResult> Login(string NombreLogin, string ContraseñaLogin){

            if(NombreLogin != null && ContraseñaLogin != null){
                var adminLog = await _context.Administradores.FirstOrDefaultAsync(ad => ad.Nombre == NombreLogin);
                if(adminLog != null && adminLog.Contraseña == ContraseñaLogin){
                    
                    return RedirectToAction("Index" , "Administradores");
                }else{
                    ViewBag.Alerta = "El nombre o la contraseña son incorrectos";
                    return RedirectToAction("Index");
                }
            }else{
                ViewBag.Alerta = "Debes llenar todos los campos";
                return RedirectToAction("Index") ;    
            }
        }


        public IActionResult Teclear(){
            
            

            
            
            return View();
        }
    }
}