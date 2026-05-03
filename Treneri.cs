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

namespace projekat_2026_Andjela_Stoisavljevic
{
    public partial class Treneri : Form
    {
        public Treneri()
        {
            InitializeComponent();
        }
        private void UcitajTrenere()
        {
            using (SqlConnection veza = new SqlConnection(Konekcija.connect().ConnectionString))
            {
                veza.Open();

                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT id, ime, prezime, kontakt
            FROM trener
            WHERE aktivan = @aktivan", veza);

                da.SelectCommand.Parameters.Add("@aktivan", SqlDbType.Bit).Value = true;

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTreneri.DataSource = null;
                dgvTreneri.DataSource = dt;

                dgvTreneri.Columns["id"].ReadOnly = true;
                dgvTreneri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTreneri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTreneri.AllowUserToAddRows = false;
            }
        }
        private void Treneri_Load(object sender, EventArgs e)
        {
            UcitajTrenere();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
        string.IsNullOrWhiteSpace(txtPrezime.Text) ||
        string.IsNullOrWhiteSpace(txtKontakt.Text))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            using (SqlConnection veza = Konekcija.connect())
            {
                veza.Open();

                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO trener (ime, prezime, kontakt)
            VALUES (@ime, @prezime, @kontakt)", veza);

                cmd.Parameters.AddWithValue("@ime", txtIme.Text.Trim());
                cmd.Parameters.AddWithValue("@prezime", txtPrezime.Text.Trim());
                cmd.Parameters.AddWithValue("@kontakt", txtKontakt.Text.Trim());

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Trener uspešno dodat!");
            txtIme.Clear();
            txtPrezime.Clear();
            txtKontakt.Clear();
            UcitajTrenere();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvTreneri.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvTreneri.CurrentRow.Cells["id"].Value);

            using (SqlConnection veza = Konekcija.connect())
            {
                veza.Open();
                SqlCommand check = new SqlCommand(@"SELECT COUNT(*)
                                                    FROM termini
                                                    WHERE trener_id = @id
                                                    AND datum >= CAST(GETDATE() AS DATE)", veza);

                check.Parameters.AddWithValue("@id", id);

                int brojTermina = (int)check.ExecuteScalar();

                if (brojTermina > 0)
                {
                    MessageBox.Show("Ne možete otpustiti trenera jer ima zakazane termine u budućnosti!");
                    return;
                }
                SqlCommand cmd = new SqlCommand(@"UPDATE trener
                                                  SET aktivan = 0
                                                  WHERE id = @id", veza);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Trener otpušten!");
            UcitajTrenere();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvTreneri.CurrentRow == null)
                return;
            int id = Convert.ToInt32(dgvTreneri.CurrentRow.Cells["id"].Value);
            string ime = dgvTreneri.CurrentRow.Cells["ime"].Value.ToString();
            string prezime = dgvTreneri.CurrentRow.Cells["prezime"].Value.ToString();
            string kontakt = dgvTreneri.CurrentRow.Cells["kontakt"].Value.ToString();

            using (SqlConnection veza = Konekcija.connect())
            {
                veza.Open();

                SqlCommand cmd = new SqlCommand(@"UPDATE trener
                                                    SET ime = @ime,
                                                        prezime = @prezime,
                                                        kontakt = @kontakt
                                                    WHERE id = @id", veza);
                cmd.Parameters.AddWithValue("@ime", ime);
                cmd.Parameters.AddWithValue("@prezime", prezime);
                cmd.Parameters.AddWithValue("@kontakt", kontakt);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Izmenjeno!");
            UcitajTrenere();
        }
    }
}
