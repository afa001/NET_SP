using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public int Respuesta { get; set; }
        public DateTime FechaHora { get; set; }
        public int UsuarioId { get; set; }
    }
}