using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public class Piesa
    {
        public Culoare Culoare { get; }
        public int Id { get;  }
        public int PozitieCurenta { get; private set; } = -1;
        public int PasiParcursi { get; private set; } = 0;
        public bool EsteInBaza { get; private set; } = true;
        public bool EsteLaFinal { get; set; } = false;


        public Piesa(Culoare culoare,int id)
        {
            this.Culoare = culoare;
            this.Id = id;
        }

        public void Muta(int nouaPozitie,int pasiEfectuati)
        {
            this.PozitieCurenta = nouaPozitie;
            this.PasiParcursi = pasiEfectuati;
            this.EsteInBaza = false;

        }

        public void TrimiteInBaza()
        {
            this.PozitieCurenta = -1;
            this.PasiParcursi = 0;
            this.EsteInBaza = true;
        }
    }
}
