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
    public partial class NoviTermin : Form
    {
        public NoviTermin()
        {
            InitializeComponent();
        }
        public event Action TerminDodat;
        private decimal IzracunajCenu(string sezona, int trajanje)
        {
            decimal satnica;

            if (sezona == "leto")
                satnica = 2000; 
            else
                satnica = 1500; 

            decimal cena = (trajanje / 60m) * satnica;
            return cena;
        }
        private void NoviTermin_Load(object sender, EventArgs e)
        {
            UcitajTrenere();
            UcitajTerene();
            cmbTipTermina.Items.Add("stalni");
            cmbTipTermina.Items.Add("jednokratni");
            cmbTipTermina.SelectedIndex = 0;
        }
        private void UcitajTrenere()
        {
            SqlConnection veza = Konekcija.connect();

            SqlDataAdapter da = new SqlDataAdapter("SELECT id, ime + ' ' + prezime AS naziv FROM trener", veza);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbTrener.DataSource = dt;
            cmbTrener.DisplayMember = "naziv";
            cmbTrener.ValueMember = "id";
        }
        private string OdrediSezonu(DateTime datum)
        {
            DateTime p = new DateTime(datum.Year, 4, 1);
            DateTime k = new DateTime(datum.Year, 11, 1);

            return (datum >= p && datum <= k) ? "leto" : "zima";
        }
        private void UcitajTerene()
        {
            SqlConnection veza = Konekcija.connect();

            SqlDataAdapter da = new SqlDataAdapter("SELECT id, tip FROM teren", veza);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbTeren.DataSource = dt;
            cmbTeren.DisplayMember = "tip";
            cmbTeren.ValueMember = "id";
        }

        private void btnZakazi_Click(object sender, EventArgs e)
        {
            DateTime datum = dtpDatum.Value.Date;
            string sezona = OdrediSezonu(datum);
            int trajanje = (int)numTrajanje.Value;

            decimal cena = IzracunajCenu(sezona, trajanje);
            using (SqlConnection veza = Konekcija.connect())
            {
                veza.Open();

                SqlCommand check = new SqlCommand(@"SELECT COUNT(*) 
                                                    FROM termini
                                                    WHERE datum = @datum
                                                    AND (
                                                        (teren_id = @teren OR trener_id = @trener)
                                                        AND ((@pocetak >= pocetak AND @pocetak < DATEADD(MINUTE, trajanje_min, pocetak))
                                                            OR
                                                            (DATEADD(MINUTE, @trajanje, @pocetak) > pocetak 
                                                             AND DATEADD(MINUTE, @trajanje, @pocetak) <= DATEADD(MINUTE, trajanje_min, pocetak))))", veza);

                check.Parameters.AddWithValue("@teren", cmbTeren.SelectedValue);
                check.Parameters.AddWithValue("@datum", datum);
                check.Parameters.AddWithValue("@pocetak", dtpPocetak.Value.TimeOfDay);
                check.Parameters.AddWithValue("@trener", cmbTrener.SelectedValue);
                check.Parameters.AddWithValue("@trajanje", trajanje);

                int postoji = (int)check.ExecuteScalar();

                if (postoji > 0)
                {
                    MessageBox.Show("Termin nije dostupan!");
                    return;
                }
            }
            DialogResult rezultat = MessageBox.Show(
                $"Cena termina je {cena} RSD.\nDa li želite da potvrdite zakazivanje?",
                "Potvrda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (rezultat != DialogResult.Yes)
                return;
            if (cmbTrener.SelectedValue == null || cmbTeren.SelectedValue == null)
            {
                MessageBox.Show("Morate izabrati trenera i teren!");
                return;
            }

            using (SqlConnection veza = Konekcija.connect())
            {
                veza.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO termini
                                                    (tip, sezona, datum, trener_id, teren_id, pocetak, trajanje_min, korisnik_id, status_id)
                                                    VALUES
                                                    (@tip, @sezona, @datum, @trener, @teren, @pocetak, @trajanje, @korisnik, 1)", veza);

                cmd.Parameters.AddWithValue("@tip", cmbTipTermina.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@sezona", sezona);
                cmd.Parameters.AddWithValue("@datum", datum);
                cmd.Parameters.AddWithValue("@trener", cmbTrener.SelectedValue);
                cmd.Parameters.AddWithValue("@teren", cmbTeren.SelectedValue);
                cmd.Parameters.AddWithValue("@pocetak", dtpPocetak.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@trajanje", trajanje);
                cmd.Parameters.AddWithValue("@korisnik", Login.trID);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Termin zakazan!");
            TerminDodat?.Invoke();
            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
