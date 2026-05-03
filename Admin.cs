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

namespace projekat_2026_Andjela_Stoisavljevic
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void UcitajPopunjenost()
        {
            SqlConnection veza = Konekcija.connect();

            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT 
            s.naziv AS status,
            COUNT(*) AS broj
        FROM termini t
        JOIN status_termina s ON t.status_id = s.id
        GROUP BY s.naziv", veza);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvPopunjenost.DataSource = dt;
        }
        private void UcitajStatistikuPoTreneru()
        {
            SqlConnection veza = Konekcija.connect();

            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT 
            tr.ime + ' ' + tr.prezime AS trener,
            COUNT(t.id) AS broj_termina
        FROM termini t
        JOIN trener tr ON t.trener_id = tr.id
        GROUP BY tr.ime, tr.prezime
        ORDER BY broj_termina DESC", veza);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvStatistika.DataSource = dt;
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            UcitajPopunjenost();
            UcitajStatistikuPoTreneru();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Treneri f = new Treneri();
            f.ShowDialog();
        }
    }
}
