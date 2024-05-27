 using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal class ClienteBuilder
    {

        private int codigo = 1;
        private string nome = "gabriel";
        private string endereco = "Rua saguaçu";
        private string email = "teste@gmail.com";
        private string telefone = "123456789";

        public static ClienteBuilder Novo()
        {
            return new ClienteBuilder();
        }

        public Cliente Criar()
        {
            return new Cliente(
                codigo,
                nome,
                endereco,
                email,
                telefone
                );
        }

        public ClienteBuilder GerarDados()
        {
            Faker faker = new Faker();

            codigo = faker.Random.Int(1, 900);
            nome = faker.Person.FullName;
            endereco = faker.Address.FullAddress();
            email = faker.Person.Email;
            telefone = faker.Person.Phone;

            return this;
        }

        public ClienteBuilder ComCodigo(int cod) 
        {
            this.codigo = cod;
            return this;
        }

        public ClienteBuilder ComNome(string nom)
        {
            this.nome = nom;
            return this;
        }

        public ClienteBuilder ComEndereco(string end)
        {
            this.endereco = end;
            return this;
        }

        public ClienteBuilder ComEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ClienteBuilder ComTelefone(string fon)
        {
            this.telefone = fon;
            return this;
        }
    }
}
