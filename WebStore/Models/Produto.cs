using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class Produto
{
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O {0} do produto deve ser informado")]
    [Display(Name = "{0} do produto")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {2} e máximo {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição do produto deve ser informada")]
    [Display(Name = "Descrição do produto")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "A descrição deve ter no mínimo {2} e máximo {1} caracteres")]
    public string DescricaoCurta { get; set; }

    [Required(ErrorMessage = "A descrição detalhada do produto deve ser informada")]
    [Display(Name = "Descrição detalhada do produto")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "A descrição deve ter no mínimo {2} e máximo {1} caracteres")]
    public string DescricaoDetalhada { get; set; }

    [Required(ErrorMessage = "O preço do produto deve ser informado")]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O preço deve estar entre {1} e {2}")]
    public decimal Preco { get; set; }

    [Display(Name = "Caminho da image normal")]
    [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
    public string ImagemUrl { get; set; }

    [Display(Name = "Caminho da image miniatura")]
    [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
    public string ImagemThumbnailUrl { get; set; }

    [Display(Name = "Destaque?")]
    public bool ProdutoDestaque { get; set; }

    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

}