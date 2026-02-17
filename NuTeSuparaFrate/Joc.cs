using System;
using System.Collections.Generic;
using System.Drawing;

namespace NuTeSuparaFrate
{
  
    public class Joc
    {
        public List<Jucator> Jucatori { get; set; }
        public int IndexJucatorCurent { get; private set; } = 0;
        private Random random = new Random();
        private List<PunctTabla> boardPositions = new List<PunctTabla>();
        public int numarSaseConsecutiv = 0;
        public int ValoareZar { get; private set; }
        private Dictionary<Culoare, Point[]> BasePositionsAbsolute = new Dictionary<Culoare, Point[]>();
        private readonly Dictionary<Culoare, int> PunctStartGlobal = new Dictionary<Culoare, int>
        {
            {Culoare.Rosu, 0},
            {Culoare.Verde, 13 },
            {Culoare.Galben,26 },
            {Culoare.Albastru,39 }
        };

        private readonly int[] PozitiiSigure = { 0, 8, 13, 21, 26, 34, 39, 47 };
        public struct PunctTabla
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public Joc(List<Culoare> culoriParticipante)
        {
            Jucatori = new List<Jucator>();
            Random rndm = new Random();
            int indexNorocos=rndm.Next(culoriParticipante.Count);

            for(int i=0;i<culoriParticipante.Count;i++)
            {
                Culoare culoareCurenta=culoriParticipante[i];

                if(i==indexNorocos)
                {
                    Jucatori.Add(new JucatorNorocos(culoareCurenta));
                }
                else
                {
                    Jucatori.Add(new JucatorStandard(culoareCurenta));
                }
            }

        }   

        public void InitializeazaHarta(int P)
        {
            if (P == 0)
                return;

            boardPositions.Clear();

            int[,] traseuMatrice = new int[,]
            {
                {1,6},{2,6},{3,6},{4,6},{5,6},//r
                {6,5},{6,4},{6,3},{6,2},{6,1},{6,0},//v
                {7,0}, {8,0}, //v
                {8,1}, {8,2}, {8,3}, {8,4}, {8,5},//v
                {9,6}, {10,6}, {11,6}, {12,6}, {13,6}, {14,6},//g
                {14,7}, {14,8}, //g
                {13,8}, {12,8}, {11,8}, {10,8}, {9,8}, //g
                {8,10}, {8,11}, {8,12}, {8,13}, {8,14}, {8,15},//a
                {7,15}, {6,15}, //a
                {6,14}, {6,13}, {6,12}, {6,11}, {6,10}, //a
                {5,8}, {4,8}, {3,8}, {2,8}, {1,8}, {0,8}, //r
                {0,7},{0,6}//r
            };

            for(int i=0;i<traseuMatrice.GetLength(0);i++)
            {
                int x = traseuMatrice[i, 0];
                int y = traseuMatrice[i, 1];

                int coordX = x * P;
                int coordY = y * P;

                if (y >= 2 && y <= 7) coordY += 7;
                else if (y == 8) coordY += 18;
                else if (y == 9) coordY -= 15;
                else coordY -= 2;

                    boardPositions.Add(new PunctTabla { X = coordX, Y = coordY });
            }

            AdaugaHomePath(P);

            
        }

        public void AdaugaHomePath(int P)
        {
            int[,] homeRosu = new int[,] 
            { 
                { 1, 7 }, { 2, 7 }, { 3, 7 }, { 4, 7 }, { 5, 7 }, { 6, 7 } 
            };
            for (int i = 0; i < 6; i++)
                boardPositions.Add(new PunctTabla { X = homeRosu[i, 0] * P, Y = homeRosu[i, 1] * P + 8 });

            int[,] homeVerde = new int[,] 
            { 
                { 7, 1 }, { 7, 2 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 } 
            };
            for (int i = 0; i < 6; i++)
                boardPositions.Add(new PunctTabla { X = homeVerde[i, 0] * P, Y = homeVerde[i, 1] * P });

            int[,] homeGalben = new int[,] 
            { 
                { 13, 7 }, { 12, 7 }, { 11, 7 }, { 10, 7 }, { 9, 7 }, { 8, 7 } 
            };
            for (int i = 0; i < 6; i++)
                boardPositions.Add(new PunctTabla { X = homeGalben[i, 0] * P, Y = homeGalben[i, 1] * P + 8 });

            int[,] homeAlbastru = new int[,] 
            { 
                { 7, 14 }, { 7, 13 }, { 7, 12 }, { 7, 11 }, { 7, 10 }, { 7, 9 } 
            };
            for (int i = 0; i < 6; i++)
            {
                if (homeAlbastru[i, 1] <= 10)
                    boardPositions.Add(new PunctTabla { X = homeAlbastru[i, 0] * P, Y = homeAlbastru[i, 1] * P -10});
                else
                    boardPositions.Add(new PunctTabla { X = homeAlbastru[i, 0] * P, Y = homeAlbastru[i, 1] * P });
            }
        }

        public void InitializeazaPozitiiBaza(int P)
        {
            BasePositionsAbsolute.Clear();

            BasePositionsAbsolute[Culoare.Rosu] = new Point[]
            {      
                new Point(53,55),
                new Point(110, 55),
                new Point(53, 115),
                new Point(110, 115)
            };

            BasePositionsAbsolute[Culoare.Verde] = new Point[]
            {
                new Point(350, 55),
                new Point(410, 55),
                new Point(350, 115),
                new Point(410, 115)
            };

            BasePositionsAbsolute[Culoare.Galben] = new Point[]
            {
               new Point(350, 375),
               new Point(410, 375),
               new Point(350, 440),
               new Point(410, 440)
            };

            BasePositionsAbsolute[Culoare.Albastru] = new Point[]
            {
                new Point(53, 375),
                new Point(110, 375),
                new Point(53, 440),
                new Point(110, 440)
            };
        }
        public bool EsteRandulJucatorului(Culoare culoarePiesa)
        {
            return Jucatori[IndexJucatorCurent].Culoare == culoarePiesa;
        }

        public Point DeterminaPozitieVizuala(Piesa piesa)
            //toate calculele locatiilor pionilor
        {
            if (piesa.EsteLaFinal)
                return new Point(-100,-100);

            if (piesa.EsteInBaza)
            {
                int indexPiesa = GetIndexPiesaInJucator(piesa);
                return BasePositionsAbsolute[piesa.Culoare][indexPiesa];
            }

            if(piesa.PozitieCurenta>=0 && piesa.PozitieCurenta<boardPositions.Count)
            {
                var pt = boardPositions[piesa.PozitieCurenta];
                
                return new Point(pt.X, pt.Y);
            }
            return Point.Empty;
        }

        private int GetIndexPiesaInJucator(Piesa piesa)
        {
            foreach(var jucator in Jucatori)
            {
                if(jucator.Culoare==piesa.Culoare)
                {
                    for(int i=0;i<jucator.Piese.Length;i++)
                    {
                        if (jucator.Piese[i] == piesa)
                            return i;
                    }
                }
            }
            return -1;
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

            if (!Jucatori[IndexJucatorCurent].PoateMutaPiesa(piesa, zar))
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

            if (pasiViitori >= 56)
            {
                if (pasiViitori == 56)
                {
                    piesa.Muta(-1, 57);
                    piesa.EsteLaFinal = true;
                    return true;
                }
                return false;
            }

            int noulIndexBoard;
            if (pasiViitori < 51)
            {
                noulIndexBoard = (PunctStartGlobal[piesa.Culoare] + pasiViitori) % 52;
            }
            else
            {
                int bazaHome = 52 + ((int)piesa.Culoare * 6);
                noulIndexBoard = bazaHome + (pasiViitori - 51);
            }

            if (ExistaBlocajPropriu(noulIndexBoard, piesa.Culoare))
            {
                return false; 
            }

            piesa.Muta(noulIndexBoard, pasiViitori);

            if (pasiViitori < 51)
                VerificaCaptura(piesa);

            return true;
        }

        private bool ExistaBlocajPropriu(int pozitie, Culoare culoare)
        {
            Jucator jucatorCurent = Jucatori[IndexJucatorCurent];
            int count = 0;
            foreach(var piesa in jucatorCurent.Piese)
            {
                if (piesa.PozitieCurenta == pozitie && !piesa.EsteInBaza)
                    count++;
            }

            return count >= 2;
        }

        private void VerificaCaptura(Piesa piesaMutata)
        {
            foreach(int pozitieSigura in PozitiiSigure)
            {
                if(piesaMutata.PozitieCurenta==pozitieSigura)
                {
                    return;
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

                if (countPieseAdverse == 1 && piesaDeCapturat!=null)
                {
                    piesaDeCapturat.TrimiteInBaza();
                    return;
                }
            }

        }

        public void TreciLaUrmatorulJucator()
        {
            numarSaseConsecutiv = 0;
            IndexJucatorCurent = (IndexJucatorCurent + 1) % Jucatori.Count;
        }

        public bool SaseConsecutiv(int zar)
        {
            if (zar == 6)
            {
                numarSaseConsecutiv++;
                if (numarSaseConsecutiv == 3)
                {
                    TreciLaUrmatorulJucator();
                    return true;
                }
            }
            else
            {
                numarSaseConsecutiv = 0;
            }
            return false;
        }

        public bool ExistaMutariValide(int zar)
        {
            return Jucatori[IndexJucatorCurent].AreMutariPosibile(zar, 52);
        }

        public Jucator VerificaCastigator()
        {
            foreach(var jucator in Jucatori)
            {
                if (jucator.JocFinalizat())
                    return jucator;
            }
            return null;

        }

        
    }
}
