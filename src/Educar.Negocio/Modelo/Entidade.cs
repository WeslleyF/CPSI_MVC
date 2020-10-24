using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Educar.Negocio.Modelo
{
    public abstract class Entidade
    {
        [Key]
        public int Id {get; set;}

    }
}
