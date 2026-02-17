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


        public FormGame(List<Culoare> culoriJoc)
        {
            InitializeComponent();
            InitializeBoardBackground();
            pbBoard.BringToFront();
            if (pbBoard.Width > 0)
                P = pbBoard.Width / 15;
            else
                P = 40;

            joc = new Joc(culoriJoc);
            joc.InitializeazaHarta(P);
            joc.InitializeazaPozitiiBaza(P);

            foreach(var jucator in joc.Jucatori)
            {
                if(jucator is JucatorNorocos)
                {
                    MessageBox.Show($"Jucatorul {jucator.Culoare} este NOROCOS! Are +1 la zarurile mai mari de 1 si mai mici de 5!");
                }
            }

            InitializePlayersGraphics();
            UpdateBoard();
            pbBoard_SizeChanged(null, null);
            ActualizeazaJucatorCurent();
            btnRollDice.Enabled = true;
            pbZar.Image = Properties.Resources.Dice_Default;
            lblStatus.Text = "Bine ati venit!";


        }
        private void pbBoard_SizeChanged(object sender, EventArgs e)
        {
            if (joc != null && pbBoard.Width > 0 && pbBoard.Height > 0)
            {
                P = pbBoard.Width / 15;
                joc.InitializeazaHarta(P);
                joc.InitializeazaPozitiiBaza(P);
                UpdateBoard();
                InitializePlayersGraphics();
            }
        }
        private void InitializeBoardBackground()
        {
            pbBoard.Image = Properties.Resources.LudoBoard;
            pbBoard.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private Image GetTokenImage(Culoare culoare)
        {
            switch (culoare)
            {
                case Culoare.Rosu: return Properties.Resources.RedToken;
                case Culoare.Verde: return Properties.Resources.GreenToken;
                case Culoare.Albastru: return Properties.Resources.BlueToken;
                case Culoare.Galben: return Properties.Resources.YellowToken;
                default: return null;
            }
        }

        private void InitializePlayersGraphics()
        {

            foreach (var pb in tokenMap.Values)
            {
                pbBoard.Controls.Remove(pb);
                pb.Dispose();
            }
            tokenMap.Clear();

            foreach (var jucator in joc.Jucatori)
            {
                foreach (var piesa in jucator.Piese)
                {
                    PictureBox pbToken = new PictureBox();
                    pbToken.Width = P;
                    pbToken.Height = P;
                    pbToken.Parent = pbBoard;
                    pbToken.BackColor = Color.Transparent;
                    pbToken.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbToken.Image = GetTokenImage(jucator.Culoare);
                    Point pozitieLogica = joc.DeterminaPozitieVizuala(piesa);
                    pbToken.Location = new Point(pozitieLogica.X - pbBoard.Location.X, pozitieLogica.Y - pbBoard.Location.Y);
                    pbToken.Tag = piesa;
                    pbToken.Click += Token_Click;
                    tokenMap.Add(piesa, pbToken);

                }
            }
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            if (zarCurent != 0)
            {
                MessageBox.Show($"Deja ai dat {zarCurent}. Muta o piesa!");
                return;
            }

            int zarAruncat = joc.AruncaZar();
            pbZar.Image = GetDiceImage(zarAruncat);
            int zarFinal = joc.Jucatori[joc.IndexJucatorCurent].AjusteazaValoareZar(zarAruncat);  

            this.zarCurent=zarFinal;        

            var jucatorCrt = joc.Jucatori[joc.IndexJucatorCurent];

            if (joc.SaseConsecutiv(zarCurent))
            {
                lblStatus.Text = "3 de 6 consecutivi! Ai pierdut randul.";
                zarCurent = 0;
                ActualizeazaJucatorCurent();
                btnRollDice.Enabled = true;
                return;
            }

            if (joc.ExistaMutariValide(zarCurent))
            {
                btnRollDice.Enabled = false;

                lblStatus.Text = $"{jucatorCrt.Culoare}: Alege o piesa! Ai dat {zarFinal}!";
            }
            else
            {

                lblStatus.Text = $"Nicio mutare pentru {jucatorCrt.Culoare} zarul cu {zarCurent}";
                joc.TreciLaUrmatorulJucator();
                zarCurent = 0;
                ActualizeazaJucatorCurent();
                btnRollDice.Enabled = true;
            }
        }

        private void Token_Click(object sender, EventArgs e)
        {
            if (zarCurent == 0)
            {
                lblStatus.Text = "Arunca zarul!";
                return;
            }

            PictureBox controlClk = (PictureBox)sender;
            Piesa piesaS = (Piesa)controlClk.Tag;

            if (!joc.EsteRandulJucatorului(piesaS.Culoare))
            {
                MessageBox.Show("Nu e randul tau!");
                return;
            }

            int valoareZarCurent = zarCurent;

            if (joc.IncearcaMutare(piesaS, zarCurent))
            {
                UpdateBoard();
                zarCurent = 0;

                var castigator = joc.VerificaCastigator();
                if (castigator != null)
                {
                    MessageBox.Show($"FELICITARI! Jucatorul {castigator.Culoare} a castigat jocul!");
                    this.Close();
                    return;
                }

                if (valoareZarCurent == 6)
                {
                    lblStatus.Text = "Ai dat 6! Mai da o data";
                    btnRollDice.Enabled = true;
                }
                else
                {
                    joc.TreciLaUrmatorulJucator();
                    ActualizeazaJucatorCurent();
                    lblStatus.Text = "Arunca zarul!";
                    btnRollDice.Enabled = true;
                }
                PrioritizeCurrentPlayerTokens();
            }
            else
            {
                lblStatus.Text = "Mutare invalida! Incearca cu o alta piesa sau apasa pe zar daca nu poti muta.";
            }

        }

        private void ActualizeazaJucatorCurent()
        {
            var jucator = joc.Jucatori[joc.IndexJucatorCurent];
            string culoare = jucator.Culoare.ToString();

            lblJucatorCurent.Text = $"Urmatorul: {culoare}";

            Color culoareText = Color.Black;
            switch (jucator.Culoare)
            {
                case Culoare.Rosu: culoareText = Color.Red; break;
                case Culoare.Galben: culoareText = Color.Goldenrod; break;
                case Culoare.Verde: culoareText = Color.Green; break;
                case Culoare.Albastru: culoareText = Color.Blue; break;
            }

            lblJucatorCurent.ForeColor = culoareText;
            btnRollDice.BackColor = culoareText;

        }

        private void PrioritizeCurrentPlayerTokens()
        {
            Culoare culoareCurenta = joc.Jucatori[joc.IndexJucatorCurent].Culoare;
            foreach (var pair in tokenMap)
            {
                Piesa piesa = pair.Key;
                PictureBox token = pair.Value;

                if (piesa.Culoare == culoareCurenta)
                {
                    token.BringToFront();
                }
            }
        }

        private void UpdateBoard()
        {
            foreach (var pair in tokenMap)
            {
                Piesa piesa = pair.Key;
                PictureBox token = pair.Value;

                Point coord = joc.DeterminaPozitieVizuala(piesa);

                if (coord == Point.Empty || piesa.EsteLaFinal)
                {
                    token.Visible = false;
                    token.Location = new Point(-100, -100);
                }
                else
                {
                    token.Location = coord;
                    token.Visible = true;
                    token.BringToFront();
                }

            }
            pbBoard.Update();
        }

        private Image GetDiceImage(int valoare)
        {
            switch (valoare)
            {
                case 1: return Properties.Resources.Dice_1;
                case 2: return Properties.Resources.Dice_2;
                case 3: return Properties.Resources.Dice_3;
                case 4: return Properties.Resources.Dice_4;
                case 5: return Properties.Resources.Dice_5;
                case 6: return Properties.Resources.Dice_6;
                default: return null;
            }
        }

        private void FormGame_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormGame_SizeChanged(object sender, EventArgs e)
        {
            pbBoard_SizeChanged(null, null);
        }
    }
}