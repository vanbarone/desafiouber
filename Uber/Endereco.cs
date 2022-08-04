using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public class Endereco
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _logradouro;

        public string logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _numero;

        public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _bairro;

        public string bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private string _cidade;

        public string cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        private string _estado;

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _cep;

        public string cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
        }

        public Endereco(string[] campos)
        {
            this.logradouro = campos[0];
            this.numero = campos[1];
            this.bairro = campos[2];
            this.cidade = campos[3];
            this.estado = campos[4];
            this.cep = campos[5];
        }

    }
}
