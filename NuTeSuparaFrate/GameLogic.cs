using System;
using System.Collections.Generic;

namespace NuTeSuparaFrate
{
    public class GameLogic
    {
        public List<int> PozitieJucator { get; private set; }
        public int JucatorCurent {  get; private set; }

        private Random random=new Random();

        public GameLogic(int nrJucatori) 
        {
            PozitieJucator=new List<int>();
            for (int i = 0; i < nrJucatori; i++)
                PozitieJucator.Add(0);

            JucatorCurent = 0;      
        }

        public int AruncaZar()
        {
            return random.Next(1, 7);
        }

        public const int LungimeTabla = 52;
        public void MutaJucatorCurent(int pasi)
        {
            PozitieJucator[JucatorCurent] += pasi;

            if (PozitieJucator[JucatorCurent] >=LungimeTabla)
                 PozitieJucator[JucatorCurent] = LungimeTabla;

            JucatorCurent = (JucatorCurent + 1) % PozitieJucator.Count;
            
        }

         
    }
}
