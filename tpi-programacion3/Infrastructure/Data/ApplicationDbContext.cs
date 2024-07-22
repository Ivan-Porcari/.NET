using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data //diseño de base de datos, tablas y columnas 
{
    public class ApplicationDbContext : DbContext
    //el context (corre 1 sola vez) tiene las configuraciones generales para toda la app y
    //el repositorio (corre siempre) encapsula la interacción con la base de dato por entidad
  
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products{ get; set; }
    public DbSet<Purchased> Purchaseds { get; set; }


    private readonly bool isTestingEnvironment;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
        this.isTestingEnvironment = isTestingEnvironment;
    }



}
