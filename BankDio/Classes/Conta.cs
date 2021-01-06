using BankDio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDio.Classes
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        
        public bool Sacar(double valor)
        {
            if ((this.Saldo + this.Credito) < valor)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.Saldo = this.Saldo - valor;
            Console.WriteLine("O saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo = this.Saldo + valor;
            Console.WriteLine("O saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if(this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }

        }

        public override string ToString()
        {
            string retorno = "";
            retorno = retorno + "Tipo Conta: " + this.TipoConta + "|";
            retorno = retorno + "Nome: " + this.Nome + "|";
            retorno = retorno + "Saldo: " + this.Saldo + "|";
            retorno = retorno + "Crédito: " + this.Credito;
            return retorno;
        }
    }
}
