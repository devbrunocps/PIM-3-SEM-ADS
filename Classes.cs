using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaGeek
{
    public class Produto
    {
        public int CodigoBarras { get; set; }
        public required string Nome { get; set; }
        public required string Categoria { get; set; }
        public required string Fabricante { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public required string Plataforma { get; set; }
        public int PrazoGarantia { get; set; }
    }

    public class Cliente
    {
        public int Codigo { get; set; }
        public required string RG { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public required string Endereco { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
    }

    public class Venda
    {
        public int CodigoVenda { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public string OpcaoPagamento { get; set; }
        public string StatusPagamento { get; set; }
        public string StatusVenda { get; set; }

        public Venda()
        {
            Produtos = new List<Produto>();
        }
    }

    public class Usuario
    {
        public required string Login { get; set; }
        public required string Senha { get; set; }
        public required string NivelAcesso { get; set; }
    }
}
