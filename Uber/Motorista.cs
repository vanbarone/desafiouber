using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public class Motorista: Usuario
    {
        private Carro _carro;

        public Carro carro
        {
            get { return _carro; }
            set { _carro = value; }
        }

        private StatusMotorista.statusMotorista _status;

        public StatusMotorista.statusMotorista status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Motorista()
        {
            this.status = StatusMotorista.statusMotorista.disponível;
        }
        
        public Motorista(string cpf, string nome, string celular, string email, string senha, Carro carro)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.celular = celular;
            this.email = email;
            this.senha = senha;
            this.carro = carro;

            this.status = StatusMotorista.statusMotorista.disponível;
        }

        public override string mostrar()
        {
            return $"\t{nome} - Carro: {carro.mostrar()}";
        }

        public bool aceitarCorrida(string origem, string destino, FormaPagamento.FormaPagto formaPagamento)
        {
            string opcao;

            Console.ForegroundColor = ConsoleColor.Blue;   

            Console.WriteLine();
            Console.WriteLine($"{nome} deseja aceitar essa corrida ? (Digite 'S' ou 'N') \n" +
                              $"   Endereço de origem: {origem}\n" +
                              $"   Endereço de destino: {destino}\n" +
                              $"   Forma de pagamento: {formaPagamento}");

            opcao = Console.ReadLine().ToUpper().Trim();
            if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (opcao == "S")
            {
                status = StatusMotorista.statusMotorista.ocupado;

                Console.WriteLine($"\nO motorista {nome} aceitou a corrida - Ele chegará em 5 minutos \n" +
                                  $"\tCarro: {carro.mostrar()}");

                return true;
            } else
            {
                return false;
            }
        }

        public void alterarStatus(StatusMotorista.statusMotorista novoStatus, bool mostraMsg = true)
        {
            status = novoStatus;

            if (mostraMsg)
            {
                Console.WriteLine($"\nMOTORISTA: {nome} alterou seu status para {novoStatus}");
            }
        }

    }
}
