﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class Categoria
{
    public int CategoriaId { get; set; }

    [StringLength(100, ErrorMessage = "O tamanho máximo é {1}")]
    [Required(ErrorMessage = "Informe o nome da categoria")]
    [Display(Name = "Nome")]
    public string CategoriaNome { get; set; }

    [StringLength(200, ErrorMessage = "O tamanho máximo é {1}")]
    [Required(ErrorMessage = "Inform a descrição da categoria")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    public List<Produto> Produtos { get; set; }

}