using System;
using System.Collections.Generic;
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
            if (cbGalben.Checked)
                culoriAlese.Add(Culoare.Galben);
            if (cbAlbastru.Checked)
                culoriAlese.Add(Culoare.Albastru);
            if (cbVerde.Checked)
                culoriAlese.Add(Culoare.Verde);     

            if (culoriAlese.Count < 2)
            {
                MessageBox.Show("Jocul necesita minim 2 jucatori. Selecteaza cel putin 2 culori!");
                return;
            }
            Culoare culoareLocal = (Culoare)cbCuloare.SelectedItem; 
            bool participa = false;

            foreach(var c in culoriAlese)
            {
                if (c == culoareLocal)
                    participa = true;
            }

            if(!participa)
            {
                MessageBox.Show($"Trebuie sa incluzi culoarea {culoareLocal} in selectia de jucatori");
                return;
            }

            try
            {
                jocForm = new FormGame(culoriAlese);
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
