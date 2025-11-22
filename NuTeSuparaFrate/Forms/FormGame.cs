using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NuTeSuparaFrate.Properties;
using NuTeSuparaFrate;
using System.Linq;
using System.Runtime.Remoting.Channels;
namespace NuTeSuparaFrate.Forms
{
    public struct PunctTabla
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public partial class FormGame : Form
    {
        private Joc joc;
        private List<PunctTabla> boardPositions = new List<PunctTabla>();
        private Dictionary<Piesa, PictureBox> tokenMap = new Dictionary<Piesa, PictureBox>();
        private int zarCurent = 0;
        private Dictionary<Culoare, PunctTabla> baseMap = new Dictionary<Culoare, PunctTabla>();
        private int P;
        
        public FormGame(List<Culoare> culoriJoc, Culoare culoareLocal)
        {
            InitializeComponent();
            pbBoard.BringToFront();
            InitializeBoardBackground();
            joc = new Joc(culoriJoc,culoareLocal);
            pbBoard_SizeChanged(null, null);
            InitializeBaseMap();
            InitializePlayersGraphics();          
            UpdateBoard();
            ActualizeazaJucatorCurent();

            btnRollDice.Enabled = true;
        }

        private void GenerateBoardPositions()
        {
            if (P == 0)
                return;

            boardPositions.Clear();

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


        private void pbBoard_SizeChanged(object sender, EventArgs e)
        {
            if (pbBoard.Width > 0 && pbBoard.Height > 0)
            {
                P = pbBoard.Width / 15;
                GenerateBoardPositions();
                UpdateBoard();

                InitializeBaseMap();
                InitializePlayersGraphics();
            }
        }

        private void InitializeBaseMap()
        {
            int P_val =(P==0)? 30:P;
            baseMap.Clear();
            baseMap.Add(Culoare.Rosu, new PunctTabla { X = 0, Y = 0 });
            baseMap.Add(Culoare.Verde, new PunctTabla { X = 9 * P_val, Y = 0 });
            baseMap.Add(Culoare.Albastru, new PunctTabla { X = 0, Y = 9 * P_val });
            baseMap.Add(Culoare.Galben, new PunctTabla { X = 9 * P_val, Y = 9 * P_val });

        }


        private Point GetBasePosition(Piesa piesa)
        {
            IJucator jucator = joc.Jucatori.FirstOrDefault(j => j.Culoare == piesa.Culoare);

            if (jucator == null) return new Point(0, 0);

            int piesaIndex = -1;
            for(int i=0;i<jucator.Piese.Length;i++)
            {
                if (jucator.Piese[i]==piesa)
                {
                    piesaIndex = i;
                    break;
                }
            }
            if (piesaIndex == -1)
                return new Point(0, 0);


            PunctTabla baseStart = baseMap[piesa.Culoare];

            
            int pionSize = P;
            int Boffset = 90; //distanta intre pioni
            int Bpadding = 45;
            double scalareFactor = (double)P / 30.0;
            int offset = (int)(Boffset * scalareFactor);
            int paddingX = (int)(Bpadding * scalareFactor);
            int paddingY = (int)(Bpadding * scalareFactor);

            int col = piesaIndex % 2;
            int row = piesaIndex / 2;

            int finalX=baseStart.X+paddingX+col*offset;
            int finalY = baseStart.Y + paddingY + row * offset;

            if (row == 0) finalY += (int)(5 * scalareFactor);
            if (row == 1) finalY -= (int)(5 * scalareFactor);
            if (col == 0) finalX += (int)(5 * scalareFactor);
            if (col == 1) finalX -= (int)(5 * scalareFactor);

            // Offset universal (pentru a compensa marginea)
            finalX -= (int)(5 * scalareFactor);
            finalY -= (int)(5 * scalareFactor);

            return new Point(finalX - (pionSize / 2), finalY - (pionSize / 2));
        }

        private void InitializeBoardBackground()
        {
            pbBoard.Image = Properties.Resources.LudoBoard;
            pbBoard.SizeMode = PictureBoxSizeMode.StretchImage;
            //pbBoard.Enabled = false;
        }     

        private void InitializePlayersGraphics()
        {
            List<Control> controlsToRemove = new List<Control>();
            foreach(Control control in pbBoard.Controls)
            {
                if(control is PictureBox && control.Tag is Piesa)
                    controlsToRemove.Add(control);
            }
            foreach(Control control in controlsToRemove)
            {
                pbBoard.Controls.Remove(control);
                control.Dispose();
            }

            tokenMap.Clear();

            foreach(var jucator in joc.Jucatori)
            {
                foreach(var piesa in jucator.Piese)
                {
                    PictureBox token = new PictureBox();
                    token.Width = P;
                    token.Height = P;
                    token.BackColor = Color.Transparent;
                    token.SizeMode = PictureBoxSizeMode.StretchImage;
                    token.Image = GetTokenImage(jucator.Culoare);
                    token.Parent = pbBoard;
                    token.Tag = piesa;

                    Point basePos = GetBasePosition(piesa);
                    token.Left = basePos.X;
                    token.Top= basePos.Y;

                    token.Click += Token_Click;
                   
                    token.BringToFront();
                    tokenMap.Add(piesa, token);
                    pbBoard.Controls.Add(token);

                    
                }
            }       
        }

        private Image GetTokenImage(Culoare culoare)
        {
            switch(culoare)
            {
                case Culoare.Rosu: return Properties.Resources.RedToken;
                case Culoare.Verde: return Properties.Resources.GreenToken;
                case Culoare.Albastru: return Properties.Resources.BlueToken;
                case Culoare.Galben: return Properties.Resources.YellowToken;
                default: return null;
            }
        }


        private void btnRollDice_Click(object sender, EventArgs e)
        {
            if(zarCurent!=0)
            {
                MessageBox.Show($"Deja ai dat {zarCurent}. Muta o piesa!");
                return;
            }

            zarCurent = joc.AruncaZar();
            MessageBox.Show($"Jucatorul {joc.Jucatori[joc.IndexJucatorCurent].Culoare} a dat {zarCurent}");
            if(joc.ExistaMutariValide(zarCurent))
            {
                btnRollDice.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Nu poti muta nicio piesa cu {zarCurent}.");
                joc.TreciLaUrmatorulJucator();
                zarCurent = 0;
                ActualizeazaJucatorCurent();
                btnRollDice.Enabled = true;
            }
        }

        private void Token_Click(object sender, EventArgs e)
        {
            if(zarCurent==0)
            {
                MessageBox.Show("Arunca zarul mai intai!");
                return;
            }

            PictureBox controlClicat=(PictureBox)sender;
            Piesa piesaSelectata = (Piesa)controlClicat.Tag;

            if(piesaSelectata.Culoare != joc.Jucatori[joc.IndexJucatorCurent].Culoare)
            {
                MessageBox.Show("Nu e randul tau!");
                return;
            }

            bool mutareValida = joc.IncearcaMutare(piesaSelectata, zarCurent);
            
            if(mutareValida)
            {
                UpdateBoard();
                int valoareZarFolosit = zarCurent;
                zarCurent = 0;

                if(valoareZarFolosit==6)
                {
                    MessageBox.Show("Ai dat6! Arunca din nou.");
                    btnRollDice.Enabled = true;
                }
                else
                {
                    joc.TreciLaUrmatorulJucator();
                    ActualizeazaJucatorCurent();
                    btnRollDice.Enabled = true;
                }
                

            }
            else
            {
                MessageBox.Show("Mutare invalida! Incearca cu o alta piesa sau apasa pe zar daca nu poti muta.");
            }
            
        }

        private void ActualizeazaJucatorCurent()
        {
            var jucator = joc.Jucatori[joc.IndexJucatorCurent];
            string culoare = jucator.Culoare.ToString();

            lblJucatorCurent.Text = $"Randul: {culoare}";

            Color culoareText = Color.Black;
            switch(jucator.Culoare)
            {
                case Culoare.Rosu: culoareText = Color.Red;break;
                case Culoare.Galben: culoareText = Color.Goldenrod; break;
                case Culoare.Verde: culoareText = Color.Green; break;
                case Culoare.Albastru: culoareText = Color.Blue; break;
            }

            lblJucatorCurent.ForeColor = culoareText;
        }

        private void UpdateBoard()
        {
            foreach(var pair in tokenMap)
            {
                Piesa piesa = pair.Key;
                PictureBox token = pair.Value;

                if(piesa.PozitieCurenta>=0 && piesa.PozitieCurenta < boardPositions.Count)
                {
                    PunctTabla target = boardPositions[piesa.PozitieCurenta];
                    token.Left = target.X;
                    token.Top = target.Y;
                    token.Visible = true;
                }
                else if(piesa.EsteInBaza)
                {
                    Point basePos = GetBasePosition(piesa);
                    token.Left = basePos.X;
                    token.Top = basePos.Y;
                    token.Visible = true;
                }
                else if(piesa.EsteLaFinal)
                {
                    token.Visible = false;
                }
                token.BringToFront();
            }
        }

        private void Token_MouseEnter(object sender, EventArgs e)
        {
            PictureBox token = (PictureBox)sender;
            Piesa piesa = (Piesa)token.Tag;

            if (zarCurent!=0 && piesa.Culoare == joc.Jucatori[joc.IndexJucatorCurent].Culoare)
            {
                token.Cursor = Cursors.Hand;
                token.BorderStyle = BorderStyle.FixedSingle;
                token.Size = new Size(P + 5, P + 5);
            }
            else
            {
                token.Cursor = Cursors.Default;
            }
        }

        private void Token_MouseLeave(object sender, EventArgs e)
        {
            PictureBox token = (PictureBox)sender;
            token.BorderStyle = BorderStyle.None;
            token.Size = new Size(P, P);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }
    }
}
