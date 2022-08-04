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
            return $"MOTORISTA: {nome} - {email} - {status} - ({carro.mostrar()})";
        }

        public void aceitarCorrida()
        {
            status = StatusMotorista.statusMotorista.ocupado;

            Console.WriteLine($"O motorista {nome} aceitou a corrida");
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
