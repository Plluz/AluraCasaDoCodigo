
class Carrinho {

    clickIncrementar(btn) {
        let data = this.getData(btn);
        data.Quantidade++;
        this.postUpdateQuantidade(data);
    }

    clickDecrementar(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postUpdateQuantidade(data);
    }

    getData(elemento) {
        var itemId = $(elemento).parents('[item-id]').attr('item-id');
        var novaQtd = $(elemento).parents('[item-id]').find('input').val();

        return {
            Id = itemId,
            Quantidade = novaQtd
        };
    }

    postUpdateQuantidade(data) {
        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        });
    }

}

var carrinho = new Carrinho();