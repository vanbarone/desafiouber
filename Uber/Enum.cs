using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber
{
    public static class Enum
    {
        public enum FormaPagto
        {
            dinheiro,
            crédito,
            cashUber
        }
        public enum statusCorrida
        {
            aguardandoMotorista,
            emTransito,
            finalizada,
            cancelada
        }
        public enum statusMotorista
        {
            disponível,
            indisponível,
            ocupado
        }
    }
}
