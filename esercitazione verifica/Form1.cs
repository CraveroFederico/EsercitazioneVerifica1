using esercitazione_verifica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esercitazione_verifica
{
    public partial class Form1 : Form
    {
        private List<Contatti> listaContatti = new List<Contatti>();

        public Form1()
        {
            InitializeComponent();
            btnAggiungi.Enabled = false;
            Contatti c = new Contatti("Lionel", "232355");
            Contatti c2 = new Contatti("Cristano", "123456");
            AggiungiContatto(c, c2);
        }

        private void AggiungiContatto(Contatti contatto1, Contatti contatto2)
        {
            listaContatti.Add(contatto1);
            lst.Items.Add(contatto1.ToString());
            listaContatti.Add(contatto2);
            lst.Items.Add(contatto2.ToString());
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            btnAggiungi.Enabled = false;
            Contatti cont = new Contatti(txtNome.Text, txtNumero.Text);
            listaContatti.Add(cont);
            lst.Items.Add(cont.ToString());
            txtNome.Text = "";
            txtNumero.Text = "";
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex != -1)
            {
                int selectedIndex = lst.SelectedIndex;
                listaContatti.RemoveAt(selectedIndex);
                lst.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Seleziona un contatto da eliminare");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
                btnAggiungi.Enabled = false;
            else
                btnAggiungi.Enabled = true;
        }
    }
}