using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuTeSuparaFrate.Forms
{
    public partial class FormStart : Form
    {
        public FormGame jocForm;
        public FormStart()
        {
            InitializeComponent();
        }
        private void FormStart_Load(object sender, EventArgs e)
        {
            cbCuloare.DataSource = Enum.GetValues(typeof(Culoare));
            cbCuloare.SelectedIndex = 0;
        }



        private void btnStartGame_Click(object sender, EventArgs e)
        {
            List<Culoare> culoriAlese = new List<Culoare>();
            if (cbRosu.Checked)
                culoriAlese.Add(Culoare.Rosu);
            if (cbAlbastru.Checked)
                culoriAlese.Add(Culoare.Albastru);
            if (cbGalben.Checked)
                culoriAlese.Add(Culoare.Galben);
            if (cbVerde.Checked)
                culoriAlese.Add(Culoare.Verde);

            if (culoriAlese.Count < 2)
            {
                MessageBox.Show("Jocul necesita minim 2 jucatori. Selecteaza cel putin 2 culori.");
                return;
            }
            Culoare culoareLocal;

            if (cbCuloare.SelectedItem == null || !Enum.TryParse(cbCuloare.SelectedItem.ToString(), out culoareLocal))
            {
                MessageBox.Show("Alege o culoare pentru tine din caseta de selectie.");
                return;
            }

            if (!culoriAlese.Contains(culoareLocal))
            {
                MessageBox.Show($"Trebuie sa incluzi culoarea {culoareLocal} in selectia de jucatori");
                return;
            }

            try
            {
                jocForm = new FormGame(culoriAlese, culoareLocal);
                jocForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la pornirea jocului: {ex.Message}");

            }
        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
