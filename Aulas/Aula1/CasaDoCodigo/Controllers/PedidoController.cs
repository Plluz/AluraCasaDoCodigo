﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();
            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }
            return View(pedido.Cadastro);
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }

            IList<ItemPedido> itensPedido = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itensPedido);
            return base.View(carrinhoViewModel);
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(pedidoRepository.UpdateCadastro(cadastro));
            }

            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}