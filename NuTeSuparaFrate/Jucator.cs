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

    }

    public class JucatorUman : Jucator
    {
        public JucatorUman(Culoare culoare) : base(culoare) { }
    }

    public class JucatorRetea : Jucator
    {
        public JucatorRetea(Culoare culoare) : base(culoare) { }
    }
}
