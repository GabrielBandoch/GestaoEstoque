using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


// Dupla: Felipe Da Silva Chawischi & Gabriel Felipe Alves Bandoch
namespace Dominio
{
    public class Registro
    {
        private int[] qtdS = {10,11,12};
        private decimal[] valorVendaS = {21,22,23};

        // campos
        private int dataEntrada;
        private int qtd;
        private string fornecedorCliente;
        private string motivoEntrada;
        private int numFatura;
        private decimal valorCompra;
        private int codigo;

        private decimal valorVenda;
        private int dataSaida;
        private string motivoSaida;

        // get e set
        public int DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        public string FornecedorCliente { get => fornecedorCliente; set => fornecedorCliente = value; }
        public string MotivoEntrada { get => motivoEntrada; set => motivoEntrada = value; }
        public int NumFatura { get => numFatura; set => numFatura = value; }
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public decimal ValorVenda { get => valorVenda; set => valorVenda = value; }
        public int DataSaida { get => dataSaida; set => dataSaida = value; }
        public string MotivoSaida { get => motivoSaida; set => motivoSaida = value; }

        // contrutor
        public Registro(int dataEntrada, int qtd, string fornecedorCliente, string motivoEntrada, int numFatura, decimal valorCompra, int codigo, decimal valorVenda, int dataSaida, string motivoSaida)
        {
            if (qtd <= 0) throw new ArgumentException("Quantidade inválida");
            if (string.IsNullOrEmpty(fornecedorCliente)) throw new ArgumentException("Fornecedor ou cliente inválido");
            if (string.IsNullOrEmpty(motivoEntrada)) throw new ArgumentException("Motivo inválido");
            if (numFatura < 1) throw new ArgumentException("Numero de fatura inválido");
            if (valorCompra <= 0) throw new ArgumentException("Valor de compra inválido");
            if (codigo < 1) throw new ArgumentException("Codigo inválido");
            if (string.IsNullOrEmpty(motivoSaida)) throw new ArgumentException("Motivo inválido");
            if (valorVenda <= 0) throw new ArgumentException("Valor de venda inválido");

            this.dataEntrada = dataEntrada;
            this.qtd = qtd;
            this.fornecedorCliente = fornecedorCliente;
            this.motivoEntrada = motivoEntrada;
            this.numFatura = numFatura;
            this.valorCompra = valorCompra;
            this.codigo = codigo;
            this.valorVenda = valorVenda;
            this.dataSaida = dataSaida;
            this.motivoSaida = motivoSaida;
        }

        public void AtualizarEstoque(int novaQtd, decimal novoValor)
        {
            this.qtd = novaQtd;
            this.ValorVenda = novoValor;
        }

        public void ExcederEstoque(int qtdEstoque)
        {
            if (this.qtd > qtdEstoque) throw new InvalidOperationException("Quantidade do estoque excedida");
        }
    }
}
