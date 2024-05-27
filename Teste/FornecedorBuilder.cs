using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Teste
{
    internal class FornecedorBuilder
    {
        
        private int id = 1;
        private string nome = "Empresa ABC";
        private string endereco = "Rua XYZ";
        private string telefone = "123456789";
        private string email = "email@empresa.com";
        private string termosPagamento = "30 dias";

        public static FornecedorBuilder Novo()
        {
            return new FornecedorBuilder();
        }

        public Fornecedor Criar()
        {
            return new Fornecedor(
                id,
                nome,
                endereco,
                telefone,
                email,
                termosPagamento
            );
        }

        public FornecedorBuilder GerarDados()
        {
            Faker faker = new Faker();

            id = faker.Random.Int(1, 999);
            nome = faker.Company.CompanyName();
            endereco = faker.Address.FullAddress();
            telefone = faker.Person.Phone;
            email = faker.Person.Email;
            termosPagamento = faker.Random.ArrayElement(new[] { "30 dias", "45 dias", "60 dias" });

            return this;
        }

        public FornecedorBuilder ComCodigo(int codigo)
        {
            this.id = codigo;
            return this;
        }

        public FornecedorBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public FornecedorBuilder ComEndereco(string endereco)
        {
            this.endereco = endereco;
            return this;
        }

        public FornecedorBuilder ComTelefone(string telefone)
        {
            this.telefone = telefone;
            return this;
        }

        public FornecedorBuilder ComEmail(string email)
        {
            this.email = email;
            return this;
        }

        public FornecedorBuilder ComTermoPGTO(string termo)
        {
            this.termosPagamento = termo;
            return this;
        }
    }
}
