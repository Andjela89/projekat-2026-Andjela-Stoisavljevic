using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace projekat_2026_Andjela_Stoisavljevic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Andjela Stoisavljevic
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.povezi();
            SqlCommand cmd = new SqlCommand("SELECT * FROM korisnik WHERE email='" + txtEmail.Text + "'", veza);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            int broj = tabela.Rows.Count;
            if (broj == 0)
            {
                MessageBox.Show("Nepostojeci email");
            }
            else
            {
                if (txtPass.Text == tabela.Rows[0]["pass"].ToString())
                {
                    Glavna nova = new Glavna();
                    this.Hide();
                    nova.Show();
                }
                else MessageBox.Show("Nije dobra lozinka!");
            }
        }
}
