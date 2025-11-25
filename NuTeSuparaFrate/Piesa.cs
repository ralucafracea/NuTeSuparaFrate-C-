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
        public bool EsteLaFinal { get; private set; } = false;

        public Piesa(Culoare culoare)
        {
            this.Culoare = culoare;
        }

        public void Muta(int nouaPozitie)
        {
            if (nouaPozitie == 58)
            {
                this.EsteLaFinal = true;
                this.PozitieCurenta = nouaPozitie;
            }
            else
            {
                this.PozitieCurenta = nouaPozitie;
                this.EsteLaFinal = false;
            }
        }

        public void TrimiteInBaza()
        {
            this.PozitieCurenta = -1;
            this.EsteLaFinal = false;
        }
    }
}
