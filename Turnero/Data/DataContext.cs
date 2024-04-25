using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnero.Models;

namespace Turnero.Data{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Buttons_services> Buttons_services { get; set; }
    }

    public class Buttons_services
    {
    }
}