# 🛒 Sistema de Pedidos e Checkout

Um sistema completo de gerenciamento de pedidos e processamento de checkout desenvolvido em **C#** com .NET 10.0. O projeto implementa funcionalidades essenciais para e-commerce, incluindo gestão de clientes, produtos, pedidos e pagamentos com suporte a diferentes métodos e tipos de cliente com descontos progressivos.

## 📋 Sumário

- [Características](#características)
- [Requisitos](#requisitos)
- [Instalação](#instalação)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Usar](#como-usar)
- [Arquitetura](#arquitetura)
- [Modelos de Dados](#modelos-de-dados)
- [Métodos de Pagamento](#métodos-de-pagamento)
- [Tipos de Cliente](#tipos-de-cliente)
- [Exemplos de Uso](#exemplos-de-uso)
- [Contribuição](#contribuição)

## ✨ Características

- ✅ **Gestão de Clientes**: Cadastro com tipos diferenciados (Comum, Silver, Gold)
- ✅ **Catálogo de Produtos**: Gerenciamento de produtos com preço e estoque
- ✅ **Sistema de Pedidos**: Criação e processamento de pedidos
- ✅ **Processamento de Pagamentos**: Suporte a Pix, Cartão de Crédito e Boleto
- ✅ **Sistema de Descontos**: Descontos variáveis por tipo de cliente e método de pagamento
- ✅ **Controle de Estoque**: Atualização automática após processamento do pedido
- ✅ **Validação de Entrada**: Tratamento de erros e validações de dados

## 🔧 Requisitos

- **.NET 10.0** ou superior
- **C# 13.0** ou superior
- Visual Studio, Visual Studio Code ou qualquer IDE compatível com .NET

## 📥 Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/jottasilvasj/Sistema-Pedidos-e-Checkout.git
cd SIstema-Pedidos-e-Checkout
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Compile o projeto

```bash
dotnet build
```

### 4. Execute o projeto

```bash
dotnet run --project Sistema-Pedidos-e-Checkout/Sistema-Pedidos-e-Checkout.csproj
```

## 📁 Estrutura do Projeto

```
SIstema-Pedidos-e-Checkout/
├── Sistema-Pedidos-e-Checkout/
│   ├── Models/
│   │   ├── Cliente.cs          # Modelo de cliente com tipos e descontos
│   │   ├── Produto.cs          # Modelo de produto com controle de estoque
│   │   ├── Pedido.cs           # Modelo de pedido com cálculo de total
│   │   ├── ItemPedido.cs       # Item individual do pedido
│   │   └── Pagamento.cs        # Processamento de pagamentos
│   ├── Program.cs              # Ponto de entrada da aplicação
│   └── Sistema-Pedidos-e-Checkout.csproj
├── .gitignore
└── README.md
```

## 🚀 Como Usar

### Fluxo Básico de Funcionamento

1. **Criação do Cliente**: Sistema solicita nome, email e tipo de cliente
2. **Seleção de Produtos**: Usuário escolhe produtos disponíveis em estoque
3. **Cálculo do Pedido**: Sistema calcula subtotal com desconto do tipo de cliente
4. **Seleção de Pagamento**: Usuário escolhe método de pagamento
5. **Processamento Final**: Sistema aplica desconto do método de pagamento e atualiza estoque

### Exemplo de Execução

```
-- Sistema de Pedidos e Checkout --

Digite o nome do cliente:
João Silva

Digite o email do cliente:
joao@example.com

Digite o seu tipo de cliente (Comum, Silver, Gold):
Gold

--------------------------------------------

Itens disponíveis:
1. Produto 1 - R$ 10,00 (Estoque: 100)
2. Produto 2 - R$ 20,00 (Estoque: 50)
3. Produto 3 - R$ 30,00 (Estoque: 30)
4. Produto 4 - R$ 40,00 (Estoque: 20)
5. Produto 5 - R$ 50,00 (Estoque: 10)

Digite o ID do produto que deseja adicionar ao pedido (1 a 5):
2

Digite a quantidade desejada:
2

---------------------------------------------------------------------------------------------

Resumo do pedido:

Cliente: João Silva
Email: joao@example.com
Tipo de Cliente: Gold

Itens do pedido:
- Produto 2 | Quantidade: 2 | Subtotal: R$ 40,00

Total parcial (com desconto de perfil 'Gold'): R$ 34,00

---------------------------------------------------------------------------------------------

Escolha a forma de pagamento (Pix, Cartão de Crédito, Boleto):
Pix

Valor final após aplicação da forma de pagamento (Pix): R$ 28,90

[Sucesso] Pagamento processado e estoque atualizado com sucesso!
```

## 🏗️ Arquitetura

O projeto segue um padrão simples baseado em **modelos de domínio** (Domain Models):

- **Cliente**: Responsável por armazenar dados do cliente e calcular desconto por tipo
- **Produto**: Gerencia informações do produto e atualização de estoque
- **Pedido**: Orquestra itens do pedido e cálculo de total
- **ItemPedido**: Representa um item específico no pedido
- **Pagamento**: Processa validação e cálculo de pagamento com aplicação de descontos

## 📊 Modelos de Dados

### Cliente

```csharp
class Cliente
{
    public string Nome { get; set; }           // Nome do cliente
    public string Email { get; set; }          // Email para contato
    public string TipoCliente { get; set; }    // Tipo: Comum, Silver, Gold
    
    public double Tipo()                       // Retorna % de desconto baseado no tipo
}
```

**Descontos por Tipo**:
- **Comum**: 0% de desconto
- **Silver**: 5% de desconto
- **Gold**: 15% de desconto

### Produto

```csharp
class Produto
{
    public string Id { get; set; }             // Identificador único
    public string Nome { get; set; }           // Nome do produto
    public double Preco { get; set; }          // Preço unitário
    public double Estoque { get; set; }        // Quantidade em estoque
    
    public void AtualizarEstoque(int quantidade)  // Reduz estoque após venda
}
```

### Pedido

```csharp
class Pedido
{
    public Cliente Cliente { get; set; }           // Cliente associado
    public List<ItemPedido> Itens { get; set; }    // Itens do pedido
    
    public void AdicionarItem(ItemPedido item)     // Adiciona item ao pedido
    public double CalcularTotal()                  // Calcula total com desconto
}
```

### ItemPedido

```csharp
class ItemPedido
{
    public Produto Produto { get; set; }       // Produto selecionado
    public int Quantidade { get; set; }        // Quantidade solicitada
    
    public double Subtotal()                   // Calcula subtotal do item
    public void AplicarAtualizacaoEstoque()   // Atualiza estoque do produto
}
```

### Pagamento

```csharp
class Pagamento
{
    public Pedido Pedido { get; set; }             // Pedido a processar
    public string MetodoPagamento { get; set; }    // Método: Pix, Cartão, Boleto
    
    public double ValidarPagamento()               // Calcula valor final com desconto
    public void ProcessarPagamento()               // Processa e atualiza estoque
}
```

## 💳 Métodos de Pagamento

| Método | Desconto/Acréscimo |
|--------|-------------------|
| **Pix** | 15% de desconto |
| **Cartão de Crédito** | Sem desconto (0%) |
| **Boleto** | 3% de desconto |

## 👥 Tipos de Cliente

| Tipo | Desconto |
|------|----------|
| **Comum** | 0% |
| **Silver** | 5% |
| **Gold** | 15% |

## 📝 Exemplos de Uso

### Cálculo de Desconto Progressivo

Um cliente **Gold** comprando **2 unidades de Produto 2** (R$ 20,00 cada) pagando com **Pix**:

```
Subtotal: R$ 20,00 × 2 = R$ 40,00
Desconto Gold (15%): R$ 40,00 × 0.15 = R$ 6,00
Total com desconto de cliente: R$ 34,00
Desconto Pix (15%): R$ 34,00 × 0.15 = R$ 5,10
Valor Final: R$ 28,90
```

### Validação de Estoque

Se o cliente tentar comprar mais unidades do que disponível em estoque, o sistema exibe um erro:

```
[Erro] Estoque insuficiente para este produto.
```

## 🔒 Tratamento de Erros

- ✅ Validação de quantidade com padrão positivo (1 se inválido)
- ✅ Verificação de estoque antes de adicionar item
- ✅ Validação de produto inexistente
- ✅ Tratamento de argumentos nulos nas classes
- ✅ Comparação case-insensitive para tipos de cliente e métodos de pagamento

## 🤝 Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça um **fork** do repositório
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um **Pull Request**

## 📋 Melhorias Futuras

- [ ] Persistência de dados (Banco de Dados)
- [ ] Interface gráfica (WPF/WinForms)
- [ ] API REST para integração
- [ ] Testes unitários automatizados
- [ ] Múltiplos itens por pedido sem limites
- [ ] Sistema de cupons e promoções
- [ ] Histórico de pedidos
- [ ] Notificações por email

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 👨‍💻 Autor

**João Silva** (jottasilvasj)

- GitHub: [@jottasilvasj](https://github.com/jottasilvasj)
- Email: sdj.joaopedro@gmail.com

---

**Desenvolvido com ❤️ em C# .NET**
