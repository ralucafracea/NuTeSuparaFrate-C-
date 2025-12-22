using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public interface IJucator
    {
        Culoare Culoare { get; }
        Piesa[] Piese { get; }
    }
    public abstract class Jucator : IJucator
    {
        public Culoare Culoare { get; }
        public Piesa[] Piese { get; }

        public Jucator(Culoare culoare)
        {
            this.Culoare = culoare;
            Piese = new Piesa[4];
            for (int i = 0; i < 4; i++)
            {
                Piese[i] = new Piesa(culoare);
            }
        }
        public abstract void JoacaRandul(int valoareZar);

    }

    public class JucatorLocal : Jucator
    {
        public JucatorLocal(Culoare culoare) : base(culoare) { }

        public override void JoacaRandul(int valoareZar)
        {
            // Aici vei activa logica de click pe pionii tăi
            // (Vei face PictureBox-urile clicabile)
        }
    }

    public class JucatorRetea : Jucator
    {
        public JucatorRetea(Culoare culoare) : base(culoare) { }
        public override void JoacaRandul(int valoareZar)
        {
            // Aici nu faci nimic cu mouse-ul. 
            // Aștepți pachetul de date prin TCP.
        }
    }
}
