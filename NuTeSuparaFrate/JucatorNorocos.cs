using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public class JucatorNorocos : Jucator
    {
        public JucatorNorocos(Culoare culoare) : base(culoare) { }
        public override int AjusteazaValoareZar(int valoareInitiala)
        {
            if (valoareInitiala > 1 && valoareInitiala < 5)
                return valoareInitiala + 1;
            return valoareInitiala;
        }
    }
}
