using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Service.Models
{
    public class Produto
    {
        /// <summary>
        /// Codigo de identificação unico do Produto
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de identificação do Produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição detalhada do Produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Quantidade disponível do produto
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário de compra do produto
        /// </summary>
        public decimal PrecoUnitarioCompra { get; set; }

        /// <summary>
        /// Preço unitário de venda do Produto
        /// </summary>
        public decimal PrecoUnitarioVenda { get; set; }

        /// <summary>
        /// Data da ultima atualização das informações do produto
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Categoria a qual pertence o produto
        /// </summary>
        public Categoria Categoria { get; set; }
    }
}
