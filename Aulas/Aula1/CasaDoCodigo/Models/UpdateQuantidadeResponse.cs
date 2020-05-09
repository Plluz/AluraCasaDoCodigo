﻿using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinho)
        {
            ItemPedido = itemPedido;
            Carrinho = carrinho;
        }

        public ItemPedido ItemPedido { get; }

        public CarrinhoViewModel Carrinho { get; }
    }
}
