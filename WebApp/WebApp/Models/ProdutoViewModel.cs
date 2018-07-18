using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProdutoViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings =false,ErrorMessage = "Favor informar o nome do produto")]
        [MaxLength(30,ErrorMessage = "O nome do produto deve conter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor informar a descrição do produto")]
        [MaxLength(500, ErrorMessage = "A descrição do produto deve conter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade disponível")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor informar a quantidade de unidades disponíveis para este produto")]
        public int Quantidade { get; set; }

        [Display(Name = "Valor de compra")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor informar o valor de compra do produto")]
        public decimal PrecoUnitarioCompra { get; set; }

        [Display(Name = "Preço Sugerido Venda")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor informar o valor de venda do produto")]
        public decimal PrecoUnitarioVenda { get; set; }

        [Display(Name = "Ultima atualização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataAtualizacao { get; set; }

        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        
    }
}
