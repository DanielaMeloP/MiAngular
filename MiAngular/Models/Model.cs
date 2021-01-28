using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAngular.Models
{

    //Se crea la BD
    
    public class MyDBContext : DbContext
    {

        // Se crea constructor, con inyeccion de dependencias.
        // Se le indicara las opciones, que será la cadena de conexion a la BD.
        public MyDBContext(DbContextOptions<MyDBContext>options) : base (options)
        {

        }
        
        public DbSet<Message> Message { get; set; }

    }

    // Se crea la clase por entidad en la BD
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
