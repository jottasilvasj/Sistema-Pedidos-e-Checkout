namespace Sistema_Pedidos_e_Checkout.Models
{
    class Pagamento
    {
        public Pedido Pedido { get; set; }
        public string MetodoPagamento { get; set; }
        public Pagamento(Pedido pedido, string metodoPagamento)
        {
            Pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));
            MetodoPagamento = metodoPagamento;
        }
        public double ValidarPagamento()
        {
            double total = Pedido.CalcularTotal();

            if (MetodoPagamento.Equals("Pix", StringComparison.OrdinalIgnoreCase))
            {
                double desconto = total * 0.15;
                return total - desconto;
            }
            else if (MetodoPagamento.Equals("Cartão de Crédito", StringComparison.OrdinalIgnoreCase))
            {
                double acrescimo = total * 0.0;
                return total + acrescimo;
            }
            else if (MetodoPagamento.Equals("Boleto", StringComparison.OrdinalIgnoreCase))
            {
                double desconto = total * 0.03;
                return total - desconto;
            }

            return total;
        }

        public void ProcessarPagamento()
        {
            double valorAPagar = ValidarPagamento();

            foreach (var item in Pedido.Itens)
            {
                item.AplicarAtualizacaoEstoque();
            }
        }
    }
}
