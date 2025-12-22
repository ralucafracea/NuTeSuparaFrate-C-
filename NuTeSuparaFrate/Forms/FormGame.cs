using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace NuTeSuparaFrate.Forms
{
    

    public partial class FormGame : Form
    {
        private Joc joc;
        
        private Dictionary<Piesa, PictureBox> tokenMap = new Dictionary<Piesa, PictureBox>();
        private int zarCurent = 0;
        private int P;
        
        public FormGame(List<Culoare> culoriJoc, Culoare culoareLocal)
        {
            InitializeComponent();
            pbBoard.BringToFront();
            InitializeBoardBackground();

            joc = new Joc(culoriJoc,culoareLocal);

            pbBoard_SizeChanged(null, null);
            
                      
            UpdateBoard();
            ActualizeazaJucatorCurent();
            PrioritizeCurrentPlayerTokens();
            btnRollDice.Enabled = true;
        }


        private void pbBoard_SizeChanged(object sender, EventArgs e)
        {
            if (pbBoard.Width > 0 && pbBoard.Height > 0)
            {
                P = pbBoard.Width / 15;
                joc.InitializeazaHarta(P);
                UpdateBoard();         
                InitializePlayersGraphics();
            }
        }

        private Point GetBasePosition(Piesa piesa)
        {
            return joc.DeterminaPozitieVizuala(piesa);
        } 


        private void InitializeBoardBackground()
        {
            pbBoard.Image = Properties.Resources.LudoBoard;
            pbBoard.SizeMode = PictureBoxSizeMode.StretchImage;
            //pbBoard.Enabled = false;
        }     

        private void InitializePlayersGraphics()
        {
            
            foreach(var pb in tokenMap.Values)
            {
                pbBoard.Controls.Remove(pb);
                pb.Dispose();
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

                    token.Click += Token_Click;
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
                MessageBox.Show("Arunca zarul!");
                return;
            }

            PictureBox controlClk=(PictureBox)sender;
            Piesa piesaS = (Piesa)controlClk.Tag;

            if(!joc.EsteRandulJucatorului(piesaS.Culoare))
            {
                MessageBox.Show("Nu e randul tau!");
                return;
            }

            int valoareZarCurent = zarCurent;

            if(joc.IncearcaMutare(piesaS, zarCurent))
            {
                UpdateBoard();
                zarCurent = 0;

                if (valoareZarCurent == 6)
                {
                    MessageBox.Show("Ai dat 6 ! Arunca din nou.");
                    btnRollDice.Enabled = true;
                }
                else
                {
                    joc.TreciLaUrmatorulJucator();
                    ActualizeazaJucatorCurent();
                    PrioritizeCurrentPlayerTokens();
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

        private void PrioritizeCurrentPlayerTokens()
        {
            Culoare culoareCurenta = joc.Jucatori[joc.IndexJucatorCurent].Culoare;
            foreach(var pair in tokenMap)
            {
                Piesa piesa = pair.Key;
                PictureBox token = pair.Value;

                if(piesa.Culoare==culoareCurenta)
                {
                    token.BringToFront();
                }
            }
        }

        private void UpdateBoard()
        {
            foreach(var pair in tokenMap)
            {
                Piesa piesa = pair.Key;
                PictureBox token = pair.Value;

                Point coord = joc.DeterminaPozitieVizuala(piesa);

                if(coord==Point.Empty)
                {
                    token.Visible = false;
                }
                else
                {
                    token.Location = coord;
                    token.Visible = true;
                    token.BringToFront();
                }
                
            }
        }

        /*private void Token_MouseEnter(object sender, EventArgs e)
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

        }*/

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }
        private void FormGame_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
