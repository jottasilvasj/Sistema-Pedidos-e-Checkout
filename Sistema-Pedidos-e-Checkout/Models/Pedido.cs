namespace Sistema_Pedidos_e_Checkout.Models
{
    class Pedido
    {  
        public Cliente Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public Pedido(Cliente cliente)
        {
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Itens = new List<ItemPedido>();
        }
        public void AdicionarItem(ItemPedido item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            Itens.Add(item);
        }
        public double CalcularTotal()
        {
            double total = 0.0;
            foreach (var item in Itens)
            {
                total += item.Subtotal();
            }
            double desconto = total * Cliente.Tipo();
            return total - desconto;
        }
    }
}
