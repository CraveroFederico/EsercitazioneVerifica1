using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercitazione_verifica
{
    internal class Contatti
    {
        public string Nome;
        public string Numero;

        public Contatti(string nome, string numero)
        {
            Nome = nome;
            Numero = numero;
        }

        public override string ToString()
        {
            return $"{Nome} - {Numero}";
        }
    }
}


