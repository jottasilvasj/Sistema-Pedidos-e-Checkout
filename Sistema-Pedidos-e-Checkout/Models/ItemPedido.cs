namespace Sistema_Pedidos_e_Checkout.Models
{
    class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Quantidade = quantidade;
        }

        public double Subtotal()
        {
            return Produto.Preco * Quantidade;
        }

        public void AplicarAtualizacaoEstoque()
        {
            Produto.AtualizarEstoque(Quantidade);
        }
    }
}
