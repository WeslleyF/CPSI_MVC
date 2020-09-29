using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPSI.Negocio.Modelo
{
    public abstract class Entidade
    {
        [Key]
        public int Id {get; set;}

    }
}
