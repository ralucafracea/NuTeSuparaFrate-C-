using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public abstract class Jucator 
    {
        public Culoare Culoare { get; }
        public Piesa[] Piese { get; }

        public Jucator(Culoare culoare)
        {
            this.Culoare = culoare;
            Piese = new Piesa[4];
            for (int i = 0; i < 4; i++)
            {
                Piese[i] = new Piesa(culoare,i);
            }
        }
        public virtual int AjusteazaValoareZar(int valoareInitiala)
        {
            return valoareInitiala;
        }

        public bool JocFinalizat()
        {
            foreach(Piesa piesa in Piese)
            {
                if (piesa.EsteLaFinal == false)
                    return false;
            }
            return true;
            
        }
        public bool AreMutariPosibile(int valoareZar, int lungimeTraseu)
        {
            foreach(var piesa in Piese)
            {
                if (PoateMutaPiesa(piesa, valoareZar))
                    return true;
            }
            return false;
        }

        public bool PoateMutaPiesa(Piesa piesa, int valoareZar)
        {
            if (piesa.EsteLaFinal)
                return false;
            if (piesa.EsteInBaza)
                return valoareZar == 6;

            return (piesa.PasiParcursi + valoareZar <= 57);
        }
    }
}