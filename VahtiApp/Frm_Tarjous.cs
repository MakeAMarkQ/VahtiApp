using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VahtiApp
{
    public partial class Frm_Tarjous : Form
    {
        Tarjous clEditTarjous;
        public Frm_Tarjous()
        {
            InitializeComponent();
        }
        //public Frm_Tarjous(Tarjous ClTarj)
        //{
        //    clEditTarjous = ClTarj;
        //    InitializeComponent();
        //}

        private void Frm_Tarjous_Shown(object sender, EventArgs e)
        {
            
            Tarjous clTemp = new Tarjous();
            clEditTarjous = clTemp.kyseinen(null);
            Txtbx_Kunta.Text = clEditTarjous.strKunta;
            TxtBx_Tunnus.Text = clEditTarjous.strTunnus;
            TxtBx_AlkuperainenLinkki.Text = clEditTarjous.strAlkuperainenLinkki;
            TxtBx_TajousDocLinkki.Text = clEditTarjous.strTajousDocLinkki;
            TxtBx_TarjousDirLinkki.Text = clEditTarjous.strTarjousDirLinkki;
            TxtBx_Pyynto.Text = clEditTarjous.strPyynto;
            TxtBx_MaaraAika.Text = clEditTarjous.strMaaraAika;
            TxtBx_DataBase.Text = clEditTarjous.strDataBase;
            TxtBx_Kuvaus.Text = clEditTarjous.strKuvaus;
            TxtBx_Kommentti.Text = clEditTarjous.strKommentti; 
            
            TxtBx_Julkaistu.Text = clEditTarjous.strJulkaistu;
            TxtBx_IlmoitusTyyppi.Text = clEditTarjous.strIlmoitusTyyppi;
            TxtBx_VaihtoehtoLinkki.Text = clEditTarjous.strVaihtoehtoLinkki;
            ChckBx_Filtered.Checked = clEditTarjous.strFiltered.ToLower().Equals("true");
            ChckBx_Kuvaushaettu.Checked = clEditTarjous.strKuvaushaettu.ToLower().Equals("true");


        }

        private void Btn_Peru_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            clEditTarjous.strKunta = Txtbx_Kunta.Text;
            clEditTarjous.strTunnus = TxtBx_Tunnus.Text;
            clEditTarjous.strAlkuperainenLinkki = TxtBx_AlkuperainenLinkki.Text;
            clEditTarjous.strTajousDocLinkki = TxtBx_TajousDocLinkki.Text;
            clEditTarjous.strTarjousDirLinkki = TxtBx_TarjousDirLinkki.Text;
            clEditTarjous.strPyynto = TxtBx_Pyynto.Text;
            clEditTarjous.strMaaraAika = TxtBx_MaaraAika.Text;
            clEditTarjous.strDataBase = TxtBx_DataBase.Text;
            clEditTarjous.strKommentti = TxtBx_Kommentti.Text;
            clEditTarjous.strKuvaus = TxtBx_Kuvaus.Text;
            clEditTarjous.strJulkaistu = TxtBx_Julkaistu.Text;
            clEditTarjous.strIlmoitusTyyppi = TxtBx_IlmoitusTyyppi.Text;
            clEditTarjous.strVaihtoehtoLinkki = TxtBx_VaihtoehtoLinkki.Text;
            clEditTarjous.strFiltered = ChckBx_Filtered.Checked.ToString();
            clEditTarjous.strKuvaushaettu = ChckBx_Kuvaushaettu.Checked.ToString();
            clEditTarjous.kyseinen(clEditTarjous);
            this.Hide();
        }

        private void btnAP_Click(object sender, EventArgs e)
        {
            WB_tarous.Navigate(TxtBx_AlkuperainenLinkki.Text);
        }

        private void btnTDL_Click(object sender, EventArgs e)
        {
            WB_tarous.Navigate(TxtBx_TajousDocLinkki.Text);
        }

        private void btnVEL_Click(object sender, EventArgs e)
        {
            WB_tarous.Navigate(TxtBx_VaihtoehtoLinkki.Text);
        }

        private void btnTdirL_Click(object sender, EventArgs e)
        {
            WB_tarous.Navigate(TxtBx_TarjousDirLinkki.Text);
        }
    }
}
