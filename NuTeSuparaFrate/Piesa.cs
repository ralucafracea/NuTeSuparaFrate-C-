using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public class Piesa
    {
        public Culoare Culoare { get; }
        public int PozitieCurenta { get; private set; } = -1;
        public bool EsteInBaza => PozitieCurenta == -1;
        public bool EsteLaFinal { get; set; } = false;
        public int PasiParcursi { get; set; } = 0;

        public Piesa(Culoare culoare)
        {
            this.Culoare = culoare;
        }

        public void Muta(int nouaPozitie,int pasiEfectuati)
        {
            this.PozitieCurenta = nouaPozitie;
            this.PasiParcursi = pasiEfectuati;

            if (pasiEfectuati>=57)
            {
                this.EsteLaFinal = true;
            }
            else
            {
                this.EsteLaFinal = false;
            }
        }

        public void TrimiteInBaza()
        {
            this.PozitieCurenta = -1;
            this.PasiParcursi = 0;
            this.EsteLaFinal = false;
        }
    }
}
