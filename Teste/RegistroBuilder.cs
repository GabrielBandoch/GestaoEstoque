using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal class RegistroBuilder
    {
        private int dataEntrada = 2010;
        private int qtd = 2;
        private string fornecedorCliente = "Fonecedor";
        private string motivoEntrada = "Compra";
        private int numFatura = 2;
        private decimal valorCompra = 22;
        private int codigo = 1;
        private decimal valorVenda = 12;
        private int dataSaida = 2011;
        private string motivoSaida = "venda";

        public static RegistroBuilder Novo()
        {
            return new RegistroBuilder();
        }

        public Registro Criar()
        {
            return new Registro(
                dataEntrada,
                qtd,
                fornecedorCliente,
                motivoEntrada,
                numFatura,
                valorCompra,
                codigo,
                valorVenda,
                dataSaida,
                motivoSaida
                );
        }

        public RegistroBuilder GerarDados()
        {
            Faker faker = new Faker();

            dataEntrada = faker.Random.Int(1999,2024);
            qtd = faker.Random.Int(1,100);
            fornecedorCliente = faker.PickRandom( new[] {"fornecedor", "cliente"});
            motivoEntrada = faker.PickRandom(new[] { "devolução", "tranferencia", "compra" });
            numFatura = faker.Random.Int(1,100);
            valorCompra = faker.Random.Decimal(0.1m, 50000);
            codigo = faker.Random.Int(1, 900);
            valorVenda = faker.Random.Decimal(0.1m, 50000);
            dataSaida = faker.Random.Int(1999, 2024);
            motivoSaida = faker.PickRandom(new[] { "devolução", "tranferencia", "venda" });

            return this;
        }

        public RegistroBuilder ComQtd(int qtd)
        {
            this.qtd = qtd;
            return this;
        }

        public RegistroBuilder ComForCli(string forCli)
        {
            this.fornecedorCliente = forCli;
            return this;
        }

        public RegistroBuilder ComMotivo(string motE)
        {
            this.motivoEntrada = motE;
            return this;
        }

        public RegistroBuilder ComFatura(int fatu)
        {
            this.numFatura = fatu;
            return this;
        }


        public RegistroBuilder ComValor(decimal valC)
        {
            this.valorCompra = valC;
            return this;
        }

        public RegistroBuilder ComCodigo(int cod)
        {
            this.codigo = cod;
            return this;
        }


        public RegistroBuilder ComMotivoSaida(string motES)
        {
            this.motivoSaida = motES;
            return this;
        }

        public RegistroBuilder ComValorVenda(decimal valV)
        {
            this.valorVenda = valV;
            return this;
        }













    }
}
