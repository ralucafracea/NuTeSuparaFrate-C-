using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public class Joc
    {
        public List<IJucator> Jucatori { get; }
        public int IndexJucatorCurent { get; private set; } = 0;
        private Random random = new Random();
        public int ValoareZar { get; private set; }

        private static readonly Dictionary<Culoare, int> PunctStartGlobal = new Dictionary<Culoare, int>
        {
            { Culoare.Rosu, 0},
            {Culoare.Verde, 13 },
            {Culoare.Galben,26 },
            {Culoare.Albastru,39 }
        };

        private static readonly Dictionary<Culoare, int> PunctIntrareHome = new Dictionary<Culoare, int>
        {
            {Culoare.Rosu,51 },
            {Culoare.Verde,10 },
            {Culoare.Galben, 23 },
            {Culoare.Albastru, 36 }
        };

        private readonly int[] PozitiiSigure = { 0, 8, 13, 21, 26, 34, 39, 47 };

        public Joc(List<Culoare> culoriParticipante, Culoare culoareJucatorLocal)
        {
            Jucatori = new List<IJucator>();

            foreach (Culoare culoareCurenta in culoriParticipante)
            {
                if (culoareCurenta == culoareJucatorLocal)
                    Jucatori.Add(new JucatorUman(culoareCurenta));
                else
                    Jucatori.Add(new JucatorRetea(culoareCurenta));
            }

        }

        public int AruncaZar()
        {
            ValoareZar = random.Next(1, 7);
            return ValoareZar;
        }


        public bool IncearcaMutare(Piesa piesa, int zar)
        {
            if (piesa.Culoare != Jucatori[IndexJucatorCurent].Culoare)
                return false;

            if (piesa.EsteInBaza)
            {
                if (zar == 6)
                {
                    int pozitieStart = PunctStartGlobal[piesa.Culoare];
                    if (ExistaBlocajPropriu(pozitieStart, piesa.Culoare))
                        return false;
                    piesa.Muta(pozitieStart);
                    VerificaCaptura(piesa);
                    return true;
                }
                return false;
            }
            if (piesa.EsteLaFinal)
            {
                return false;
            }
            int nouaPozitie = piesa.PozitieCurenta + zar;
            int punctIntrare = PunctIntrareHome[piesa.Culoare];
            int distantaPanaLaIntrare;

            if (piesa.PozitieCurenta <= punctIntrare)
                distantaPanaLaIntrare = punctIntrare - piesa.PozitieCurenta;
            else
                distantaPanaLaIntrare = (52 - piesa.PozitieCurenta) + punctIntrare;

            int pasiRamasiPeHomePath = 0;
            if (piesa.PozitieCurenta >= 52 || zar > distantaPanaLaIntrare)
            {

                if (piesa.PozitieCurenta >= 52)
                    pasiRamasiPeHomePath = piesa.PozitieCurenta + zar;
                else
                    pasiRamasiPeHomePath = 52 + (zar - distantaPanaLaIntrare);
            }

            if (pasiRamasiPeHomePath > 58)
            {
                return false;
            }


            bool intraPeHomePath = piesa.PozitieCurenta <= punctIntrare && nouaPozitie > punctIntrare;
            bool esteDejaPeHomePath = piesa.PozitieCurenta >= 52;

            if (intraPeHomePath || esteDejaPeHomePath)
            {
                int mutariPeHomePath;
                if (intraPeHomePath)
                {
                    mutariPeHomePath = nouaPozitie - punctIntrare;
                }
                else
                {
                    mutariPeHomePath = piesa.PozitieCurenta - 51 + zar;
                }

                if (mutariPeHomePath <= 7)
                {
                    int nouaPozitieHome = 51 + mutariPeHomePath;
                    piesa.Muta(nouaPozitieHome);

                    return true;
                }
                return false; //depasire

            }
            piesa.Muta(nouaPozitie % 52);
            VerificaCaptura(piesa);
            return true;
        }

        private bool ExistaBlocajPropriu(int pozitie, Culoare culoare)
        {
            int count = 0;
            foreach (var jucator in Jucatori)
            {
                if (jucator.Culoare == culoare)
                {
                    foreach (var piesa in jucator.Piese)
                    {
                        if (piesa.PozitieCurenta == pozitie)
                        {
                            count++;
                        }
                    }
                }
            }
            return count >= 2;
        }

        private void VerificaCaptura(Piesa piesaMutata)
        {
            if (Array.IndexOf(PozitiiSigure, piesaMutata.PozitieCurenta) != -1)
            {
                return; //nu captureaza pe poz sigure
            }

            foreach (var jucatorAdversar in Jucatori)
            {
                if (jucatorAdversar.Culoare == piesaMutata.Culoare)
                {
                    continue;

                }

                Piesa piesaDeCapturat = null;
                int countPieseAdverse = 0;

                foreach (var piesaAdversara in jucatorAdversar.Piese)
                {
                    if (!piesaAdversara.EsteInBaza && !piesaAdversara.EsteLaFinal && piesaAdversara.PozitieCurenta == piesaMutata.PozitieCurenta)
                    {
                        countPieseAdverse++;
                        piesaDeCapturat = piesaAdversara;
                    }
                }

                if (countPieseAdverse == 1)
                {
                    piesaDeCapturat.TrimiteInBaza();
                    return;
                }
            }

        }

        public void TreciLaUrmatorulJucator()
        {
            IndexJucatorCurent = (IndexJucatorCurent + 1) % Jucatori.Count;
        }

        public bool ExistaMutariValide(int zar)
        {
            IJucator jucatorCurent = Jucatori[IndexJucatorCurent];

            foreach (var piesa in jucatorCurent.Piese)
            {
                if (piesa.EsteInBaza)
                {
                    if (zar == 6)
                    {
                        int pozitieStart = PunctStartGlobal[piesa.Culoare];
                        if (!ExistaBlocajPropriu(pozitieStart, piesa.Culoare))
                            return true;
                    }
                }
                else if (!piesa.EsteLaFinal)
                {
                    if (piesa.PozitieCurenta >= 52)
                    {
                        if (piesa.PozitieCurenta + zar <= 58)
                            return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
