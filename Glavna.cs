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
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }
        DataTable tabelaPrikaz;

        private void button1_Click(object sender, EventArgs e)
        {
            NoviTermin f = new NoviTermin();
            f.TerminDodat += UcitajTermine;
            f.ShowDialog();
        }

        private void Glavna_Load(object sender, EventArgs e)
        {
            UcitajTermine();
        }
        private void UcitajTermine()
        {
            SqlConnection veza = Konekcija.connect();

            string upit = @"SELECT 
                        t.id,
                        t.tip,
                        t.sezona,
                        t.datum,
                        t.pocetak,
                        t.trajanje_min,

                        t.trener_id,
                        tr.ime + ' ' + tr.prezime AS trener,

                        t.teren_id,
                        te.tip AS teren,

                        k.ime + ' ' + k.prezime AS korisnik,
                        s.naziv AS status

                    FROM termini t
                    JOIN trener tr ON t.trener_id = tr.id
                    JOIN teren te ON t.teren_id = te.id
                    LEFT JOIN korisnik k ON t.korisnik_id = k.id
                    JOIN status_termina s ON t.status_id = s.id
                    WHERE t.korisnik_id = @korisnik";

            SqlDataAdapter a = new SqlDataAdapter(upit, veza);

            a.SelectCommand.Parameters.Add("@korisnik", SqlDbType.Int).Value = Login.trID;

            tabelaPrikaz = new DataTable();
            a.Fill(tabelaPrikaz);

            dgvTermini.DataSource = tabelaPrikaz;
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            if (dgvTermini.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvTermini.CurrentRow.Cells["id"].Value);

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite da otkažete termin?",
                "Potvrda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rezultat != DialogResult.Yes)
                return;

            SqlConnection veza = Konekcija.connect();

            SqlCommand cmd = new SqlCommand(
                "UPDATE termini SET status_id = 2 WHERE id = @id", veza);

            cmd.Parameters.AddWithValue("@id", id);

            veza.Open();
            cmd.ExecuteNonQuery();
            veza.Close();

            MessageBox.Show("Termin otkazan!");

            UcitajTermine();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvTermini.CurrentRow == null)
                return;

            try
            {
                int id = Convert.ToInt32(dgvTermini.CurrentRow.Cells["id"].Value);
                DateTime datum = Convert.ToDateTime(dgvTermini.CurrentRow.Cells["datum"].Value);
                TimeSpan pocetak = TimeSpan.Parse(dgvTermini.CurrentRow.Cells["pocetak"].Value.ToString());
                int trajanje = Convert.ToInt32(dgvTermini.CurrentRow.Cells["trajanje_min"].Value);

                DialogResult rezultat = MessageBox.Show(
                    "Da li ste sigurni da želite da izmenite termin?",
                    "Potvrda",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rezultat != DialogResult.Yes)
                    return;

                SqlConnection veza = Konekcija.connect();

                SqlCommand cmd = new SqlCommand(@"UPDATE termini 
                                                      SET tip = @tip,
                                                          datum = @datum,
                                                          pocetak = @pocetak,
                                                          trajanje_min = @trajanje,
                                                          trener_id = @trener_id,
                                                          teren_id = @teren_id
                                                      WHERE id = @id", veza);

                cmd.Parameters.AddWithValue("@tip", dgvTermini.CurrentRow.Cells["tip"].Value.ToString());

                cmd.Parameters.AddWithValue("@datum", Convert.ToDateTime(dgvTermini.CurrentRow.Cells["datum"].Value));

                cmd.Parameters.AddWithValue("@pocetak", TimeSpan.Parse(dgvTermini.CurrentRow.Cells["pocetak"].Value.ToString()));

                cmd.Parameters.AddWithValue("@trajanje", Convert.ToInt32(dgvTermini.CurrentRow.Cells["trajanje_min"].Value));

                cmd.Parameters.AddWithValue("@trener_id", Convert.ToInt32(dgvTermini.CurrentRow.Cells["trener_id"].Value));

                cmd.Parameters.AddWithValue("@teren_id", Convert.ToInt32(dgvTermini.CurrentRow.Cells["teren_id"].Value));

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvTermini.CurrentRow.Cells["id"].Value));
                veza.Open();
                int rows = cmd.ExecuteNonQuery();
                veza.Close();
                UcitajTermine();
                dgvTermini.Columns["trener_id"].Visible = false;
                dgvTermini.Columns["teren_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }
    }
}
