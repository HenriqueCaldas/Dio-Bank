using BankDio.Classes;
using BankDio.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankDio
{
    class Program
    {
           static List<Conta> ListaContas = new List<Conta>();
           static StreamWriter arquivo = new StreamWriter(@"C:\Users\luish\Desktop\Projetos Estudo\BankDio\arquivos.txt", true);
        static void Main(string[] args)
        {
            Console.WriteLine("Seja Bem Vindo ao Dio Bank");

            string opcaoEscolhida = ObterOpcaoUsuario();
 
            while(opcaoEscolhida.ToUpper() != "X")
            {
                switch(opcaoEscolhida)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        Gravar();
                        break;
                    case "3":
                        Transferir();
                        Gravar();
                        break;
                    case "4":
                        Sacar();
                        Gravar();
                        break;
                    case "5":
                       Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoEscolhida = ObterOpcaoUsuario();
            }
            Gravar();
            
            arquivo.Close();
            Console.WriteLine("Obrigado, Have a nice day!");
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite a conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da transferência");
            double valor = double.Parse(Console.ReadLine());

            ListaContas[indiceContaOrigem].Transferir(valor, ListaContas[indiceContaDestino]);

        }

        private static void Gravar()
        {
            foreach (Conta line in ListaContas)
            {

                arquivo.WriteLine(line);

            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite a conta de depósito");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do depósito");
            double valor = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Depositar(valor);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite a conta que deseja sacar: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor que deseja sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserindo nova conta");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para conta Jurídica");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o Crédito inicial");
            double creditoInicial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta,
                saldo: 0,
                credito: creditoInicial,
                nome: nomeCliente);

            ListaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listando todas as contas");
            if(ListaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i < ListaContas.Count; i++)
            {
                Console.WriteLine("#{0} - {1}", i, ListaContas[i]);
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Novas Contas");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("===============================");

            string opcaoEscolhida = Console.ReadLine();

            return opcaoEscolhida;
        }

    }
}
