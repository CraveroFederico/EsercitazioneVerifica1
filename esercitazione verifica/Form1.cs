using esercitazione_verifica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (txtNome.Text == "" || txtNumero.Text == "")
            {
                MessageBox.Show("Inserisci tutti i campi");
                return;
            }

            for (int i = 0; i < listaContatti.Count; i++)
            {
                if(txtNumero.Text == listaContatti[i].Numero || (txtNome.Text == listaContatti[i].Nome && txtNumero.Text == listaContatti[i].Numero))
                {
                    MessageBox.Show("Numero già presente nella lista");
                    return;
                }
            }


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

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtNumero.Text == "")
            {
                MessageBox.Show("Inserisci tutti i campi");
                return;
            }

            if (lst.SelectedIndex != -1)
            {
                int selectedIndex = lst.SelectedIndex;
                listaContatti[selectedIndex].Nome = txtNome.Text;
                listaContatti[selectedIndex].Numero = txtNumero.Text;

                lst.Items[selectedIndex] = listaContatti[selectedIndex];

                txtNome.Text = "";
                txtNumero.Text = "";
            }
            else
            {
                MessageBox.Show("Seleziona un contatto da modificare");
            }
        }

        private void txtCerca_TextChanged(object sender, EventArgs e)
        {
            string ricerca = txtCerca.Text.ToLower();
            lst.Items.Clear();

            foreach (var contatto in listaContatti)
            {
                if (contatto.Nome.ToLower().Contains(ricerca) || contatto.Numero.Contains(ricerca))
                    lst.Items.Add(contatto.ToString());
            }
        }

        private void btnCarica_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Contatti.txt"))
            {
                MessageBox.Show("Il file Contatti.txt non esiste.");
                return;
            }

            listaContatti.Clear();
            lst.Items.Clear();

            using (StreamReader sr = new StreamReader("Contatti.txt"))
            {
                string[] contatto;
                while (!sr.EndOfStream)
                {
                    contatto = sr.ReadLine().Split(',');
                    Contatti c = new Contatti(contatto[0], contatto[1]);
                    listaContatti.Add(c);
                    lst.Items.Add(c.ToString());
                }
            }
        }


        private void btnSalva_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Contatti.txt", false))
            {
                foreach (var contatto in listaContatti)
                {
                    sw.WriteLine($"{contatto.Nome},{contatto.Numero}");
                }
            }
            MessageBox.Show("Rubrica salvata correttamente");
        }
    }
}