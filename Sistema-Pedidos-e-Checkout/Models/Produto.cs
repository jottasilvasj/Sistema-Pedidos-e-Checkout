namespace Sistema_Pedidos_e_Checkout.Models
{
    class Produto
    {
            public string Id { get; set; }
            public string Nome { get; set; }
            public double Preco { get; set; }
            public double Estoque { get; set; }

            public void AtualizarEstoque(int quantidade)
            {
                Estoque -= quantidade;
            }
    }
}
