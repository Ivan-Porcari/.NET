using Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data //diseño de base de datos, tablas y columnas 
{
    public class ApplicationDbContext : DbContext
    { 
    //el context (corre 1 sola vez) tiene las configuraciones generales para toda la app y
    //el repositorio (corre siempre) encapsula la interacción con la base de dato por entidad
    
    private readonly bool isTestingEnvironment;
    public DbSet<User> Users { get; set; }  //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<TicketDoc> TicketDocs { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
    public DbSet<Product> Products{ get; set; }
    public DbSet<Purchased> Purchaseds { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
        this.isTestingEnvironment = isTestingEnvironment;
    }

    }



}
