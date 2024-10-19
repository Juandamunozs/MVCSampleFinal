using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto

    {

        [Key]
        public Guid Id { get; set; }

        public String Nombre { get; set; }

        public float Precio { get; set; }

        public int stock { get; set; }
    }
}

