using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public abstract class Usuario
    {
        private string _cpf;
        
        public string cpf
        {
            get { return this._cpf; }
            set { _cpf = value; }
        }

        private string _nome;

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _celular;

        public string celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _senha;

        public string senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public virtual string mostrar()
        {
            return $"{nome} - {email}";
        }

    }
}
