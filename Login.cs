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
        public static int trID;
        public static int trTIP;
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
            SqlConnection veza = Konekcija.connect();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM korisnik WHERE email=@email", veza);

            cmd.Parameters.AddWithValue("@email", txtEmail.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);

            if (tabela.Rows.Count == 0)
            {
                MessageBox.Show("Nepostojeci email");
                return;
            }

            if (txtPass.Text == tabela.Rows[0]["pass"].ToString())
            {
                Login.trID = Convert.ToInt32(tabela.Rows[0]["id"]);
                Login.trTIP = Convert.ToInt32(tabela.Rows[0]["tip_id"]);

                if (Login.trTIP == 1)
                {
                    Admin a = new Admin();
                    this.Hide();
                    a.Show();
                }
                else
                {
                    Glavna g = new Glavna();
                    this.Hide();
                    g.Show();
                }
            }
            else
            {
                MessageBox.Show("Nije dobra lozinka!");
            }
        }
        
    }
}
