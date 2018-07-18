using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CategoriaViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}