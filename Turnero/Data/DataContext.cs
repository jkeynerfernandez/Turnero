using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Models;

namespace Turnero.Data{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<HistorialTurno> HistorialTurnos { get; set; }
        
    }
}