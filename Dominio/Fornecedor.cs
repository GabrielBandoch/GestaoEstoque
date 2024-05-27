using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


// Dupla: Felipe Da Silva Chawischi & Gabriel Felipe Alves Bandoch
namespace Dominio
{
    public class Fornecedor
    {
        private static List<string> nomesEmpresas = new List<string>();
        private static List<string> numerosTelefone = new List<string>();
        private int id;
        private string nome;
        private string endereco;
        private string telefone;
        private string email;
        private string termosPagamento;

        public Fornecedor(int id, string nome, string endereco, string telefone, string email, string termosPagamento)
        {
            if (id < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome da empresa é obrigatório");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço é obrigatório");
            if (string.IsNullOrEmpty(email) || !EmailValido(email)) throw new ArgumentException("Email Inválido");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone é obrigatório");
            if (nomesEmpresas.Contains(nome)) throw new ArgumentException("Já existe um fornecedor com esse nome");
            if (numerosTelefone.Contains(telefone)) throw new ArgumentException("Já existe um fornecedor com esse número de telefone");

            this.id = id;
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.termosPagamento = termosPagamento;
            nomesEmpresas.Add(nome);
            numerosTelefone.Add(telefone);
        }

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string TermosPagamento { get => termosPagamento; set => termosPagamento = value; }

        public bool EmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void Atualizar(string novoEndereco, string novoTelefone, string novoEmail, string novosTermosPagamento)
        {
            if (string.IsNullOrEmpty(novoEndereco)) throw new ArgumentException("Endereço é obrigatório");
            if (string.IsNullOrEmpty(novoEmail) || !EmailValido(novoEmail)) throw new ArgumentException("Email Inválido");
            if (string.IsNullOrEmpty(novoTelefone)) throw new ArgumentException("Telefone é obrigatório");

            this.endereco = novoEndereco;
            this.telefone = novoTelefone;
            this.email = novoEmail;
            this.termosPagamento = novosTermosPagamento;
        }

        public bool Corresponde(string termoDeBusca)
        {
            return nome.Contains(termoDeBusca, StringComparison.OrdinalIgnoreCase) ||
                   email.Contains(termoDeBusca, StringComparison.OrdinalIgnoreCase) ||
                   telefone.Contains(termoDeBusca);
        }

        public static List<Fornecedor> BuscarFornecedores(List<Fornecedor> fornecedores, string termoDeBusca)
        {
            return fornecedores.FindAll(fornecedor => fornecedor.Corresponde(termoDeBusca));
        }

        public static bool NomeEmpresaJaExiste(string nomeEmpresa)
        {
            return nomesEmpresas.Contains(nomeEmpresa);
        }

        public static bool NumeroTelefoneJaExiste(string numeroTelefone)
        {
            return numerosTelefone.Contains(numeroTelefone);
        }

    }
}
