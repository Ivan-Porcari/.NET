using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {   //al ser abstracta no la vamos a poder instanciar por si misma
        [Key] //atributo de identificación de todos los registros
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ID numerico
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserType { get; protected set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
