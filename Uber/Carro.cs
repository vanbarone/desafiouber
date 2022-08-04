using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public class Carro
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _marca;

        public string marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private string _modelo;

        public string modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private string _placa;

        public string placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        private string _cor;

        public string cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

        public Carro(string marca, string modelo, string placa, string cor)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.placa = placa;
            this.cor = cor;
        }

        public string mostrar()
        {
            return $"{marca}/{modelo}/{placa}/{cor}";
        }

    }
}
