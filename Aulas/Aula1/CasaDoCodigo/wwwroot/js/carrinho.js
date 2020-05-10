
class Carrinho {

    aumentarQuantidade(btn) {
        let data = this.getData(btn);
        data.Quantidade++;
        this.postUpdateQuantidade(data);
    }

    diminuirQuantidade(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postUpdateQuantidade(data);
    }

    setQuantidade(input) {
        let data = this.getData(input);
        this.postUpdateQuantidade(data);
    }

    getData(elemento) {
        var elementoComItemId = $(elemento).parents('[item-id]');
        var itemId = $(elementoComItemId).attr('item-id');
        var novaQtd = $(elementoComItemId).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtd
        };
    }

    postUpdateQuantidade(data) {

        let headers = {};
        let token = $('[name=__RequestVerificationToken]').val();
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            let itemPedido = response.itemPedido;

            let elementoComItemId = $('[item-id=' + itemPedido.id + ']');
            elementoComItemId.find('input').val(itemPedido.quantidade);
            elementoComItemId.find('[subtotal]').html((itemPedido.subtotal).valorContabil());

            let carrinhoViewModel = response.carrinho;
            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens');
            $('[total]').html((carrinhoViewModel.total).valorContabil());

            if (itemPedido.quantidade < 1) {
                elementoComItemId.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.valorContabil = function () {
    return this.toFixed(2).replace('.',',');
}