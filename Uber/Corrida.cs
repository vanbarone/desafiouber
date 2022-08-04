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

        private Endereco _origem;

        public Endereco origem
        {
            get { return _origem; }
            set { _origem = value; }
        }

        private Endereco _destino;

        public Endereco destino
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

        private Enum.FormaPagto _formaPagto;

        public Enum.FormaPagto formaPagto
        {
            get { return _formaPagto; }
            set { _formaPagto = value; }
        }

        public Corrida(Passageiro passageiro, Endereco origem, Endereco destino, Enum.FormaPagto formaPagto)
        {
            this.data = DateTime.Now;
            this.passageiro = passageiro;
            this.origem = origem;   
            this.destino = destino;
            this.formaPagto = formaPagto;

            this.status = StatusCorrida.statusCorrida.aguardandoMotorista;
        }

        public void iniciarCorrida()
        {
            status = StatusCorrida.statusCorrida.emTransito;

            if (formaPagto == Enum.FormaPagto.crédito)
            {
                Console.WriteLine($"Corrida iniciada - Foi lançada uma cobrança no valor de R$ {valor} no seu cartão de crédito");
            } else if (formaPagto == Enum.FormaPagto.cashUber)
            {
                if (valor <= passageiro.saldo)
                {
                    passageiro.saldo -= valor;
                    Console.WriteLine($"Corrida iniciada - O valor da corrida foi debitado de seu saldo Uber");
                } else
                {
                    Console.WriteLine($"Essa corrida será cancelada pois você não tem saldo Uber suficiente");
                    cancelarCorrida();
                }
            } else
            {
                Console.WriteLine($"Corrida iniciada");
            }
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
            status = StatusCorrida.statusCorrida.finalizada;

            if (formaPagto == Enum.FormaPagto.dinheiro)
            {
                Console.WriteLine($"Corrida finalizada - Você já pode fazer o pagamento para o motorista");
            }
            else
            {
                Console.WriteLine("Corrida Finalizada");
            }

            motorista.alterarStatus(StatusMotorista.statusMotorista.disponível, false);
            status = StatusCorrida.statusCorrida.finalizada;
        }

        public void finalizarCorrida(double novoValor)
        {
            double vlRestante = novoValor - valor;

            valor = novoValor;  

            status = StatusCorrida.statusCorrida.finalizada;

            if (formaPagto == Enum.FormaPagto.crédito)
            {
                Console.WriteLine($"Corrida finalizada com alteração de valor - A diferença de R$ {vlRestante} foi lançada no seu cartão de crédito");
            }
            else if (formaPagto == Enum.FormaPagto.cashUber)
            {
                if (vlRestante <= passageiro.saldo)
                {
                    passageiro.saldo -= vlRestante;
                    Console.WriteLine($"Corrida finalizada com alteração de valor - A diferença de R$ {vlRestante} foi debitada de seu saldo Uber");
                }
                else
                {
                    Console.WriteLine($"Corrida finalizada com alteração de valor - A diferença de R$ {vlRestante} deve ser paga diretamente ao motorista pois seu saldo de Uber é insuficiente");
                }
            }
            else
            {
                Console.WriteLine($"Corrida finalizada com alteração de valor - Você já pode fazer o pagamento para o motorista");
            }

            motorista.alterarStatus(StatusMotorista.statusMotorista.disponível, false);
            status = StatusCorrida.statusCorrida.finalizada;
        }

    }
}
