using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public class Passageiro: Usuario
    {
        private double _saldo;

        public double saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public Passageiro()
        {
        }

        public Passageiro(string cpf, string nome, string celular, string email, string senha, double saldo)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.celular = celular;
            this.email = email;
            this.senha = senha;
            this.saldo = saldo;
        }

        public void solicitarCorrida(Endereco origem, Endereco destino)
        {
            Console.WriteLine($"{nome} está solicitando uma corrida");
        }

        public void cancelarCorrida()
        {
            Console.WriteLine($"{nome} está cancelando a corrida");
        }

    }
}
