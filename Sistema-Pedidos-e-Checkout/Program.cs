using System;
using Sistema_Pedidos_e_Checkout.Models;

Console.WriteLine("\n-- Sistema de Pedidos e Checkout --\n");

var cliente = new Cliente();
var pedido = new Pedido(cliente);

var produto1 = new Produto { Id = "1", Nome = "Produto 1", Preco = 10.0, Estoque = 100 };
var produto2 = new Produto { Id = "2", Nome = "Produto 2", Preco = 20.0, Estoque = 50 };
var produto3 = new Produto { Id = "3", Nome = "Produto 3", Preco = 30.0, Estoque = 30 };
var produto4 = new Produto { Id = "4", Nome = "Produto 4", Preco = 40.0, Estoque = 20 };
var produto5 = new Produto { Id = "5", Nome = "Produto 5", Preco = 50.0, Estoque = 10 };

Console.WriteLine("Digite o nome do cliente:");
cliente.Nome = Console.ReadLine() ?? string.Empty;

Console.WriteLine("\nDigite o email do cliente:");
cliente.Email = Console.ReadLine() ?? string.Empty;

Console.WriteLine("\nDigite o seu tipo de cliente (Comum, Silver, Gold):");
cliente.TipoCliente = Console.ReadLine() ?? string.Empty;

Console.WriteLine("\n--------------------------------------------\n");

Console.WriteLine("Itens disponíveis:");
Console.WriteLine("1. Produto 1 - R$ 10,00 (Estoque: 100)");
Console.WriteLine("2. Produto 2 - R$ 20,00 (Estoque: 50)");
Console.WriteLine("3. Produto 3 - R$ 30,00 (Estoque: 30)");
Console.WriteLine("4. Produto 4 - R$ 40,00 (Estoque: 20)");
Console.WriteLine("5. Produto 5 - R$ 50,00 (Estoque: 10)\n");

Console.WriteLine("Digite o ID do produto que deseja adicionar ao pedido (1 a 5):");
var idProduto = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Digite a quantidade desejada:");
if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
{
    quantidade = 1;
}

Produto? produtoSelecionado = idProduto switch
{
    "1" => produto1,
    "2" => produto2,
    "3" => produto3,
    "4" => produto4,
    "5" => produto5,
    _ => null
};

if (produtoSelecionado != null)
{
    if (produtoSelecionado.Estoque >= quantidade)
    {
        var itemPedido = new ItemPedido(produtoSelecionado, quantidade);
        pedido.AdicionarItem(itemPedido);
    }
    else
    {
        Console.WriteLine("\n[Erro] Estoque insuficiente para este produto.");
        return;
    }
}
else
{
    Console.WriteLine("\n[Erro] Produto não encontrado.");
    return;
}

Console.WriteLine("\n---------------------------------------------------------------------------------------------\n");
Console.WriteLine("Resumo do pedido:\n");
Console.WriteLine($"Cliente: {cliente.Nome}");
Console.WriteLine($"Email: {cliente.Email}");
Console.WriteLine($"Tipo de Cliente: {cliente.TipoCliente}\n");

Console.WriteLine("Itens do pedido:");
foreach (var item in pedido.Itens)
{
    Console.WriteLine($"- {item.Produto.Nome} | Quantidade: {item.Quantidade} | Subtotal: R$ {item.Subtotal():F2}");
}

double totalComDescontoCliente = pedido.CalcularTotal();
Console.WriteLine($"\nTotal parcial (com desconto de perfil '{cliente.TipoCliente}'): R$ {totalComDescontoCliente:F2}");
Console.WriteLine("\n---------------------------------------------------------------------------------------------\n");

Console.WriteLine("Escolha a forma de pagamento (Pix, Cartão de Crédito, Boleto):");
var metodoPagamento = Console.ReadLine() ?? "Pix";

var pagamento = new Pagamento(pedido, metodoPagamento);
double valorFinal = pagamento.ValidarPagamento();

Console.WriteLine($"\nValor final após aplicação da forma de pagamento ({metodoPagamento}): R$ {valorFinal:F2}");

pagamento.ProcessarPagamento();
Console.WriteLine("\n[Sucesso] Pagamento processado e estoque atualizado com sucesso!");