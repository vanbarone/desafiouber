using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public class Corrida
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _data;

        public DateTime data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Passageiro _passageiro;

        public Passageiro passageiro
        {
            get { return _passageiro; }
            set { _passageiro = value; }
        }

        private string _origem;

        public string origem
        {
            get { return _origem; }
            set { _origem = value; }
        }

        private string _destino;

        public string destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

        private Motorista _motorista;

        public Motorista motorista
        {
            get { return _motorista; }
            set { _motorista = value;}
        }

        private Carro _carro;

        public Carro carro
        {
            get { return _carro; }
            set { _carro = value; }
        }

        private double _valor;

        public double valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private StatusCorrida.statusCorrida _status;

        public StatusCorrida.statusCorrida status
        {
            get { return _status; }
            set { _status = value; }
        }

        private FormaPagamento.FormaPagto _formaPagto;

        public FormaPagamento.FormaPagto formaPagto
        {
            get { return _formaPagto; }
            set { _formaPagto = value; }
        }

        public Corrida(Passageiro passageiro, string origem, string destino)
        {
            this.data = DateTime.Now;
            this.passageiro = passageiro;
            this.origem = origem;   
            this.destino = destino;

            this.valor = calcularValor();
            this.status = StatusCorrida.statusCorrida.aguardandoMotorista;
        }

        public void iniciarCorrida()
        {
            status = StatusCorrida.statusCorrida.emAndamento;

            Console.WriteLine($"\nCORRIDA INICIADA ***********");

            cobrarCorrida();
         }

        public void cobrarCorrida()
        {
            if (formaPagto == FormaPagamento.FormaPagto.crédito)
            {
                Console.WriteLine($"\tATENÇÂO: Foi lançada uma cobrança no valor de R$ {valor} no seu cartão de crédito");
            }
            else if (formaPagto == FormaPagamento.FormaPagto.cashUber)
            {
                passageiro.saldo -= valor;
                Console.WriteLine($"\tATENÇÂO: O valor de R$ {valor} foi debitado de seu saldo Uber (Saldo atual: {passageiro.saldo})");
            }
        }

        public void cobrarCorrida(double novoValor)
        {
            double vlDiferenca = novoValor - valor;

            valor = novoValor;

            if (formaPagto == FormaPagamento.FormaPagto.crédito)
            {
                Console.WriteLine($"\tATENÇÂO: Foi lançada uma cobrança no valor de R$ {vlDiferenca} no seu cartão de crédito");
            }
            else if (formaPagto == FormaPagamento.FormaPagto.cashUber)
            {
                if (vlDiferenca <= passageiro.saldo)
                {
                    passageiro.saldo -= vlDiferenca;
                    Console.WriteLine($"\tATENÇÂO: O valor de R$ {vlDiferenca} foi debitado de seu saldo Uber (Saldo atual: {passageiro.saldo})");
                }
                else
                {
                    Console.WriteLine($"\tATENÇÂO: A diferença de R$ {vlDiferenca} deve ser paga diretamente ao motorista pois seu saldo de Uber é insuficiente");
                }
            }
        }

        public double calcularValor()
        {
            return 70;
        }

        public void cancelarCorrida()
        {
            status = StatusCorrida.statusCorrida.cancelada;

            if (motorista != null)
            {
                motorista.alterarStatus(StatusMotorista.statusMotorista.disponível, false);
            }
        }

        public void finalizarCorrida()
        {
            Console.WriteLine("\nCORRIDA FINALIZADA ***********");

            motorista.alterarStatus(StatusMotorista.statusMotorista.disponível, false);

            status = StatusCorrida.statusCorrida.finalizada;

            if (formaPagto == FormaPagamento.FormaPagto.dinheiro)
            {
                Console.WriteLine($"\nATENÇÂO: Você já pode fazer o pagamento para o motorista");    
            }
        }
    }
}
