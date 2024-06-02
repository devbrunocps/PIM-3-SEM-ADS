using System;

namespace LojaGeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();
            
            // Exemplos de uso:
            Produto novoProduto = new Produto
            {
                CodigoBarras = 12345,
                Nome = "Jogo XYZ",
                Categoria = "Jogos",
                Fabricante = "Fabricante XYZ",
                Quantidade = 10,
                Valor = 199.99M,
                Plataforma = "PC",
                PrazoGarantia = 12
            };

            sistema.CadastrarProduto(novoProduto, "estoquista");

            Cliente novoCliente = new Cliente
            {
                Codigo = 1,
                RG = "12345678-9",
                CPF = "123.456.789-00",
                Nome = "João da Silva",
                DataCadastro = DateTime.Now,
                Endereco = "Rua XYZ, 123",
                Telefone = "(11) 1234-5678",
                Email = "joao.silva@exemplo.com"
            };

            sistema.CadastrarCliente(novoCliente, "atendente");

            Venda novaVenda = new Venda
            {
                CodigoVenda = 1,
                Cliente = novoCliente,
                DataVenda = DateTime.Now,
                ValorTotal = novoProduto.Valor,
                OpcaoPagamento = "Cartão de Crédito",
                StatusPagamento = "Pago",
                StatusVenda = "Concluída"
            };
            novaVenda.Produtos.Add(novoProduto);

            sistema.RealizarVenda(novaVenda, "atendente");

            sistema.CancelarVenda(1, "admin");

            Console.ReadLine();
        }
    }
}
