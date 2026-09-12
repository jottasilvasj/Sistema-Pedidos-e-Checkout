namespace Sistema_Pedidos_e_Checkout.Models
{
    class Cliente
    {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string TipoCliente { get; set; }

            public double Tipo()
            {
                if (TipoCliente.Equals("Comum", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.00;
                }
                else if (TipoCliente.Equals("Silver", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.05;
                }
                else if (TipoCliente.Equals("Gold", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.15;
                }
                else
                {
                    return 0.00;
                }
            }
        }
    }
