using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaGeek
{
    public class Sistema
    {
        private List<Produto> produtos = new List<Produto>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Venda> vendas = new List<Venda>();
        private List<Usuario> usuarios = new List<Usuario>();

        public Sistema()
        {
            usuarios.Add(new Usuario { Login = "admin", Senha = "admin123", NivelAcesso = "Supervisor" });
            usuarios.Add(new Usuario { Login = "estoquista", Senha = "estoque123", NivelAcesso = "Estoquista" });
            usuarios.Add(new Usuario { Login = "atendente", Senha = "atende123", NivelAcesso = "Atendente" });
        }

        public bool Login(string login, string senha)
        {
            return usuarios.Any(u => u.Login == login && u.Senha == senha);
        }

        public Usuario ObterUsuario(string login)
        {
            return usuarios.FirstOrDefault(u => u.Login == login);
        }

        public void CadastrarProduto(Produto produto, string login)
        {
            if (Login(login, ObterUsuario(login).Senha))
            {
                produtos.Add(produto);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não autenticado!");
            }
        }

        public void AlterarProduto(Produto produto, string login)
        {
            if (Login(login, ObterUsuario(login).Senha))
            {
                var p = produtos.FirstOrDefault(pr => pr.CodigoBarras == produto.CodigoBarras);
                if (p != null)
                {
                    p.Nome = produto.Nome;
                    p.Categoria = produto.Categoria;
                    p.Fabricante = produto.Fabricante;
                    p.Quantidade = produto.Quantidade;
                    p.Valor = produto.Valor;
                    p.Plataforma = produto.Plataforma;
                    p.PrazoGarantia = produto.PrazoGarantia;
                    Console.WriteLine("Produto alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não autenticado!");
            }
        }

        public void ExcluirProduto(int codigoBarras, string login, string senha)
        {
            if (Login(login, senha) && ObterUsuario(login).NivelAcesso == "Supervisor")
            {
                var produto = produtos.FirstOrDefault(p => p.CodigoBarras == codigoBarras);
                if (produto != null)
                {
                    produtos.Remove(produto);
                    Console.WriteLine("Produto excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não autorizado!");
            }
        }

        public Produto ConsultarProduto(int codigoBarras)
        {
            return produtos.FirstOrDefault(p => p.CodigoBarras == codigoBarras);
        }

        public void CadastrarCliente(Cliente cliente, string login)
        {
            if (Login(login, ObterUsuario(login).Senha))
            {
                clientes.Add(cliente);
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não autenticado!");
            }
        }

        public void AlterarCliente(Cliente cliente, string login)
        {
            if (Login(login, ObterUsuario(login).Senha))
            {
                var c = clientes.FirstOrDefault(cl => cl.Codigo == cliente.Codigo);
                if (c != null)
                {
                    c.RG = cliente.RG;
                    c.CPF = cliente.CPF;
                    c.Nome = cliente.Nome;
                    c.DataCadastro = cliente.DataCadastro;
                    c.Endereco = cliente.Endereco;
                    c.Telefone = cliente.Telefone;
                    c.Email = cliente.Email;
                    Console.WriteLine("Cliente alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não autenticado!");
            }
        }

        public void ExcluirCliente(int codigo, string login)
        {
            if (Login(login, ObterUsuario(login).Senha) && ObterUsuario(login).NivelAcesso == "Supervisor")
            {
                var cliente = clientes.FirstOrDefault(c => c.Codigo == codigo);
                if (cliente != null)
                {
                    clientes.Remove(cliente);
                    Console.WriteLine("Cliente excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não autorizado!");
            }
        }

        public Cliente ConsultarCliente(int codigo)
        {
            return clientes.FirstOrDefault(c => c.Codigo == codigo);
        }

        public void RealizarVenda(Venda venda, string login)
        {
            if (Login(login, ObterUsuario(login).Senha))
            {
                vendas.Add(venda);
                Console.WriteLine("Venda realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não autenticado!");
            }
        }

        public void CancelarVenda(int codigoVenda, string login)
        {
            if (Login(login, ObterUsuario(login).Senha) && ObterUsuario(login).NivelAcesso == "Supervisor")
            {
                var venda = vendas.FirstOrDefault(v => v.CodigoVenda == codigoVenda);
                if (venda != null)
                {
                    vendas.Remove(venda);
                    Console.WriteLine("Venda cancelada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Venda não encontrada!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não autorizado!");
            }
        }
    }
}
