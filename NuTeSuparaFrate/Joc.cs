using NuTeSuparaFrate.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuTeSuparaFrate
{
    public struct PunctTabla
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Joc
    {
        public List<IJucator> Jucatori { get; }
        public int IndexJucatorCurent { get; private set; } = 0;
        private Random random = new Random();
        private List<PunctTabla> boardPositions = new List<PunctTabla>();
        public int ValoareZar { get; private set; }

        private readonly Dictionary<Culoare, int> PunctStartGlobal = new Dictionary<Culoare, int>
        {
            {Culoare.Rosu, 0},
            {Culoare.Verde, 13 },
            {Culoare.Galben,26 },
            {Culoare.Albastru,39 }
        };

        private readonly Dictionary<Culoare, int> PunctIntrareHome = new Dictionary<Culoare, int>
        {
            {Culoare.Rosu,51 },
            {Culoare.Verde,10 },
            {Culoare.Galben, 23 },
            {Culoare.Albastru, 36 }
        };

        private readonly int[] PozitiiSigure = { 0, 8, 13, 21, 26, 34, 39, 47 };

        public void InitializeazaHarta(int P)
        {
            if (P == 0)
                return;

            boardPositions.Clear();
            //rosu
            boardPositions.Add(new PunctTabla { X = 1 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 2 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 3 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 4 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 5 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 5 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 4 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 3 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 2 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 1 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 0 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 0 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 0 * P });

            //verde
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 1 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 2 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 3 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 4 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 5 * P });
            boardPositions.Add(new PunctTabla { X = 9 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 10 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 11 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 12 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 13 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 14 * P, Y = 6 * P });
            boardPositions.Add(new PunctTabla { X = 14 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 14 * P, Y = 8 * P });

            //galben
            boardPositions.Add(new PunctTabla { X = 13 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 12 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 11 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 10 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 9 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 9 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 10 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 11 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 12 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 13 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 14 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 14 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 14 * P });

            //albastru
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 13 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 12 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 11 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 10 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 9 * P });
            boardPositions.Add(new PunctTabla { X = 5 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 4 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 3 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 2 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 1 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 0 * P, Y = 8 * P });
            boardPositions.Add(new PunctTabla { X = 0 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 0 * P, Y = 6 * P });


            //rosu home
            boardPositions.Add(new PunctTabla { X = 1 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 2 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 3 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 4 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 5 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 6 * P, Y = 7 * P });

            //verde home
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 1 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 2 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 3 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 4 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 5 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 6 * P });

            //galben home
            boardPositions.Add(new PunctTabla { X = 13 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 12 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 11 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 10 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 9 * P, Y = 7 * P });
            boardPositions.Add(new PunctTabla { X = 8 * P, Y = 7 * P });

            //albastru home
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 13 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 12 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 11 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 10 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 9 * P });
            boardPositions.Add(new PunctTabla { X = 7 * P, Y = 8 * P });
        }

        private readonly Dictionary<Culoare, Point[]> BasePositionsAbsolute = new Dictionary<Culoare, Point[]>
        {
            { Culoare.Rosu, new Point[]
                {
                    new Point(53, 55),
                    new Point(110, 55),
                    new Point(53, 115),
                    new Point(110, 115)
                }
            },
            { Culoare.Verde, new Point[]
                {
                    new Point(348, 55),
                    new Point(413, 55),
                    new Point(348, 115),
                    new Point(413, 115)
                }
            },

            { Culoare.Albastru, new Point[]
                {
                    new Point(53, 375),
                    new Point(110, 375),
                    new Point(53, 440),
                    new Point(110, 440)
                }
            },
            { Culoare.Galben, new Point[]
                {
                    new Point(348, 375),
                    new Point(413, 375),
                    new Point(348, 440),
                    new Point(413, 440)
                }
            }
        };

        public Joc(List<Culoare> culoriParticipante, Culoare culoareJucatorLocal)
        {
            Jucatori = new List<IJucator>();

            foreach (Culoare culoareCurenta in culoriParticipante)
            {
                if (culoareCurenta == culoareJucatorLocal)
                    Jucatori.Add(new JucatorLocal(culoareCurenta));
                else
                    Jucatori.Add(new JucatorRetea(culoareCurenta));
            }

        }

        public bool EsteRandulJucatorului(Culoare culoarePiesa)
        {
            return Jucatori[IndexJucatorCurent].Culoare == culoarePiesa;
        }

        public Point DeterminaPozitieVizuala(Piesa piesa)
            //toate calculele locatiilor pionilor
        {
            if (piesa.EsteLaFinal)
                return Point.Empty;

            if(piesa.PozitieCurenta>=0 && piesa.PozitieCurenta<boardPositions.Count)
            {
                var pt = boardPositions[piesa.PozitieCurenta];
                return new Point(pt.X, pt.Y);
            }

            int indexPiesaSet = -1;
            foreach(var jucator in Jucatori)
            {
                if(jucator.Culoare==piesa.Culoare)
                {
                    for(int i=0;i<jucator.Piese.Length;i++)
                    {
                        if (jucator.Piese[i]==piesa)
                        {
                            indexPiesaSet = i;
                            break;
                        }
                    }
                    break;
                }
            }

            if(indexPiesaSet!=-1)
            {
                return BasePositionsAbsolute[piesa.Culoare][indexPiesaSet];
            }
            return Point.Empty;
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
                    piesa.Muta(pozitieStart,0);
                    VerificaCaptura(piesa);
                    return true;
                }
                return false;
            }

            int pasiViitori = piesa.PasiParcursi + zar;

            if(pasiViitori>56)
            {
                if(pasiViitori==57)
                {
                    piesa.EsteLaFinal = true;
                    return true;
                }
                return false;
            }

            int noulIndexBoard;
            if(pasiViitori<51)
            {
                noulIndexBoard = (PunctStartGlobal[piesa.Culoare] + pasiViitori) % 52;
            }
            else
            {
                int bazaHome = 52 + ((int)piesa.Culoare * 6);
                noulIndexBoard = bazaHome + (pasiViitori - 51);
            }

            piesa.Muta(noulIndexBoard, pasiViitori);

            if (pasiViitori < 51)
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
            bool estePozitieSigura = false;
            foreach(int pozitieSigura in PozitiiSigure)
            {
                if(piesaMutata.PozitieCurenta==pozitieSigura)
                {
                    estePozitieSigura |= true;
                    break;
                }
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
