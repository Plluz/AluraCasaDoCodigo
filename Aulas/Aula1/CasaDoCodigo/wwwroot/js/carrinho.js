
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
        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            let itemPedido = response.itemPedido;
            let elementoComItemId = $('[item-id=' + itemPedido.id + ']');
            elementoComItemId.find('input').val(itemPedido.quantidade);
            elementoComItemId.find('[subtotal]').html((itemPedido.subtotal).valorContabil());
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.valorContabil = function () {
    return this.toFixed(2).replace('.',',');
}