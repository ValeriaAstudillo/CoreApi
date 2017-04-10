using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiAspNetCore.Models
{
    public class Perfil
    {
        [Key]
        public int ID { get; set; }
        public string CodigoPerfil { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }
        public bool EsGeneral { get; set; }
    }
}
