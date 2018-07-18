using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Service.Models
{
    public class Categoria 
    {
        /// <summary>
        /// Codigo de identificação unica da categoria
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de identificação da categoria
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Identificação do status da Categoria
        /// </summary>
        public bool Ativo { get; set; }
    }
}
