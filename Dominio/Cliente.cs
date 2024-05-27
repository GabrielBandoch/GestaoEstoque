using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


// Dupla: Felipe Da Silva Chawischi & Gabriel Felipe Alves Bandoch
namespace Dominio
{
    public class Cliente
    {
        private static List<string> nomeCli = new List<string>();
        private static List<string> numeroTelefone = new List<string>();

        private static int cods;
        private static List<int> codigos = new List<int>(); 
        private int codigo;
        private string nome;
        private string endereco;
        private string email;
        private string telefone;

        public Cliente(int codigo, string nome, string endereco, string email, string telefone)
        {
            if (codigo < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome Inválido");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço Inválido");
            if (string.IsNullOrEmpty(email) || !EmailValido(email)) throw new ArgumentException("Email Inválido");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone inválido");
            if (codigos.Contains(cods)) throw new ArgumentException("Codigo repetido");
            if (nomeCli.Contains(nome)) throw new ArgumentException("Já existe um cliente com esse nome");
            if (numeroTelefone.Contains(telefone)) throw new ArgumentException("Já existe um cliente com esse número de telefone");

            this.Codigo = codigo;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Email = email;
            this.Telefone = telefone;
            codigos.Add(cods);
            cods++;
            nomeCli.Add(nome);
            numeroTelefone.Add(telefone);
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }

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

        public void AtualizarInformacoes(string novoEndereco, string novoTelefone)
        {
            this.Endereco = novoEndereco;
            this.Telefone = novoTelefone;
        }

        public static List<Cliente> BuscarCliente(List<Cliente> clientes, string criterio)
        {
            return clientes.Where(c => c.Nome.Contains(criterio) || c.Email == criterio || c.Telefone == criterio).ToList();
        }

        public static bool NomeClienteJaExiste(string nomeCliente)
        {
            return nomeCli.Contains(nomeCliente);
        }

        public static bool NumeroTelefoneJaExiste(string telefoneNumero)
        {
            return numeroTelefone.Contains(telefoneNumero);
        }


    }
}