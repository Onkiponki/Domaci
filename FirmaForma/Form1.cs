using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FirmaForma
{
    public partial class Form1 : Form
    {
        void sacredRefresh()
        {
            if (podaci.Rows.Count==0)
            {
                topButton.Enabled = false;
                botButton.Enabled = false;
                leftButton.Enabled = false;
                rightButton.Enabled = false;
                deleteButton.Enabled = false;
                updateButton.Enabled = false;
                idText.Text = "";
                nazivText.Text = "";
                pibText.Text = "";
                adresaText.Text = "";
                emailText.Text = "";
                tekracunText.Text = "";
            }
            else
            {
                idText.Text = podaci.Rows[gde]["id"].ToString();
                nazivText.Text = podaci.Rows[gde]["naziv"].ToString();
                pibText.Text = podaci.Rows[gde]["pib"].ToString();
                adresaText.Text = podaci.Rows[gde]["adresa"].ToString();
                emailText.Text = podaci.Rows[gde]["email"].ToString();
                tekracunText.Text = podaci.Rows[gde]["tekRacun"].ToString();

                botButton.Enabled = (gde != podaci.Rows.Count - 1);
                rightButton.Enabled = (gde != podaci.Rows.Count - 1);
                topButton.Enabled = (gde != 0);
                leftButton.Enabled = (gde != 0);
            }
            
        }
        string cs = "Data source = DESKTOP-HLB8M6E\\SQLEXPRESS; Initial catalog = Firma; Integrated security = true";
        int gde = 0;
        DataTable podaci = new DataTable();
        SqlConnection veza;
        string naziv, pib, adresa, email, tekracun;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            veza = new SqlConnection(cs);
            adapter = new SqlDataAdapter("select * from firma", veza);
            adapter.Fill(podaci);
            idText.Enabled = false;
            sacredRefresh();
        }

        private void idText_TextChanged(object sender, EventArgs e)
        {

        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (gde + 1 <= podaci.Rows.Count)
            {
                gde++;
                sacredRefresh();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand(String.Format($"delete from firma where id={idText.Text}"), veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            podaci.Clear();
            adapter = new SqlDataAdapter("select * from firma", veza);
            adapter.Fill(podaci);
            gde = 0;
            sacredRefresh();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            
            veza = new SqlConnection(cs);
            naziv = nazivText.Text;
            pib = pibText.Text;
            adresa = adresaText.Text;
            email = emailText.Text;
            tekracun = tekracunText.Text;
            if (naziv == "" && pib == "" && adresa == "" && email == "" && tekracun == "")
                MessageBox.Show("Unesite makar jedan podatak za updateovanje");
            veza.Open();
            SqlCommand naredba = new SqlCommand($"update firma set naziv = '{naziv}', pib = '{pib}', adresa = '{adresa}', email = '{email}', tekRacun = '{tekracun}' where id = {idText.Text}", veza);
            naredba.ExecuteNonQuery();
            veza.Close();
            podaci.Clear();
            adapter = new SqlDataAdapter("select * from firma", veza);
            adapter.Fill(podaci);
            sacredRefresh();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            nazivText.Text = "";
            pibText.Text = "";
            adresaText.Text = "";
            emailText.Text = "";
            tekracunText.Text = "";
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (gde - 1 >= 0)
            {
                gde--;
                sacredRefresh();
            }
        }

        private void botButton_Click(object sender, EventArgs e)
        {
            gde = podaci.Rows.Count-1;
            sacredRefresh();
        }

        private void topButton_Click(object sender, EventArgs e)
        {
            gde = 0;
            sacredRefresh();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            veza = new SqlConnection(cs);
            naziv = nazivText.Text;
            pib = pibText.Text;
            adresa = adresaText.Text;
            email = emailText.Text;
            tekracun = tekracunText.Text;

            veza.Open();
            SqlCommand naredba = new SqlCommand($"insert into firma values('{naziv}','{pib}','{adresa}','{email}','{tekracun}')", veza);
            naredba.ExecuteNonQuery();
            veza.Close();
            podaci.Clear();
            adapter = new SqlDataAdapter("select * from firma", veza);
            adapter.Fill(podaci);
            gde = podaci.Rows.Count-1;
            sacredRefresh();
        }
    }
}
