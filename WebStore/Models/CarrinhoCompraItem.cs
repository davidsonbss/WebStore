﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class CarrinhoCompraItem
{
    public int CarrinhoCompraItemId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    [StringLength(200)]
    public string CarrinhoCompraId { get; set; }
}